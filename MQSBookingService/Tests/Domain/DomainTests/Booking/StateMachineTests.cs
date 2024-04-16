
using Domain.Entities;
using Domain.Enums;
using NUnit.Framework;
using Action = Domain.Enums.Action;

namespace DomainTests.Bookings;

public class StateMachineTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ShowlAlwaysStartWithCreatedStatus()
    {
        var booking = new Booking();
        Assert.AreEqual(booking.CurrenStatus, Status.Created);
    }

    [Test]
    public void ShowldSetStatusToPaidWhenPayingForBookingWithCreatedStatus()
    {
        var booking = new Booking();

        booking.ChengeState(Action.Pay);

        Assert.AreEqual(booking.CurrenStatus, Status.Paid);
    }

    [Test]
    public void ShowldSetStatusToCanceldWhenCancelingForBookingWithCreatedStatus()
    {
        var booking = new Booking();

        booking.ChengeState(Action.Cancel);

        Assert.AreEqual(booking.CurrenStatus, Status.Canceled);
    }

    [Test]
    public void ShouldNotSetStatusToFinishedWhenFinishingAPaidBooking()
    {
        var booking = new Booking();

        booking.ChengeState(Action.Pay);

        booking.ChengeState(Action.Finish);

        Assert.AreEqual(booking.CurrenStatus, Status.Finished);
    }

    [Test]
    public void ShoudlSetStatusToRefoundedWhenFinishingAPaidBooking()
    {
        var booking = new Booking();

        booking.ChengeState(Action.Pay);

        booking.ChengeState(Action.Refound);

        Assert.AreEqual(booking.CurrenStatus, Status.Refounded);
    }

    [Test]
    public void ShouldSetStatusToCreatedWhenReopeningCanceledBooking()
    {
        var booking = new Booking();

        booking.ChengeState(Action.Cancel);

        booking.ChengeState(Action.Reopen);

        Assert.AreEqual(booking.CurrenStatus, Status.Created);
    }

    [Test]
    public void ShouldSetNotChangeStatusWhenRefoundingBookingWithCreatedState()
    {
        var booking = new Booking();

        booking.ChengeState(Action.Refound);

        Assert.AreEqual(booking.CurrenStatus, Status.Created);
    }

    [Test]
    public void ShouldSetNotChangeStatusWhenRefoundingBookingWithFinished()
    {
        var booking = new Booking();

        booking.ChengeState(Action.Pay);
        booking.ChengeState(Action.Finish);
        booking.ChengeState(Action.Refound);

        Assert.AreEqual(booking.CurrenStatus, Status.Finished);
    }
}
