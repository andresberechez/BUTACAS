using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppButaca.dominio;
using AppButaca.dominio.Interfaces.Repositorios;
using AppButaca.Aplicaciones.Interfaces;
using AppButaca.dominio.Interfaces;

namespace AppButaca.Aplicaciones.Servicios
{
    public class BookingServicio : IRepositorioMovimiento<BookingEntity, int, String, DateTime>
    {

        private readonly IRepositorioMovimiento<BookingEntity, int, String, DateTime> repoBooking;

        public BookingServicio(IRepositorioMovimiento<BookingEntity, int, String, DateTime> _repoBooking)
        {
            repoBooking = _repoBooking;
        }


        public BookingEntity Agregar(BookingEntity entidad)
        {

            if (entidad == null)
                throw new ArgumentNullException("La reserva booking es requerdia");

            var bookingAgregado = repoBooking.Agregar(entidad);

            repoBooking.GuardarCambios();
            return entidad;
            
        }


        public IEnumerable<BookingEntity> ObtenerPeliculaPorFecha(String genre, DateTime startDate, DateTime endDate)
        {
            var bookingsObtenidos = repoBooking.ObtenerPeliculaPorFecha(genre, startDate, endDate);

            return bookingsObtenidos;
        }




        public IEnumerable<object> ObtenerButacasPorDisponibilidad()
        {
            var seatsObtenidos = repoBooking.ObtenerButacasPorDisponibilidad();

            return seatsObtenidos;

        }



        public object Inhabilitar(int entidadId)
        {
            var seatsInhabilitados = repoBooking.Inhabilitar(entidadId);

            return seatsInhabilitados;

        }



        public void Anular(int entidadId)
        {
            throw new NotImplementedException();
        }

        public void GuardarCambios()
        {
            throw new NotImplementedException();
        }

        public List<BookingEntity> Listar()
        {
            //return List<MovieGenreEnum>;
            return repoBooking.Listar();
        }

        public BookingEntity ListarPorID(int entidadId)
        {
            throw new NotImplementedException();
        }

        
    }

}
