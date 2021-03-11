using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FieldEngineerApi.Models
{
    public class KnowledgeBaseBoilerPart
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
        public string Overview { get; set; }
        public virtual ICollection<KnowledgeBaseTip> KnowledgeBaseTips { get; set; }
    }
}