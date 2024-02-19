using AppButaca.dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppButaca.Aplicaciones.Interfaces
{
    internal interface IServicioBillboardTransaction<TEntidadID> : ICancelarCartelera<TEntidadID>
    {
    }
}
