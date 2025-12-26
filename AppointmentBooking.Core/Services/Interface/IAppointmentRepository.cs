using AppointmentBooking.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentBooking.Core.Services.Interface
{
    public interface IAppointmentRepository
    {
        void AddAppointment(Appointment appointment);
        int CountAppointmentByDate(DateTime date);
        IEnumerable<Appointment> GetAppointmentByDate(DateTime date);
    }
}
