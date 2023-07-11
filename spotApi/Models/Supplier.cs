using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace spotApi.Models
{
    public class Supplier
    {
        public int supplier_id{ get; set; }
       [Required]
       [StringLength(50)]
       public string supplier_name { get; set; }
        public string supplier_description { get; set; }
        public string phone { get; set; }

    }
}
