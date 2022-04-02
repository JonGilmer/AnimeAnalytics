using System;
using System.Collections.Generic;

namespace AnimeAnalytics.Models
{
    public class AnimeList
    {
        public AnimeList()
        {
        }

        public List<string> ListOfAnime { get; set; } = new List<string>();
        //public IEnumerable<string> AnimeListTitle { get; set; }
    }
}
