using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppButaca.dominio.Interfaces;

namespace AppButaca.Aplicaciones.Interfaces
{
    public interface IServicioBase<TEntidad, TEntidadID>
        : IAgregar<TEntidad>, IEditar<TEntidad>,
          IEliminar<TEntidadID>, IListar<TEntidad,TEntidadID>
    {
    }
}
