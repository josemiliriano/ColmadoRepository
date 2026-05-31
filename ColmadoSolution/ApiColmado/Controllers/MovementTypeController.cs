using ApiColmado.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiColmado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovementTypeController : ControllerBase
    {
        private static List<MovementType> _movement = new List<MovementType>
        {
            new MovementType{IdMovementType=1,Description="Ventas"},
            new MovementType{IdMovementType=2,Description="Compras"}
        };
        [HttpGet]
        public ActionResult<MovementType> GetAll()
        {
            return Ok(_movement);
        }
    }
}
