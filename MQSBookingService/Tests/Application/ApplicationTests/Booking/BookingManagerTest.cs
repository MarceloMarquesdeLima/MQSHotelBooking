using Application.Booking;
using Application.Guest;
using Application.Payment;
using Application.Payment.DTOS;
using Application.Payment.Ports;
using Domain.Enums;
using Domain.Ports;
using Moq;
using NUnit.Framework;
using static Application.Booking.DTO.PaymentRequestDTO;

namespace ApplicationTests.Booking
{
    public class BookingManagerTest
    {
        GuestManager guestManager;

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async Task Should_PayForABooking()
        {
            var dto = new PaymentRequestDto
            {
                SelectedPaymentProvider = SupportedPaymentProviders.MercadoPago,
                PaymentIntention = "https://www.mercadopago.com.br/asdf",
                SelectedPaymentMethod = SupportedPaymentMethods.CreditCard
            };

            var bookingRepository = new Mock<IBookingRepository>();
            var roomRepository = new Mock<IRoomRepository>();
            var guestRepository = new Mock<IGuestRepository>();
            var paymentProcessorFactory = new Mock<IPaymentProcessorFactory>();
            var paymentProcessor = new Mock<IPaymentProcessor>();

            var responseDto = new PaymentStateDTO
            {
                CreatedDate = DateTime.Now,
                Message = $"Successfully paid {dto.PaymentIntention}",
                PaymentId = "123",
                Status = (Application.Payment.Enums.StatusEnum)Status.Success
            };

            var response = new PaymentResponse
            {
                Data = responseDto,
                Success = true,
                Message = "Payment successfully processed"
            };

            paymentProcessor.
                Setup(x => x.CapturePayment(dto.PaymentIntention))
                .Returns(Task.FromResult(response));

            paymentProcessorFactory
                .Setup(x => x.GetPaymentProcessor(dto.SelectedPaymentProvider))
                .Returns(paymentProcessor.Object);

            var bookingManager = new BookingManager(
                bookingRepository.Object,
                roomRepository.Object,
                guestRepository.Object,
                paymentProcessorFactory.Object);

            var res = await bookingManager.PayForABooking(dto);

            Assert.NotNull(res);
            Assert.True(res.Success);
            Assert.AreEqual(res.Message, "Payment successfully processed");
        }
    }
}
