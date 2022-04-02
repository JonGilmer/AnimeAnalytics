using System;
using System.Collections.Generic;
using AnimeAnalytics.Models;

namespace AnimeAnalytics
{
    public interface IAnimeListRepo
    {
        // AnimeRec represents Anime Recommender API
        public List<string> GetAnimeRecAnimeList();
    }
}
