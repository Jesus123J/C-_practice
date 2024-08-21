using Microsoft.AspNetCore.Mvc;
using ProyectoStore.data.Repositorio;

namespace ProyectStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {

       private  readonly ProveedorImpl _proveedorImpl;

        public HomeController(ProveedorImpl proveedorImpl)
        {
           _proveedorImpl = proveedorImpl;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProveedor()
        {
            return Ok(await _proveedorImpl.GetProveedors());
        }
    }
}
