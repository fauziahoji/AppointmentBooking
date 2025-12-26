using AppointmentBooking.Core.DTOs;
using AppointmentBooking.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentBooking.Core.Mapping
{
    public static class AppointmentMapping
    {
        public static BookAppointmentResponse ToBookAppointmentResponse(this Appointment appointment)
        {
            return new BookAppointmentResponse
            {
                AppointmentDate = appointment.AppointmentDate,
                CustomerName = appointment.CustomerName,
                TokenNumber = appointment.TokenNumber
            };
        }
    }
}
