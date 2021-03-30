using System.ComponentModel.DataAnnotations; 
using System.Collections.Generic; 

namespace FieldEngineerApi.Models 
{ 
    public class ScheduleEngineer 
    { 
        [Key] 
        public string Id { get; set; } 
        [Required] 
        public string Name { get; set; } 
        public string ContactNumber { get; set; } 
        public virtual ICollection<Appointment> Appointments { get; set; } 
    } 
}