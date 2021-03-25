using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FieldEngineerApi.Models
{
    public class AppointmentStatus {
        [Key]
        public long Id { get; set; }
        public string StatusName { get; set; }

        public List<Appointment> Appointments { get; set; }
    }

}