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

            var fakeRepo = new Mock<IGuestRepository>();
            fakeRepo.Setup(x => x.Create(It.IsAny<Guest>())).Returns(Task.FromResult(222));
            guestManager = new GuestManager(fakeRepo.Object);

            var res = await guestManager.CreateGuest(request);
            Assert.IsNotNull(res);
            Assert.True(res.Success);
            Assert.AreEqual(res.Data.Id, 222);
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase("a")]
        [TestCase("ab")]
        [TestCase("abc")]
        public async Task Shold_Return_InvalidPersonDocumentIdException_WhenDocsAreInvaliddocNUmber(string docNumber)
        {
            var guestDTO = new GuestDTO
            {
                Name = "Test",
                Surname = "Testando",
                Email = "testando@gmail.com",
                IdNumber = docNumber,
                IdTypeCode = 1
            };

            var request = new CreateGuestRequest()
            {
                Data = guestDTO,
            };

            var fakeRepo = new Mock<IGuestRepository>();
            fakeRepo.Setup(x => x.Create(It.IsAny<Guest>())).Returns(Task.FromResult(222));
            guestManager = new GuestManager(fakeRepo.Object);

            var res = await guestManager.CreateGuest(request);
            Assert.IsNotNull(res);
            Assert.False(res.Success);
            Assert.AreEqual(res.ErrorCode, ErrorCodes.INVALID_PERSON_ID);
            Assert.AreEqual(res.Message, "The ID passed is not valid.");
        }

        [TestCase("","surnametest","asdf@gmail.com")]
        [TestCase(null, "surnametest", "asdf@gmail.com")]
        [TestCase("Fulano", "", "asdf@gmail.com")]
        [TestCase("Fulano", null, "asdf@gmail.com")]
        [TestCase("Fulano", "surnametest", "")]
        [TestCase("Fulano", "surnametest", null)]
        public async Task Shold_Return_MissingRequeridInformation_WhenDocsAreInvalid(string name, string surname, string email)
        {
            var guestDTO = new GuestDTO
            {
                Name = name,
                Surname = surname,
                Email = email,
                IdNumber = "abcd",
                IdTypeCode = 1
            };

            var request = new CreateGuestRequest()
            {
                Data = guestDTO,
            };

            var fakeRepo = new Mock<IGuestRepository>();
            fakeRepo.Setup(x => x.Create(It.IsAny<Guest>())).Returns(Task.FromResult(222));
            guestManager = new GuestManager(fakeRepo.Object);

            var res = await guestManager.CreateGuest(request);
            Assert.IsNotNull(res);
            Assert.False(res.Success);
            Assert.AreEqual(res.ErrorCode, ErrorCodes.MISSING_REQUIRED_INFORMATION);
            Assert.AreEqual(res.Message, "Missing required information passed.");
        }
    }
}
