using Domain.Enums;

namespace Domain.Entities
{
	public class Booking
	{
		public Booking()
		{
		}

		public int Id { get; set; }
		public DateTime PlacedAt { get; set; }
		public DateTime Start { get; set; }
		public DateTime End { get; set; }
		public Status Status { get; set; }

		public Status CurrenStatus { get { return this.Status; } }
	}
}

