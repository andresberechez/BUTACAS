using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppButaca.dominio;
using AppButaca.dominio.Interfaces.Repositorios;
using AppButaca.Infraestructura.Datos.Contextos;


namespace AppButaca.Infraestructura.Datos.Repositorios
{
    public class BaseRepositorio : IRepositorioBase<BaseEntity, Guid>  {


        private ButacasContexto db;

        public BaseRepositorio(ButacasContexto _db)
        {
            db = _db;
        }


        public BaseEntity Agregar(BaseEntity entidad)
        {
            throw new NotImplementedException();
        }

        public void Editar(BaseEntity tentidad)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(Guid entidadId)
        {
            throw new NotImplementedException();
        }

        public void GuardarCambios()
        {
            throw new NotImplementedException();
        }

        public List<BaseEntity> Listar()
        {
            throw new NotImplementedException();
        }

        public BaseEntity ListarPorID(Guid entidadId)
        {
            throw new NotImplementedException();
        }
    }

}
