using System;
using System.ComponentModel.DataAnnotations;

namespace FieldEngineerApi.Models
{
    public class KnowledgeBaseTip {
        [Key]
        public long Id { get; set; }
        public long KnowledgeBaseBoilerPartId { get; set; }
        public KnowledgeBaseBoilerPart KnowledgeBaseBoilerPart { get; set; }
        public Guid KnowledgeBaseEngineerGuid { get; set; }
        public KnowledgeBaseEngineer KnowledgeBaseEngineer { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }

}