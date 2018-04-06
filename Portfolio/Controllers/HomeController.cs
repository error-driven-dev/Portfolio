using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("projects")]
        public IActionResult Projects()
        {
            return View();
        }
        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View();
        }
    }
}