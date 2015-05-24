using System;
using System.Security.Principal;

namespace nexTwitter.Models
{
    public class MyCustomPrincipal : IPrincipal
    {
		public MyCustomPrincipal(string Username)
		{
			this.Identity = new GenericIdentity(Username);
		}
		public IIdentity Identity { get; private set; }
		public string Id { get; set; }
		public string Email { get; set; }
		public bool IsAdministrator { get; set; }
		public string FullName { get; set; }
		public string ImageUrl { get; set; }
		public bool IsInRole(string role)
		{
			if (!Identity.IsAuthenticated)
			{
				return false;
			}
			if (role == "User")
				return !IsAdministrator;
			else if (role == "Admin")
				return IsAdministrator;
			return false;
		}
	}

	public class PrincipalViewModel
	{
		public string Id { get; set; }
		public string Email { get; set; }
		public bool IsAdministrator { get; set; }
		public string FullName { get; set; }
		public string ImageUrl { get; set; }

	}
}