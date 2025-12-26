using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentBooking.Core.DTOs
{
    public class BookAppointmentRequest
    {
        [Required]
        public string CustomerName { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }
    }
}
