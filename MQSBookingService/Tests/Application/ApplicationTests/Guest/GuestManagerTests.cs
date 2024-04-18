using Application;
using Domain.Ports;
using Guest = Domain.Entities.Guest;
using NUnit.Framework;
using Application.Guest.DTO;
using Application.Guest.Requests;
using Moq;

namespace ApplicationTests.Guests
{
    public class GuestManagerTests
    {
        GuestManager guestManager;

        [SetUp]
        public void Setup() 
        {
            var fakeRepo = new Mock<IGuestRepository>();
            fakeRepo.Setup(x => x.Create(It.IsAny<Guest>())).Returns(Task.FromResult(222));
            guestManager = new GuestManager(fakeRepo.Object);
        }

        [Test]
        public async Task Test1()
        {
            var guestDTO = new GuestDTO
            {
                Name = "Test",
                Surname = "Testando",
                Email = "testando@gmail.com",
                IdNumber = "abcd",
                IdTypeCode = 1
            };

            var request = new CreateGuestRequest()
            {
                Data = guestDTO,
            };

            var res = await guestManager.CreateGuest(request);
            Assert.IsNotNull(res);
            Assert.True(res.Success);
        }
    }
}
