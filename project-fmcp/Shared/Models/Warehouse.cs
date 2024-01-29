using System.ComponentModel.DataAnnotations;

namespace Shared.Models {
    public class Warehouse
    {
        public Warehouse(){}
        public Warehouse(int WarehouseId, string Location, int Capacity)
        {
            this.WarehouseId = WarehouseId;
            this.Location = Location;
            this.Capacity = Capacity;
        }

        [Key]
        public int WarehouseId { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }

        public void Deconstruct(out int WarehouseId, out string Location, out int Capacity)
        {
            WarehouseId = this.WarehouseId;
            Location = this.Location;
            Capacity = this.Capacity;
        }
    }
}
