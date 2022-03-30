using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimeAnalytics.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnimeAnalytics.Controllers
{
    public class AnimeController : Controller
    {
        // Creating instance of AnimeAPIRepo
        private readonly IAnimeAPIRepo repo;

        public AnimeController(IAnimeAPIRepo repo)
        {
            this.repo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DisplayAnimeTitleExists()
        {
            var inputAnime = Console.ReadLine();
            var repoResponse = repo.GetAnimeRecTitleExists(inputAnime);
            if (repoResponse == true)
            {
                var modelTrue = repo.GetAnimeRecAnimeInfo(inputAnime);
                return View(modelTrue);
            }
            else
            {
                var modelFalse = "This anime does not exist! Please check your spelling, capitalization, and punctuation.";
                return View(modelFalse);
            }
        }
        
        public IActionResult DisplayAnimeInfo()
        {
            Console.WriteLine("");
            var inputAnime = Console.ReadLine();
            Anime chosenAnime;

            chosenAnime = repo.GetAnimeRecAnimeInfo(inputAnime);
            var model = chosenAnime;
            return View(model);
        }

        public IActionResult DisplayAnimeList()
        {
            var animeList = repo.GetAnimeRecAnimeList();
            var model = animeList;
            return View(model);
        }

        public IActionResult DisplayRecommendedAnime()
        {
            Console.WriteLine("");
            var inputAnime = Console.ReadLine();

            var animeRecommendations = repo.GetAnimeRecRecommend(inputAnime);
            var model = animeRecommendations;
            return View(model);
        }
    }
}
