﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppButaca.dominio.Interfaces
{
    public interface IAgregar<TEntidad> 
    {
        TEntidad Agregar(TEntidad entidad);
    }
}
