using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using AnimeAnalytics.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AnimeAnalytics
{
    public class AnimeListRepo : IAnimeListRepo
    {
        public readonly IConfiguration _configuration;

        public AnimeListRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetAuthKey()
        {
            var authKey = _configuration.GetConnectionString("AuthorizationKey");
                //GetValue<string>("AuthorizationKey");
            return authKey;
        }

        public List<string> GetAnimeRecAnimeList()
        {
            var authKey = GetAuthKey();
            var animeList = new AnimeList();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://anime-recommender.p.rapidapi.com/get_titles"),
                Headers =
                {
                    { "X-RapidAPI-Host", "anime-recommender.p.rapidapi.com" },
                    { "X-RapidAPI-Key", "c4add58659mshdfdbdffa531f767p1929a7jsnf630a44c647b" },
                },
            };

            using var response = client.SendAsync(request);
            var responseJSON = response.Result.Content.ReadAsStringAsync().Result;
            var stringResponse = JObject.Parse(responseJSON).GetValue("data").ToString();

            var stringTitles = JsonConvert.DeserializeObject<List<string>>(stringResponse);
            //stringTitles.ForEach(x => animeList.ListOfAnime(x));
            //animeList.ListOfAnime = stringTitles;
            return stringTitles;
        }
    }
}
