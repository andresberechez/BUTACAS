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
    public class MovieRepositorio : IRepositorioBase<MovieEntity, int>
    {
        public MovieEntity Agregar(MovieEntity entidad)
        {
            throw new NotImplementedException();
        }

        public void Editar(MovieEntity tentidad)
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

        public List<MovieEntity> Listar()
        {
            throw new NotImplementedException();
        }

        public MovieEntity ListarPorID(int entidadId)
        {
            throw new NotImplementedException();
        }

        //public ListMovieFotType(String movie, )

    }
}
