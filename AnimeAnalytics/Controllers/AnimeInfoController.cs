using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimeAnalytics.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnimeAnalytics.Controllers
{
    public class AnimeInfoController : Controller
    {
        // Creating instance of AnimeAPIRepo
        private readonly IAnimeInfoRepo repo;

        public AnimeInfoController(IAnimeInfoRepo repo)
        {
            this.repo = repo;
        }



        public IActionResult Index()
        {
            var chosenAnime = new Anime();
            return View(chosenAnime);
        }

        public IActionResult AnimeDoesNotExist()
        {
            return View("DisplayAnimeNotFound");
        }

        public IActionResult DisplayAnimeTitleExists(string searchTitle)
        {
            Anime chosenAnime = new Anime();
            chosenAnime.SearchTitle = searchTitle;
            var repoResponse = repo.GetAnimeRecTitleExists(chosenAnime.SearchTitle);
            if (repoResponse == false)
            {
                return RedirectToAction("AnimeDoesNotExist");
            }

            chosenAnime = repo.GetAnimeRecAnimeInfo(chosenAnime);
            chosenAnime = repo.GetAnimeRecRecommend(chosenAnime);

            return View(chosenAnime);
        }
    }
}
