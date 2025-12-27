using AppointmentBooking.Core.Models;
using AppointmentBooking.Core.Services;
using AppointmentBooking.Core.Services.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;


namespace AppointmentBooking.Test
{
    [TestClass]
    public class AppointmentServiceTest
    {
        private Mock<IAppointmentRepository> _repoMock;
        private AppointmentService _service;

        [TestInitialize]
        public void Setup()
        {
            _repoMock = new Mock<IAppointmentRepository>();
            _service = new AppointmentService(_repoMock.Object);
        }

        [TestMethod]
        public void BookAppointment_ShouldGenerateToken_WhenSlotAvailable()
        {
            // Arrange
            var date = new DateTime(2025, 12, 26);

            _repoMock
                .Setup(r => r.CountAppointmentByDate(date))
                .Returns(0);

            // Act
            var result = _service.BookAppointment("XX", date);

            // Assert
            Assert.AreEqual(1, result.TokenNumber);
            Assert.AreEqual(date, result.AppointmentDate);

            _repoMock.Verify(
                r => r.AddAppointment(It.IsAny<Appointment>()),
                Times.Once);
        }

        [TestMethod]
        public void BookAppointment_ShouldMoveToNextDay_WhenDayIsFull()
        {
            // Arrange
            var date = new DateTime(2025, 12, 26);

            _repoMock.Setup(r => r.CountAppointmentByDate(date))
                .Returns(10);

            _repoMock.Setup(r => r.CountAppointmentByDate(date.AddDays(1)))
                .Returns(0);

            // Act
            var result = _service.BookAppointment("XX", date);

            // Assert
            Assert.AreEqual(date.AddDays(1), result.AppointmentDate);
            Assert.AreEqual(1, result.TokenNumber);
        }
    }
}
