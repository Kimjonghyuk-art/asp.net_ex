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

        public IActionResult Study()
        {
          return View();
        }

    public IActionResult Submit(User user)
    {



      if (ModelState.IsValid)
      {
        // Process the form data (e.g., save to database, send email, etc.)
        // For demonstration, we're just returning the data to the view.

        // You might redirect to a "Thank You" page or display a success message
        ViewBag.Message = "Your message has been sent!";
        return View("Success", user);
      }

      // If the model is invalid, return the form view with validation errors
      return View("Index");
    }

    public IActionResult Success(User user)
    {
      return View(user);
    }



  }
}

