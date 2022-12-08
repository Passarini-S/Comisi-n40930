using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeGestion.Models;
using SistemaDeGestion.Repositories;

namespace SistemaDeGestion.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductoVendidoController : Controller
    {
        private ProductoVendidoRepository repository = new ProductoVendidoRepository();

        [HttpGet]
        public ActionResult<List<ProductoVendido>> Get()
        {
            try
            {
                List<ProductoVendido> lista = repository.listarProductoVendido();
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
