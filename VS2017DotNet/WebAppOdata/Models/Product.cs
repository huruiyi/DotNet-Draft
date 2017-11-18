using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppOdata.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

        [Column("desc")]
        public string Description { get; set; }

        [ForeignKey("Supplier")]
        public int? SupplierId { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}