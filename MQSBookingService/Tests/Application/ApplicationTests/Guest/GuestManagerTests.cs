using Application;
using Domain.Ports;
using Guest = Domain.Entities.Guest;
using NUnit.Framework;
using Application.Guest.DTO;
using Application.Guest.Requests;

namespace ApplicationTests.Guests
{
    class FakeRepo : IGuestRepository
    {
        public Task<int> Create(Guest guest)
        {
            return Task.FromResult(1111);
        }

        public Task<Guest> Get(int Id)
        {
            throw new NotImplementedException();
        }
    }

    public class GuestManagerTests
    {
        GuestManager guestManager;

        [SetUp]
        public void Setup() 
        {
            var fakeRepo = new FakeRepo();
            guestManager = new GuestManager(fakeRepo);
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
