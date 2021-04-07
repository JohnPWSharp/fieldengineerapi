using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FieldEngineerApi.Models
{
    public class AppointmentStatus {
        [Key]
        public long Id { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
