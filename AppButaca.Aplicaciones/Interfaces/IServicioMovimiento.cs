using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppButaca.dominio.Interfaces;

namespace AppButaca.Aplicaciones.Interfaces
{
    public interface IServicioMovimiento<TEntidad, TEntidadID, String, DateTime>
        : IAgregar<TEntidad>, IListar<TEntidad, TEntidadID>, IObtenerPeliculaPorFecha<String, DateTime>, IObtenerButacasPorDisponibilidad, IInhabilitar<TEntidadID>
    {
        void Anular(TEntidadID entidadId);
    }
}
