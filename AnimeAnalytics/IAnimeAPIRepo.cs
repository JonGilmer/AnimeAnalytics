using System;
using System.Collections.Generic;
using AnimeAnalytics.Models;

namespace AnimeAnalytics
{
    public interface IAnimeAPIRepo
    {
        // AnimeRec represents Anime Recommender API
        public bool GetAnimeRecTitleExists(string animeTitle);
        public Anime GetAnimeRecAnimeInfo(string animeTitle);
        public string[] GetAnimeRecAnimeList();
        public string[] GetAnimeRecRecommend(string animeTitle);
    }
}
