using System;
using System.ComponentModel.DataAnnotations;

namespace FieldEngineerApi.Models
{

    public class Appointment
    {
        public long Id { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string CustomerAddress { get; set; }
        public string ProblemDetails { get; set; }
        public string ContactNumber { get; set; }
        [Required]
        public string Status { get; set; }

        [Display(Name = "StartTime")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy H:mm:ss}")]
        public DateTime StartDateTime { get; set; }
        public string Notes { get; set; }
    }

}