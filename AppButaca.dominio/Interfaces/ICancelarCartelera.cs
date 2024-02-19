using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppButaca.dominio.Interfaces
{
    public interface ICancelarCartelera<TEntidadID>
    {
        IEnumerable<object> CancelarCartelera(TEntidadID id);

    }
}
