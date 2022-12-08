using Microsoft.AspNetCore.Http;
using SistemaDeGestion.Models;
using SistemaDeGestion.Repositories;
//using Microsoft.A;
using Microsoft.AspNetCore.Mvc;

namespace SistemaDeGestion.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductosController : Controller
    {
        private ProductosRepository repository = new ProductosRepository();

        [HttpGet]
        public ActionResult<List<Producto>> Get()
        {
            try
            {
                List<Producto> lista = repository.listarProductos();
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
