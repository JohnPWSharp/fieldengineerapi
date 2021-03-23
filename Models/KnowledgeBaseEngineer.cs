using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FieldEngineerApi.Models
{

    public class KnowledgeBaseEngineer
    {
        [Key]
        public Guid guid { get; set; }
        [Required]
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public virtual ICollection<KnowledgeBaseTip> KnowledgeBaseTips { get; set; }
    }

}