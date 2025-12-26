using AppointmentBooking.Core.Models;
using AppointmentBooking.Core.Services.Interface;
using AppointmentBooking.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentBooking.Infra.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppDbContext appDbContext;

        public AppointmentRepository(AppDbContext appDbContext)
        {
            appDbContext = appDbContext;
        }

        public void AddAppointment(Appointment appointment)
        {
            appDbContext.Add(appointment);
            appDbContext.SaveChanges();
        }

        public int CountAppointmentByDate(DateTime date)
        {
            return appDbContext.appointmentsEntity
                .Count(a => a.AppointmentDate.Date == date.Date);
        }

        public IEnumerable<Appointment> GetAppointmentByDate(DateTime date)
        {
            return appDbContext.appointmentsEntity
                .Where(a => a.AppointmentDate == date.Date)
                .OrderBy(a => a.TokenNumber)
                .ToList();
        }
    }
}
