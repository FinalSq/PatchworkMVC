using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PatchworkMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PatchworkMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult PWPage()
        {
            Patchwork model = new();

            model.PatchValue = 3;
            model.WorkValue = 5;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PWPage(Patchwork patchwork)
        {

            List<string> pwItems = new();
            bool patch;
            bool work;

            for (int i = 1; i <= 100; i++)
            {
                patch = (i % patchwork.PatchValue == 0);
                work = (i % patchwork.WorkValue == 0);

                if (patch == true && work == true)
                {
                    pwItems.Add("Patchwork");

                }
                else if (patch == true)
                {
                    pwItems.Add("Patch");

                }
                else if (work == true)
                {
                    pwItems.Add("work");

                }
                else
                {
                    pwItems.Add(i.ToString());
                }
            }

            patchwork.Result = pwItems;


            return View(patchwork);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
