using AppButaca.dominio;
using AppButaca.dominio.Interfaces.Repositorios;
using AppButaca.Infraestructura.Datos.Contextos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppButaca.Infraestructura.Datos.Repositorios
{
    public class BookingRepositorio : IRepositorioMovimiento<BookingEntity, int, String, DateTime>
    {
        private ButacasContexto db;

        public BookingRepositorio(ButacasContexto _db)
        {
            db = _db;
        }


        public BookingEntity Agregar(BookingEntity entidad)
        {
            db.Bookings.Add(entidad);
            return entidad;

        }


        //=================================
        // ORDEN - 2A
        //=================================
        public IEnumerable<BookingEntity> IObtenerPeliculaPorFecha(String genre, DateTime startDate, DateTime endDate)
        {
            
            MovieGenreEnum genreEnum;
            if (!Enum.TryParse(genre, true, out genreEnum))
            {
              Console.WriteLine("Genre no es valido");
            }
            int genreValue = (int)genreEnum + 1;

            var listMovieID = db.Movies
                .Where(m => (int)m.Genre == genreValue) 
                .Select(m => m.Id) 
                .ToList();

            var bookings = db.Bookings
                   .Where(b => listMovieID.Contains(b.Billboard.MovieId) &&
                   b.Date >= startDate && b.Date <= endDate)
                   .ToList();

            return bookings;
                
        }


        //=================================
        // ORDEN - 2B
        //=================================

        public IEnumerable<object> ObtenerButacasPorDisponibilidad()
        {

            var current_date = DateTime.Now.Date;
            var billboardsAvailable = db.Billboards.Where(bb => bb.Date >= current_date && bb.Status == true).Select(m => m.Id).ToList(); //&& bb.Status == true
            

            var seatsIdOcupados = db.Bookings
                   .Where(b => billboardsAvailable.Contains(b.BillboardId)).Select(c => c.SeatId)
                   .ToList();

            
            var seatsOcupados = db.Seats
                .Where(s => seatsIdOcupados.Contains(s.Id) && s.Status == true)
                .Select(s => new { 
                   number = s.Number ,
                   rowNumber = s.RowNumber,
                   idRoom = s.RoomId,
                   roomName = s.Room.Name,
                   roomNumber = s.Room.Number
                })
                .ToList();


            var seatsDisponibles = db.Seats
                .Where(s => !seatsIdOcupados.Contains(s.Id) && s.Status == true)
                 .Select(s => new {
                     number = s.Number,
                     rowNumber = s.RowNumber,
                     idRoom = s.RoomId,
                     roomName = s.Room.Name,
                     roomNumber = s.Room.Number
                 })
                .ToList();

            var result = new
            {
                ocupadas = seatsOcupados,
                disponibles = seatsDisponibles
            };


            return new List<object> { result};
        }

        //=================================
        // ORDEN - 3A
        //=================================
        public object Inhabilitar(int entidadId)
        {
  
            using (var dbContextTransaction = db.Database.BeginTransaction())

             try

             {
                var asiento = db.Seats.Find(entidadId);

                 if (asiento != null)
                    {
                        asiento.Status = false;
                        db.SaveChanges();
                        dbContextTransaction.Commit();

                        var asientoInhabilitado = db.Seats.Find(entidadId);
                        //var asientoInhabilitado2 = db.Seats.Where(s => s.Id == entidadId);

                        var asientoModificado = new {
                            number = asientoInhabilitado.Number,
                            rowNumber = asientoInhabilitado.Number,
                            roomName = asientoInhabilitado.RoomId,
                            status = asientoInhabilitado.Status
                        };

                        return asientoModificado ;

                    }
                 else
                 {
                        throw new Exception("El asiento especificado no existe.");
                 }
             }
             catch (Exception ex)
             {
                dbContextTransaction.Rollback();
                throw new Exception("Error al inhabilitar el asiento: " + ex.Message);
             }


        }


        public void Anular(int entidadId)
        {
            var bookingSeleccionado = db.Bookings.Where(c => c.Id == entidadId).FirstOrDefault();
            if (bookingSeleccionado == null)
                throw new NullReferenceException("Estas intentando anular una reservacion que no existe!");

            bookingSeleccionado.Status = false;
            db.Entry(bookingSeleccionado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }


        public void GuardarCambios()
        {
            db.SaveChanges();
        }

        public List<BookingEntity> Listar()
        {
            return db.Bookings.ToList();
        }

        public BookingEntity ListarPorID(int entidadId)
        {
            var bookingSeleccionado = db.Bookings.Where(c => c.Id==entidadId).FirstOrDefault();
            return bookingSeleccionado;
        }

        public IEnumerable<BookingEntity> ObtenerPeliculaPorFecha(string genre, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        
    }


}
