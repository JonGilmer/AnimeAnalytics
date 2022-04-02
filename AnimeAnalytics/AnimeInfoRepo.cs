using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using AnimeAnalytics.Models;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace AnimeAnalytics
{
    public class AnimeInfoRepo : IAnimeInfoRepo
    {
        // ----- Setting up connection with appsettings to retrieve API Key ------
        private readonly IConfiguration _configuration;

        // Constructor
        public AnimeInfoRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetAuthKey()
        {
            var authKey = _configuration.GetValue<string>("AuthorizationKey");
            return authKey;
        }


        // ------- API Get Methods --------
        public bool GetAnimeRecTitleExists(string animeTitle)
        {
            var authKey = GetAuthKey();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://anime-recommender.p.rapidapi.com/title_exists?anime_title={animeTitle}"),
                Headers =
                {
                    { "X-RapidAPI-Host", "anime-recommender.p.rapidapi.com" },
                    { "X-RapidAPI-Key", "c4add58659mshdfdbdffa531f767p1929a7jsnf630a44c647b" },
                },
            };

            using var response = client.SendAsync(request);
            var responseContent = response.Result.Content.ReadAsStringAsync().Result;
            JObject formattedResponse = JObject.Parse(responseContent);
            string responseData = formattedResponse["data"][0].ToString();
            bool titleExists = bool.Parse(responseData);

            return titleExists;
        }


        public Anime GetAnimeRecAnimeInfo(Anime animeTitle)
        {
            var authKey = GetAuthKey();
            //var chosenAnime = new Anime();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://anime-recommender.p.rapidapi.com/get_anime_info?anime_title={animeTitle.SearchTitle}"),

                Headers =
                {
                    { "X-RapidAPI-Host", "anime-recommender.p.rapidapi.com" },
                    { "X-RapidAPI-Key", "c4add58659mshdfdbdffa531f767p1929a7jsnf630a44c647b" },
                },
            };

            using var response = client.SendAsync(request);
            var responseContent = response.Result.Content.ReadAsStringAsync().Result;
            JObject formattedResponse = JObject.Parse(responseContent);

            int animeID = Int32.Parse(formattedResponse["data"]["id"].ToString());
            int averageScore = Int32.Parse(formattedResponse["data"]["averageScore"].ToString());
            string bannerImageURL = formattedResponse["data"]["bannerImage"].ToString();
            string coverImageURL = formattedResponse["data"]["coverImage"]["large"].ToString();
            string description = formattedResponse["data"]["description"].ToString();
            int seasonYear = Int32.Parse(formattedResponse["data"]["seasonYear"].ToString());

            animeTitle.AnimeID = animeID;
            animeTitle.AverageScore = averageScore;
            animeTitle.BannerImageURL = bannerImageURL;
            animeTitle.CoverImageARURL = coverImageURL;
            animeTitle.Description = description;
            animeTitle.SeasonYear = seasonYear;

            return animeTitle;

        }


        public Anime GetAnimeRecRecommend(Anime animeTitle)
        {
            var authKey = GetAuthKey();
            //var chosenAnime = new Anime();
            var client = new HttpClient();
            var request = new HttpRequestMessage

            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://anime-recommender.p.rapidapi.com/?anime_title={animeTitle.SearchTitle}&number_of_anime=5"),
                Headers =
                {
                    { "X-RapidAPI-Host", "anime-recommender.p.rapidapi.com" },
                    { "X-RapidAPI-Key", "c4add58659mshdfdbdffa531f767p1929a7jsnf630a44c647b" },
                },
            };

            using var response = client.SendAsync(request);
            var responseContent = response.Result.Content.ReadAsStringAsync().Result;
            JObject formattedResponse = JObject.Parse(responseContent);

            // English title parsing
            string recAnime1_Title = formattedResponse["data"][1]["title"]["english"].ToString();
            string recAnime2_Title = formattedResponse["data"][2]["title"]["english"].ToString();
            string recAnime3_Title = formattedResponse["data"][3]["title"]["english"].ToString();
            string recAnime4_Title = formattedResponse["data"][4]["title"]["english"].ToString();
            //string recAnime5_Title = formattedResponse["data"][4]["title"]["english"].ToString();
            // Cover image parsing
            string recAnime1_CvrImg = formattedResponse["data"][1]["coverImage"]["large"].ToString();
            string recAnime2_CvrImg = formattedResponse["data"][2]["coverImage"]["large"].ToString();
            string recAnime3_CvrImg = formattedResponse["data"][3]["coverImage"]["large"].ToString();
            string recAnime4_CvrImg = formattedResponse["data"][4]["coverImage"]["large"].ToString();
            //string recAnime5_CvrImg = formattedResponse["data"][4]["coverImage"]["large"].ToString();

            animeTitle.RecAnime1_CoverImage = recAnime1_CvrImg;
            animeTitle.RecAnime1_Title = recAnime1_Title;
            animeTitle.RecAnime2_CoverImage = recAnime2_CvrImg;
            animeTitle.RecAnime2_Title = recAnime2_Title;
            animeTitle.RecAnime3_CoverImage = recAnime3_CvrImg;
            animeTitle.RecAnime3_Title = recAnime3_Title;
            animeTitle.RecAnime4_CoverImage = recAnime4_CvrImg;
            animeTitle.RecAnime4_Title = recAnime4_Title;

            return animeTitle;
        }
    }
}
