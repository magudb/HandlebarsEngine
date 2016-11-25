using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Website.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new
            {
                title="Test",
                content="Content"
            });
        }

       
        public IActionResult Error()
        {
            return View();
        }
    }
}
