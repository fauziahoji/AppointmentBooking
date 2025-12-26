using AppointmentBooking.Core.Models;
using AppointmentBooking.Core.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentBooking.Core.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private const int MaxAppointmentsPerDay = 10;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public Appointment BookAppointment(string customerName, DateTime requestedDate)
        {
            var date = requestedDate.Date;

            while (true)
            {
                var count = _appointmentRepository.CountAppointmentByDate(date);

                if (count < MaxAppointmentsPerDay)
                {
                    var app = new Appointment
                    {
                        CustomerName = customerName,
                        AppointmentDate = date,
                        CreatedAt = DateTime.Now,
                        TokenNumber = count + 1
                    };

                    _appointmentRepository.AddAppointment(app);
                    return app;
                }

                date = date.AddDays(1);
            }
        }

        public IEnumerable<Appointment> GetAppointmentsForDate(DateTime date)
        {
            return _appointmentRepository.GetAppointmentByDate(date);
        }
    }
}
