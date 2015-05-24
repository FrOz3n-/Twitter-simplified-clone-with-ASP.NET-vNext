using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using nexTwitter.Models;
using Microsoft.AspNet.Authorization;

namespace nexTwitter.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
       
    }
}