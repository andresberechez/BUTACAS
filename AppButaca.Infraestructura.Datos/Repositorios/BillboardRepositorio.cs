using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Linq;
using AppButaca.dominio;
using AppButaca.dominio.Interfaces.Repositorios;
using AppButaca.Infraestructura.Datos.Contextos;



namespace AppButaca.Infraestructura.Datos.Repositorios
{
    public class BillboardRepositorio : IRepositorioBase<BillboardEntity, int> , IRepositorioBillboardTransaction<int>
    {

        private ButacasContexto db;


        public BillboardRepositorio(ButacasContexto _db)
        {
            db = _db;
        }

        public IEnumerable<object> CancelarCartelera(int id)
        {
            //b.Implementar el método con transaccionalidad para cancelar la cartelera y cancelar todas las reservas de la sala,
            ///adicional se debe habilitar las butacas e imprimir por consola la lista de clientes que fueron afectados.
            ///
            using (var dbContextTransaction = db.Database.BeginTransaction())

                try

                {
                    var cartelera = db.Seats.Find(id);

                    if (cartelera != null)
                    {
                        //Pone false a la cartelera
                        cartelera.Status = false;


                        //recupera reservas con id obtenido 
                        var reservasSala = db.Bookings.Where(b => b.BillboardId == cartelera.Id).ToList();
                        
                        
                        db.SaveChanges();
                        dbContextTransaction.Commit();


                        var result = new
                        {
                            reservas = reservasSala,
                            clientesAfectados = reservasSala //probando
                        };


                        return new List<object> { result };

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


            throw new NotImplementedException();
        }


        public BillboardEntity Agregar(BillboardEntity entidad)
        {

            db.Billboards.Add(entidad);
            db.SaveChanges();
            return entidad;

        }


        public void Editar(BillboardEntity tentidad)
        {

            var billboardSeleccionado = db.Billboards.Where(c => c.Id == tentidad.Id).FirstOrDefault();
            if (billboardSeleccionado != null)
            {
                billboardSeleccionado.StartTime = tentidad.StartTime;
                billboardSeleccionado.EndTime = tentidad.EndTime;
                billboardSeleccionado.Status = tentidad.Status;
                billboardSeleccionado.Date = tentidad.Date;
                billboardSeleccionado.Movie = tentidad.Movie;
                billboardSeleccionado.MovieId = tentidad.MovieId;
                billboardSeleccionado.Room = tentidad.Room;
                billboardSeleccionado.RoomId = tentidad.RoomId;

                db.Entry(billboardSeleccionado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }

        }

        public void Eliminar(int entidadId)
        {
            var billboardSeleccionado = db.Billboards.Where(c => c.Id == entidadId).FirstOrDefault();
            if (billboardSeleccionado != null)
            {
              db.Billboards.Remove(billboardSeleccionado);
            }

        }

        public void GuardarCambios()
        {
            db.SaveChanges();
            throw new NotImplementedException();
        }

        public List<BillboardEntity> Listar()
        {
            return db.Billboards.ToList();
        }

        public BillboardEntity ListarPorID(int entidadId)
        {
            var billboardSeleccionado = db.Billboards.Where(c => c.Id == entidadId).FirstOrDefault();
            return billboardSeleccionado;
        }



    }
}
