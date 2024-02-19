using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppButaca.dominio.Interfaces
{
    public interface IObtenerPeliculaPorFecha<String, DateTime>
    {
        IEnumerable<BookingEntity> ObtenerPeliculaPorFecha(String genre, DateTime startDate, DateTime endDate);

    }
}
