using System;

namespace nexTwitter.Domain.Entities
{
    public class UserWithTweet : BaseEntity
    {
		public int UserId { get; set; }
		public int TweetId { get; set; }

		public virtual User User { get; set; }
		public virtual Tweet Tweet { get; set; }
	}
}