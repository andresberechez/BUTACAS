using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppButaca.dominio.Interfaces;

namespace AppButaca.dominio.Interfaces.Repositorios
{
    public interface IRepositorioMovimiento<TEntidad, TEntidadID, String, DateTime>
        : IAgregar<TEntidad>, IListar<TEntidad, TEntidadID>, ITransaccion, IObtenerPeliculaPorFecha<String, DateTime>, IObtenerButacasPorDisponibilidad, IInhabilitar<TEntidadID>
    {
        void Anular(TEntidadID entidadId);
    }
}