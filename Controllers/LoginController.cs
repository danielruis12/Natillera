using Natillera.Clases;
using Natillera.Models;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Natillera.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/login")]
    // [AllowAnonymous]: Directiva para que el servicio no requiera de autenticación.
    // [Authorize]: Directiva para que el servicio necesite de autenticación y un token para que se pueda procesar.
    [AllowAnonymous]
    public class LoginController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("Ingresar")]
        public IQueryable<LoginRespuesta> Ingresar([FromBody] Login login)
        {
            clsLogin _login = new clsLogin();
            _login.login = login;
            return _login.Ingresar();
        }
    }
}