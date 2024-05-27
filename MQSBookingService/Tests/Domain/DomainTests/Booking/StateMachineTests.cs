
using Domain.Entities;
using Domain.Enums;
using NUnit.Framework;
using Action = Domain.Enums.Action;

namespace DomainTests.Bookings;

public class StateMachineTests
{
    [SetUp]
    public void Setup() {  }

    [Test]
    public void ShowlAlwaysStartWithCreatedStatus()
    {
        var booking = new Booking();
        Assert.AreEqual(booking.Status, Status.Created);
    }

    [Test]
    public void ShowldSetStatusToPaidWhenPayingForBookingWithCreatedStatus()
    {
        var booking = new Booking();

        booking.ChangeState(Action.Pay);

        Assert.AreEqual(booking.Status, Status.Paid);
    }

    [Test]
    public void ShowldSetStatusToCanceldWhenCancelingForBookingWithCreatedStatus()
    {
        var booking = new Booking();

        booking.ChangeState(Action.Cancel);

        Assert.AreEqual(booking.Status, Status.Canceled);
    }

    [Test]
    public void ShouldNotSetStatusToFinishedWhenFinishingAPaidBooking()
    {
        var booking = new Booking();

        booking.ChangeState(Action.Pay);

        booking.ChangeState(Action.Finish);

        Assert.AreEqual(booking.Status, Status.Finished);
    }

    [Test]
    public void ShoudlSetStatusToRefoundedWhenFinishingAPaidBooking()
    {
        var booking = new Booking();

        booking.ChangeState(Action.Pay);

        booking.ChangeState(Action.Refound);

        Assert.AreEqual(booking.Status, Status.Refounded);
    }

    [Test]
    public void ShouldSetStatusToCreatedWhenReopeningCanceledBooking()
    {
        var booking = new Booking();

        booking.ChangeState(Action.Cancel);

        booking.ChangeState(Action.Reopen);

        Assert.AreEqual(booking.Status, Status.Created);
    }

    [Test]
    public void ShouldSetNotChangeStatusWhenRefoundingBookingWithCreatedState()
    {
        var booking = new Booking();

        booking.ChangeState(Action.Refound);

        Assert.AreEqual(booking.Status, Status.Created);
    }

    [Test]
    public void ShouldSetNotChangeStatusWhenRefoundingBookingWithFinished()
    {
        var booking = new Booking();

        booking.ChangeState(Action.Pay);
        booking.ChangeState(Action.Finish);
        booking.ChangeState(Action.Refound);

        Assert.AreEqual(booking.Status, Status.Finished);
    }
}
