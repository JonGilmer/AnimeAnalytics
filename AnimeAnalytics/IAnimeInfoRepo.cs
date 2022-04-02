using System;
using System.Collections.Generic;
using AnimeAnalytics.Models;

namespace AnimeAnalytics
{
    public interface IAnimeInfoRepo
    {
        // AnimeRec represents Anime Recommender API
        public bool GetAnimeRecTitleExists(string animeTitle);
        public Anime GetAnimeRecAnimeInfo(Anime animeTitle);
        public Anime GetAnimeRecRecommend(Anime animeTitle);
    }
}
