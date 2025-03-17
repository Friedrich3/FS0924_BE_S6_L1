using FS0924_BE_S6_L1.Services;
using Microsoft.AspNetCore.Mvc;

namespace FS0924_BE_S6_L1.Controllers
{
    public class StudentiController : Controller
    {
        private readonly StudentiServices _studentiServices;
        public StudentiController(StudentiServices studentiServices)
        {
            _studentiServices = studentiServices;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
