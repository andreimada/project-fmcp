using System.ComponentModel.DataAnnotations;

namespace Shared.Models {
    public class Product
    {
        public Product(){}
        public Product(int ProductId, string Name, string Description)
        {
            this.ProductId = ProductId;
            this.Name = Name;
            this.Description = Description;
        }

        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public void Deconstruct(out int ProductId, out string Name, out string Description)
        {
            ProductId = this.ProductId;
            Name = this.Name;
            Description = this.Description;
        }
    }
}
