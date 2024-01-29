using System.ComponentModel.DataAnnotations;

namespace Shared.Models {
    public class InventoryRecord
    {
        public InventoryRecord(){}
        public InventoryRecord(int RecordId, int ProductId, int WarehouseId, int Quantity)
        {
            this.RecordId = RecordId;
            this.ProductId = ProductId;
            this.WarehouseId = WarehouseId;
            this.Quantity = Quantity;
        }

        [Key]
        public int RecordId { get; set; }
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public int Quantity { get; set; }

        public void Deconstruct(out int RecordId, out int ProductId, out int WarehouseId, out int Quantity)
        {
            RecordId = this.RecordId;
            ProductId = this.ProductId;
            WarehouseId = this.WarehouseId;
            Quantity = this.Quantity;
        }
    }
}
