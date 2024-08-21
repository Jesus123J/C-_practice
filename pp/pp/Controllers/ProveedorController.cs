using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using pp.Repositorio;

namespace pp.Controllers
{

        [Route("api/[controller]")]
        [ApiController]
    public class ProveedorController : Controller
    {
        private readonly ProveedorImpl _proveedorImpl;

        public ProveedorController(ProveedorImpl proveedorImpl)
        {
            _proveedorImpl = proveedorImpl;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProveedor()
        {
            try
            {
                var proveedores = await _proveedorImpl.GetProveedors();
                return Ok(proveedores);
            }
            catch (InvalidOperationException ex)
            {
                // Puedes registrar el error aquí si es necesario
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
            catch (Exception ex)
            {
                // Manejo genérico de excepciones
                // Puedes registrar el error aquí si es necesario
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message});
            }
        }

        [HttpGet("test-connection")]
        public async Task<IActionResult> TestConnection()
        {
            bool isConnected = await _proveedorImpl.TestConnectionAsync();
            if (isConnected)
            {
                return Ok(new { message = "Conexión exitosa con la base de datos." });
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "No se pudo conectar a la base de datos." });
            }
        }
    }


}
