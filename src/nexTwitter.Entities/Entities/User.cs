using System;

namespace nexTwitter.Domain.Entities
{
    public class User : BaseEntity
    {
		public string Username { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public string Country { get; set; }
		public DateTime DateOfBirth { get; set; }
	}
}