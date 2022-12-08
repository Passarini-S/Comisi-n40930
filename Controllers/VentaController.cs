using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeGestion.Models;
using SistemaDeGestion.Repositories;

namespace SistemaDeGestion.Controllers
{
        [ApiController]
        [Route("api/v1/[controller]")]
        public class VentaController : Controller
        {
            private VentaRepository repository = new VentaRepository();

            [HttpGet]
            public ActionResult<List<Venta>> Get()
            {
                try
                {
                    List<Venta> lista = repository.listarVenta();
                    return Ok(lista);
                }
                catch (Exception ex)
                {
                    return Problem(ex.Message);
                }
            }

            /*
            [HttpPost]
            public IActionResult Post()
            {
                return Ok();
            }
            */
        }
    
}
