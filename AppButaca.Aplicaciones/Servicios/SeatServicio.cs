using AppButaca.dominio.Interfaces.Repositorios;
using AppButaca.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppButaca.Aplicaciones.Servicios
{
    internal class SeatServicio : IRepositorioSeatTransaction<SeatEntity>
    {
        private readonly IRepositorioSeatTransaction<SeatEntity> repoBooking;

        public SeatServicio(IRepositorioSeatTransaction<SeatEntity> _repoBooking)
        {
            repoBooking = _repoBooking;
        }


        public object Inhabilitar(SeatEntity entidadId)
        {
            var seatsInhabilitados = repoBooking.Inhabilitar(entidadId);

            return seatsInhabilitados;
        }


    }


}
