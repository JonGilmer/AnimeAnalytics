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
    public class AnimeAPIRepo : IAnimeAPIRepo
    {
        // Default Constructor
        public AnimeAPIRepo()
        {
        }

        // ----- Setting up connection with appsettings to retrieve API Key ------
        private readonly IConfiguration _configuration;

        public AnimeAPIRepo(IConfiguration configuration)
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
                    { "X-RapidAPI-Key", $"\"{authKey}\"" },
                },
            };

            using var response = client.SendAsync(request);
            var responseContent = response.Result.Content.ReadAsStringAsync().Result;
            JObject formattedResponse = JObject.Parse(responseContent);
            string responseData = formattedResponse["data"][0].ToString();
            bool titleExists = bool.Parse(responseData);

            return titleExists;
        }


        public Anime GetAnimeRecAnimeInfo(string animeTitle)
        {
            var authKey = GetAuthKey();
            var chosenAnime = new Anime();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://anime-recommender.p.rapidapi.com/get_anime_info?anime_title={animeTitle}"),

                Headers =
                {
                    { "X-RapidAPI-Host", "anime-recommender.p.rapidapi.com" },
                    { "X-RapidAPI-Key", $"\"{authKey}\"" },
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

            Console.WriteLine(animeID);
            Console.WriteLine(averageScore);
            Console.WriteLine(bannerImageURL);
            Console.WriteLine(coverImageURL);
            Console.WriteLine(description);
            Console.WriteLine(seasonYear);

            chosenAnime.AnimeID = animeID;
            chosenAnime.AverageScore = averageScore;
            chosenAnime.BannerImageURL = bannerImageURL;
            chosenAnime.CoverImageARURL = coverImageURL;
            chosenAnime.Description = description;
            chosenAnime.SeasonYear = seasonYear;

            return chosenAnime;

        }


        //// PARSE FOR IENUMBERABLE, NOT SINGLE OBJECT
        public string[] GetAnimeRecAnimeList()
        {
            var authKey = GetAuthKey();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://anime-recommender.p.rapidapi.com/get_titles"),
                Headers =
                {
                    { "X-RapidAPI-Host", "anime-recommender.p.rapidapi.com" },
                    { "X-RapidAPI-Key", $"\"{authKey}\"" },
                },
            };

            using var response = client.SendAsync(request);
            var formattedResponse = response.Result.Content.ReadAsStringAsync().Result.ToString();
            var animeList = formattedResponse.Split(',');

            foreach (var title in animeList)
                Console.WriteLine($"{title}\n");

            return animeList;
        }


        public string[] GetAnimeRecRecommend(string animeTitle)
        {
            var authKey = GetAuthKey();
            var client = new HttpClient();
            var request = new HttpRequestMessage

            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://anime-recommender.p.rapidapi.com/?anime_title={animeTitle}&number_of_anime=5"),
                Headers =
                {
                    { "X-RapidAPI-Host", "anime-recommender.p.rapidapi.com" },
                    { "X-RapidAPI-Key", $"\"{authKey}\"" },
                },
            };

            using var response = client.SendAsync(request);
            var responseContent = response.Result.Content.ReadAsStringAsync().Result;
            JObject formattedResponse = JObject.Parse(responseContent);

            string recommendedAnime1 = formattedResponse["data"][0]["title"]["english"].ToString();
            string recommendedAnime2 = formattedResponse["data"][1]["title"]["english"].ToString();
            string recommendedAnime3 = formattedResponse["data"][2]["title"]["english"].ToString();
            string recommendedAnime4 = formattedResponse["data"][3]["title"]["english"].ToString();
            string recommendedAnime5 = formattedResponse["data"][4]["title"]["english"].ToString();

            string[] recommendedAnimeList = new string[5] { recommendedAnime1, recommendedAnime2,
                recommendedAnime3, recommendedAnime4, recommendedAnime5 };
            return recommendedAnimeList;
        }
    }
}
