using System.ComponentModel.DataAnnotations.Schema;

namespace FieldEngineerApi.Models
{
    public class BoilerPart
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long ContainedInId { get; set; }
        public string Category { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public string Overview { get; set; }
    }
}