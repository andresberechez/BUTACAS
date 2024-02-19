using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppButaca.dominio.Interfaces;

namespace AppButaca.dominio.Interfaces.Repositorios
{
    public interface IRepositorioBase<TEntidad, TEntidadID>
        : IAgregar<TEntidad>, IEditar<TEntidad>, 
          IEliminar<TEntidadID>, IListar<TEntidad, TEntidadID>,
          ITransaccion
    {

    }

}
