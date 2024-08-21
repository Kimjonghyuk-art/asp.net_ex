using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NETMVC_test.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP.NETMVC_test.Controllers
{
    public class StudyController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {

          User user = new User();
          user.UserId = 1;
          user.UserName = "홍길동";

            //방법1.
            //return View(user);

          ViewBag.User = user;

        
            return View();
        }
        public IActionResult Java()
        {
            return View();
        }
    }
}

