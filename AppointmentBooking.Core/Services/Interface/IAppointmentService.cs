using AppointmentBooking.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentBooking.Core.Services.Interface
{
    public interface IAppointmentService
    {
        Appointment BookAppointment(string customerName, DateTime requestedDate);
        IEnumerable<Appointment> GetAppointmentsForDate(DateTime date);
    }
}
