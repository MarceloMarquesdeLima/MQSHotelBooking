﻿using Application.Booking.DTO;
using Application.Booking;
using Application;
using Application.Booking.Ports;
using Application.Payment;
using Microsoft.AspNetCore.Mvc;
using static Application.Booking.DTO.PaymentRequestDTO;


namespace ApiConsumer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingManager _bookingManager;
        private readonly ILogger<BookingController> _logger;

        public BookingController(IBookingManager bookingManager, ILogger<BookingController> logger)
        {
            _bookingManager = bookingManager;
            _logger = logger;
        }

        [HttpPost]
        [Route("{bookingId}/Pay")]
        public async Task<ActionResult<PaymentResponse>> Pay(
           PaymentRequestDto paymentRequestDTO, int bookingId)
        {
            paymentRequestDTO.BookingId = bookingId;
            var res = await _bookingManager.PayForABooking(paymentRequestDTO);

            if(res.Success) return Ok(res.Data);

            return BadRequest(res);
        }

        [HttpPost]
        public async Task<ActionResult<BookingResponse>> Post(BookingDTO booking)
        {
            var res = await _bookingManager.CreateBooking(booking);

            if (res.Success) return Created("", res.Data);

            else if (res.ErrorCode == ErrorCodes.BOOKING_MISSING_REQUIRED_INFORMATION)
            {
                return BadRequest(res);
            }
            else if (res.ErrorCode == ErrorCodes.BOOKING_COULD_NOT_STORE_DATA)
            {
                return BadRequest(res);
            }
            else if (res.ErrorCode == ErrorCodes.BOOKING_ROOM_CANNOT_BE_BOOKED)
            {
                return BadRequest(res);
            }

            _logger.LogError("Response with unknown ErrorCode Returned", res);
            return BadRequest(500);
        }
    }
}
