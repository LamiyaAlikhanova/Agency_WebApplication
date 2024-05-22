using Agency_WebAppliaction.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Agency_WebAppliaction.Controllers
{
    
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        
    }
}
