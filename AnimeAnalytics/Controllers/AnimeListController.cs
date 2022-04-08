using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AnimeAnalytics.Controllers
{
    public class AnimeListController : Controller
    {
        // Creating instance of AnimeAPIRepo
        private readonly IAnimeListRepo repo;

        public AnimeListController(IAnimeListRepo repo)
        {
            this.repo = repo;
        }

        public IActionResult DisplayAnimeList()
        {
            var animeTitle = repo.GetAnimeRecAnimeList();

            if (animeTitle == null)
            {
                return View();
            }

            return View(animeTitle);
        }
    }
}