using AppButaca.dominio;
using AppButaca.dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppButaca.Aplicaciones.Servicios
{
    public class BillboardServicio : IRepositorioBase<BillboardEntity, int>, IRepositorioBillboardTransaction<int>
    {

        private readonly IRepositorioBillboardTransaction<int> repoBooking;

        public BillboardServicio(IRepositorioBillboardTransaction<int> _repoBooking)
        {
            repoBooking = _repoBooking;
        }


        public IEnumerable<object> CancelarCartelera(int id)
        {

            var clientesAfectados = repoBooking.CancelarCartelera(id);

            return clientesAfectados;

        }

        public BillboardEntity Agregar(BillboardEntity entidad)
        {
            throw new NotImplementedException();
        }

        

        public void Editar(BillboardEntity tentidad)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(int entidadId)
        {
            throw new NotImplementedException();
        }

        public void GuardarCambios()
        {
            throw new NotImplementedException();
        }

        public List<BillboardEntity> Listar()
        {
            throw new NotImplementedException();
        }

        public BillboardEntity ListarPorID(int entidadId)
        {
            throw new NotImplementedException();
        }
    }
}
