using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace spotApi.Models
{
    [Table("TblUser")]
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }

        public decimal price { get; set; }
        public int supplier_id { get; set; }
        [Required]
        public string description { get; set; }
        public List<Tag> Tags { get; set; }
        public Supplier Suppliers { get; set; }
    }

}
