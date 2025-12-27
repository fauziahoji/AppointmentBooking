# Appointment Booking API

This project is a simple Web API for booking customer appointments and issuing daily queue tokens.
It was built as a take-home assignment with a focus on clean design, clarity, and correctness rather than feature completeness.

---

## What the system does

- Allows an agency to book appointments for customers
- Automatically assigns a queue token for each booking
- Provides a daily view of the appointment queue, ordered by token number
- Enforces a maximum number of appointments per day
- Automatically moves bookings to the next available day if the current day is full

The API intentionally exposes only the endpoints required by the problem statement.

---

## Architecture

The solution is split into multiple projects to separate concerns clearly:

AppointmentBooking.Api Web API layer (controllers, Swagger)
AppointmentBooking.Core Domain logic, entities, and interfaces
AppointmentBooking.Infrastructure Data access (EF Core, repositories)
AppointmentBooking.Tests Unit tests (MSTest)

Business rules live in the Core layer and are tested independently of the database or web framework.

---

## API Endpoints

POST /api/appointments


Request body:
```json
{
  "customerName": "Budi",
  "appointmentDate": "2025-12-26"
}


Response:

{
  "customerName": "Budi",
  "appointmentDate": "2025-12-26",
  "tokenNumber": 1
}


