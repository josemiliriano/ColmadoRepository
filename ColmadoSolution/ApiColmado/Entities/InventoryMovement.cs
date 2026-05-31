namespace ApiColmado.Entities
{
    public class InventoryMovement
    {
        public int IdInventoryMovement { get; set; }
        
        public int IdProduct { get; set; }
        
        public string MovementTypediD { get; set; }
        
        public int Quantity { get; set; }
        
        public DateTime MovementDate { get; set; }
        
        public string? Description { get; set; }
        
        public int? IdSupplier { get; set; }

        public char IsDelete { get; set; } = '0';
    }
}
