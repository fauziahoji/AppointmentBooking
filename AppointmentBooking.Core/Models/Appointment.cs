using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentBooking.Core.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int TokenNumber { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
