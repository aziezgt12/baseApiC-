using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace spotApi.Models
{
    [Table("TblUser")]
    public class Tag
    {
        public int tag_id{ get; set; }
        public int product_id{ get; set; }

        public string tag{ get; set; }

    }
}
