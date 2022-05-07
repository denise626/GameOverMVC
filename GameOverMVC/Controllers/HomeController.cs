using GameOverMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GameOverMVC.Controllers
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

        public IActionResult GOPage()
        {
            GameOver model = new();

            model.GameValue = 3;
            model.OverValue = 5;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GOPage(GameOver gameover)
        {
            List<string> goItems = new();

            bool game;
            bool over;

            for(int i = 1; i <=100; i++)
            {
                game = (i % gameover.GameValue == 0);
                over = (i % gameover.OverValue == 0);

                if (game == true && over == true)
                {
                    goItems.Add("GameOver");
                }
                else if (game == true)
                {
                    goItems.Add("Game");
                }else if(over == true)
                {
                    goItems.Add("Over");
                }
                else
                {
                    goItems.Add(i.ToString());
                }
            }
            gameover.Result = goItems;

            return View(gameover);
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
