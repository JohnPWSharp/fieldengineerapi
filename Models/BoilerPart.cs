using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FieldEngineerApi.Models
{
    public class BoilerPart
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        //public long? ContainedInId { get; set; }
        //[ForeignKey(nameof(ContainedInId))]
        //[InverseProperty(nameof(Contains))]
        //public virtual BoilerPart ContainedIn { get; set; }
        //[ForeignKey(nameof(ContainedInId))]
        //public virtual ICollection<BoilerPart> Contains { get; set; }
        public string CategoryId { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public string Overview { get; set; }
        public int NumberInStock { get; set; }
        public string ImageUrl { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}