using Microsoft.AspNet.Mvc;
using nexTwitter.Business.ApplicationServices.Services;
using System;

namespace nexTwitter.Controllers
{
	public class UsersController : Controller
	{
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
		public ActionResult All()
		{
            var user = _userService.GetById(1);
            if (user != null)
            {
                ViewBag.Result = "success!";
            }
            else
                ViewBag.Result = "Not Found :(";
			return View();
		}
	}
}