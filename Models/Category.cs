using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FieldEngineerApi.Models
{

    public class Category {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BoilerPart> BoilerParts { get; set; }
    }

}