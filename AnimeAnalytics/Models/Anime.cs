using System;

namespace AnimeAnalytics.Models
{
    public class Anime
    {
        public Anime()
        {
        }

        public int AnimeID { get; set; }
        public string SearchTitle { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AverageScore { get; set; }
        public int SeasonYear { get; set; }
        public string CoverImageARURL { get; set; }
        public string BannerImageURL { get; set; }
        public string TitleNative { get; set; }
        // Recommended Anime
        public string RecAnime1_Title { get; set; }
        public string RecAnime2_Title { get; set; }
        public string RecAnime3_Title { get; set; }
        public string RecAnime4_Title { get; set; }
        public string RecAnime1_CoverImage { get; set; }
        public string RecAnime2_CoverImage { get; set; }
        public string RecAnime3_CoverImage { get; set; }
        public string RecAnime4_CoverImage { get; set; }
        //public string CoverImageHBURL { get; set; }
        //public string Genre1 { get; set; }
        //public string Genre2 { get; set; }
        //public int EpisodeCount { get; set; }
        //public string Status { get; set; }
    }
}
