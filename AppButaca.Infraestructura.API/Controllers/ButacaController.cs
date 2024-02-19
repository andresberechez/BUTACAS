using Microsoft.AspNetCore.Mvc;

using AppButaca.dominio;
using AppButaca.Aplicaciones;
using AppButaca.Infraestructura.Datos.Contextos;
using AppButaca.Infraestructura.Datos.Repositorios;
using AppButaca.Aplicaciones.Servicios;


namespace AppButaca.Infraestructura.API.Controllers
{
    //=================================
    // ORDEN - 4 - a
    //=================================
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ButacaController : ControllerBase {

        BookingServicio crearServicio()
        {
            ButacasContexto db = new ButacasContexto();
            BookingRepositorio repo = new BookingRepositorio(db);
            BookingServicio servicio = new BookingServicio(repo);
            return servicio;
        }

        [HttpGet]
        public ActionResult<List<BillboardEntity>> Get()
        {
            var servicio = crearServicio();
            return Ok(servicio.Listar());
        }


        [HttpGet("{id}")]
        public ActionResult<BookingEntity> Get(int id)
        {
            var servicio = crearServicio();
            return Ok(servicio.ListarPorID(id));
        }

        //=================================
        // ORDEN - 4 - d
        //=================================
        [HttpGet("{genre}/{startDate}/{endDate}")]
        public ActionResult<IEnumerable<BookingEntity>> GetBookingsByGenreAndDateRange(
            string genre,
            DateTime startDate,
            DateTime endDate)
        {
            var servicio = crearServicio();

            return Ok(servicio.ObtenerPeliculaPorFecha(genre, startDate, endDate));
        }

        //=================================
        // ORDEN - 4 - e
        //=================================
        [HttpGet("disponibilidad")]
        public ActionResult<IEnumerable<object>> ObtenerButacasPorDisponibilidad()
        {
            var servicio = crearServicio();

            return Ok(servicio.ObtenerButacasPorDisponibilidad());
        }


        [HttpPost]
        public ActionResult Post([FromBody] BookingEntity booking)
        {
            var servicio = crearServicio();
            servicio.Agregar(booking);
            return Ok("Agregado el producto!!" +booking);
        }



        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }


    }


}
