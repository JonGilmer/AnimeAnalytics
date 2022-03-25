using System;

namespace AnimeAnalytics.Models
{
    public class Anime
    {
        public Anime()
        {
        }

        public int AnimeID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AverageScore { get; set; }
        public int SeasonYear { get; set; }
        public string CoverImageURL { get; set; }
        public string BannerImageURL { get; set; }
        public string Genre1 { get; set; }
        public string Genre2 { get; set; }
        public int EpisodeCount { get; set; }
        public string Status { get; set; }
        public string AlternateTitle { get; set; }

    }
}
