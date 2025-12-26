using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentBooking.Core.DTOs
{
    public class BookAppointmentResponse
    {
        public string CustomerName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int TokenNumber { get; set; }
    }
}
