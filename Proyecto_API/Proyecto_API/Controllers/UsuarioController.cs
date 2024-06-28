using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Dapper;
using Proyecto_API.Emtities;


namespace Proyecto_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {


        [HttpPost]
        [Route("RegistrarUsuario")]
        public IActionResult RegistrarUsuario(Usuario ent)
        {
            using (var context = new SqlConnection("Server=DESKTOP-RAP4D7R;Database=Proyecto_Web;Trusted_Connection=True;TrustServerCertificate=True"))
            {
                var result = context.Execute("RegistrarUsuario",
                    new {ent.nombre, ent.correo, ent.contrasenna },
                    commandType: System.Data.CommandType.StoredProcedure );
            }

            return Ok("Todo bien");
        }
    }
}
