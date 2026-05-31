using ApiColmado.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiColmado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryMovementController : ControllerBase
    {
        private static List<InventoryMovement> _movement = new List<InventoryMovement>
        {
            new InventoryMovement{ IdInventoryMovement=1,IdProduct=1,MovementTypediD=1,Quantity=3,Description="Venta de mercancia"},
            new InventoryMovement{ IdInventoryMovement=2,IdProduct=1,MovementTypediD=2,Quantity=45,Description="Compra de mercancia",ProviderId=2}
        };
        [HttpGet("Compras")]
        public ActionResult<IEnumerable<InventoryMovement>> GetAllBuys()
        {
            return Ok(_movement.FirstOrDefault(m => m.MovementTypediD == 2));
        }
        [HttpGet("Ventas")]
        public ActionResult<IEnumerable<InventoryMovement>> GetAllSales()
        {
            return Ok(_movement.FirstOrDefault(m => m.MovementTypediD == 1));
        }
        [HttpGet("VentasById")]
        public ActionResult<IEnumerable<InventoryMovement>> GetAllBuysById(int id)
        {
            return Ok(_movement.FirstOrDefault(m => m.MovementTypediD == 1 && m.IdInventoryMovement == id));
        }
        [HttpGet("ComprasById")]
        public ActionResult<IEnumerable<InventoryMovement>> GetAllSalesById(int id)
        {
            return Ok(_movement.FirstOrDefault(m => m.MovementTypediD == 2 && m.IdInventoryMovement==id));
        }

        [HttpPost("Ventas")]
        public ActionResult<InventoryMovement> CreateSale(InventoryMovement sale)
        {
            if (sale.MovementTypediD != 1 && sale.MovementTypediD != 2)
            {
                return BadRequest("El tipo de movimiento no es válido. Debe ser 1 para la Venta o 2 para la Compra.");
            }
            var newId = _movement.Any() ? _movement.Max(m => sale.IdInventoryMovement) + 1 : 1;
            sale.IdInventoryMovement = newId;
            sale.MovementTypediD = 1;
            _movement.Add(sale);

            return CreatedAtAction(
                nameof(GetAllSalesById),
                new { id = sale.IdInventoryMovement },
                sale);
        }
        [HttpPost("Compras")]
        public ActionResult<InventoryMovement> CreateBuy(InventoryMovement Buy)
        {
            if (Buy.MovementTypediD != 1 && Buy.MovementTypediD != 2)
            {
                return BadRequest("El tipo de movimiento no es válido. Debe ser 1 para la Venta o 2 para la Compra.");
            }
            var newId = _movement.Any() ? _movement.Max(m => Buy.IdInventoryMovement) + 1 : 1;
            Buy.IdInventoryMovement = newId;
            Buy.MovementTypediD = 2;
            _movement.Add(Buy);

            return CreatedAtAction(
                nameof(GetAllSalesById),
                new { id = Buy.IdInventoryMovement },
                Buy);
        }
        [HttpPut]
        public ActionResult<InventoryMovement> Update(int id, InventoryMovement movement)
        {
            var existingMovement = _movement.FirstOrDefault(m => movement.IdInventoryMovement == id);
            if (existingMovement == null)
            {
                return NotFound($"El id {id} no existe en la lista");
            }
            existingMovement.Quantity = movement.Quantity;
            existingMovement.Description = movement.Description;
            return Ok(existingMovement);

        }
    }
}

