using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FieldEngineerApi.Models
{
    public class Order {
        [Key]
        public long Id { get; set; }
        public long BoilerPartId { get; set; }
        public virtual BoilerPart BoilerPart { get; set; }
        public string BoilerPartName { get; set; }
        public long quantity { get; set; }
        [Column(TypeName = "money")]
        public decimal ItemPrice { get; set; }
        [Column(TypeName = "money")]
        public decimal TotalPrice { get; set; }
    }
}