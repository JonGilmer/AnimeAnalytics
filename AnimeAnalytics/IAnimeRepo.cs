using System;
using AnimeAnalytics.Models;
using System.Collections.Generic;

namespace AnimeAnalytics
{
    public interface IAnimeRepo
    {
        public IEnumerable<Anime> GetAnime();
        public Anime GetAnime(int id);
        public void InsertAnime(Anime anime_var);
        public void UpdateAnime(Anime anime_var);
        public void DeleteAnime(Anime anime_var);
    }
}
