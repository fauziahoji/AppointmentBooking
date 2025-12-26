using AppointmentBooking.Core.DTOs;
using AppointmentBooking.Core.Mapping;
using AppointmentBooking.Core.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        ///<summary>
        ///Book appointments and generate token
        /// </summary>
        [HttpPost]
        public IActionResult BookAppointment([FromBody] BookAppointmentRequest request)
        {
            var appointment = _appointmentService.BookAppointment(
                request.CustomerName,
                request.AppointmentDate
            );

            return Ok(appointment.ToBookAppointmentResponse());
        }

        /// <summary>
        /// Get appointment queue for a specific date
        /// </summary>
        [HttpGet]
        public IActionResult GetAppointments([FromQuery] DateTime date)
        {
            var appointments = _appointmentService.GetAppointmentsForDate(date);
            return Ok(appointments);
        }
    }
}
