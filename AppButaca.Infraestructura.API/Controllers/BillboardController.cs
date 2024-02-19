using Microsoft.AspNetCore.Mvc;

using AppButaca.dominio;
using AppButaca.Aplicaciones;
using AppButaca.Infraestructura.Datos.Contextos;
using AppButaca.Infraestructura.Datos.Repositorios;
using AppButaca.Aplicaciones.Servicios;


namespace AppButaca.Infraestructura.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BillboardController : ControllerBase
    {

        BookingServicio crearServicioBooking()
        {
            ButacasContexto db = new ButacasContexto();
            BookingRepositorio repo = new BookingRepositorio(db);
            BookingServicio servicio = new BookingServicio(repo);
            return servicio;
        }

        BillboardServicio crearServicioBillboard()
        {
            ButacasContexto db = new ButacasContexto();
            BillboardRepositorio repo = new BillboardRepositorio(db);
            BillboardServicio servicio2 = new BillboardServicio(repo);
            return servicio2;
        }

        //=================================
        // ORDEN - 4 - b1
        //=================================
        [HttpGet("inhabilitar/{id}")]
        public ActionResult<IEnumerable<object>> InhabilitarAsientos(int id)
        {
            var servicio = crearServicioBooking(); 

            return Ok(servicio.Inhabilitar(id));

        }


        //=================================
        // ORDEN - 4 - b2
        //=================================
        [HttpGet("inhabilitar-cartelera/{id}")]
        public ActionResult<IEnumerable<object>> CancelarCartelera(int id)
        {

            var servicio = crearServicioBillboard();
            return Ok(servicio.CancelarCartelera(id));        

        }



        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        [HttpPost]
        public void Post([FromBody] string value)
        {
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
