using System;
using System.Collections.Generic;
using System.Net.Http;
using AnimeAnalytics.Models;
using Newtonsoft.Json.Linq;

namespace AnimeAnalytics
{
    public class HumingbirdAPI_Setup
    {
        // Default Constructor
        public HumingbirdAPI_Setup()
        {
        }

        public static Anime GetHumingBirdAnimeInfo(string animeTitle, string apiKey)
        {
            var client = new HttpClient();
            var chosenAnime = new Anime();

            var animeInfoURL = $"https://hummingbirdv1.p.rapidapi.com/anime/{animeTitle}";

            var animeInfoResponse = client.GetStringAsync(animeInfoURL).Result;

            var formattedResponse = JObject.Parse(animeInfoResponse);

            var returnedTitle = formattedResponse["list"][0]["main"]["temp"];
            var returnedDescription = formattedResponse["list"][0]["main"]["temp"];
            var returnedEpisodeCount = formattedResponse["list"][0]["main"]["temp"];
            var returnedStatus = formattedResponse["list"][0]["main"]["temp"];
            var returnedAlternativeTitle = formattedResponse["list"][0]["main"]["temp"];
            var returnedGenre1 = formattedResponse["list"][0]["main"]["temp"];
            var returnedGenre2 = formattedResponse["list"][0]["main"]["temp"];
            var returnedCoverImage = formattedResponse["list"][0]["main"]["temp"];


            chosenAnime.Title = returnedTitle.ToString();
            chosenAnime.Description = returnedDescription.ToString();
            chosenAnime.EpisodeCount = Int32.Parse(returnedEpisodeCount.ToString());
            chosenAnime.Status = returnedStatus.ToString();
            chosenAnime.AlternateTitle = returnedAlternativeTitle.ToString();
            chosenAnime.Genre1 = returnedGenre1.ToString();
            chosenAnime.Genre2 = returnedGenre2.ToString();
            chosenAnime.CoverImageHBURL = returnedCoverImage.ToString();

            return chosenAnime;
        }





        // Main method for testing purposes
        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter your API key: ");
            var apiKey = Console.ReadLine();

            // Add methods to lowercase, replace spaces with "-" and remove punctuation from titles that are entered
            Console.WriteLine("What is the title of the anime you are requesting information on?: ");
            var animeTitle = Console.ReadLine();

            var info = GetHumingBirdAnimeInfo(animeTitle, apiKey);
            Console.WriteLine(info);
        }


    }
}
