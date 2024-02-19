using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppButaca.dominio;
using AppButaca.dominio.Interfaces.Repositorios;
using AppButaca.Aplicaciones.Interfaces;


namespace AppButaca.Aplicaciones.Servicios
{
    public class MovieServicio : IServicioBase<MovieEntity, Guid>
    {

        private readonly IRepositorioBase<MovieEntity, Guid> repoProducto;


        public MovieServicio(IRepositorioBase<MovieEntity, Guid> _repoProducto) 
        { 
            repoProducto = _repoProducto;
        }


        //============================================
        //        Implementación de IServicioBase
        //============================================
        public MovieEntity Agregar(MovieEntity entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("La 'Película' es requerida");
            
            var resultMovie = repoProducto.Agregar(entidad);
            repoProducto.GuardarCambios();
            return resultMovie;

        }


        public void Editar(MovieEntity entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("La 'Pelicula' es requerida para editar");

            repoProducto.Editar(entidad);
            repoProducto.GuardarCambios();
        }


        public void Eliminar(Guid entidadId)
        {
            repoProducto.Eliminar(entidadId);
            repoProducto.GuardarCambios() ;
        }


        public List<MovieEntity> Listar()
        {
            return repoProducto.Listar();
        }


        public MovieEntity ListarPorID(Guid entidadId)
        {
            return repoProducto.ListarPorID(entidadId);
        }

    }

}
