using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Task2.Data;
using Task2.Models;

namespace Task2.Controllers
{
    public class HomeController : Controller
    {
        private MarathonContext db;

        public HomeController(MarathonContext context)
        {
            db = context;
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(MarathonMember marathonMember)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await db.MarathonMember.AddAsync(marathonMember);
                    await db.SaveChangesAsync();
                }
                catch
                {
                    return Content("Ошибка при регистрации участника марафона!");
                }
            }
            return Content("Вы успешло зарегистрированы на участие в марафоне!");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
