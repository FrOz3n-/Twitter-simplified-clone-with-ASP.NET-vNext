using System;

namespace nexTwitter.Domain.Entities
{
    public class Tweet : BaseEntity
    {
		public int UserId { get; set; }
		public string Text { get; set; }
		public virtual User User { get; set; }
	}
}
