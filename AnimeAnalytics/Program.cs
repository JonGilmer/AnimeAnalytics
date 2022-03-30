using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AnimeAnalytics
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();


            //// --------- Section for testing purposes only!!!! ----------
            //// Get the anime title that user wants to access
            //Console.WriteLine("What is the title of the anime you are requesting information on (Case sensitive)?: ");
            //var animeTitle = Console.ReadLine();
            //// Encode user input as URL format (ASCII)
            //string animeTitleEncoded = WebUtility.UrlEncode(animeTitle);
            //string animeTitleEncodedSpaces = animeTitleEncoded.Replace("+", "%20");

            //// ---------- Anime Title Exists ---------- 
            ////GetAnimeRecTitleExists(animeTitleEncodedSpaces);

            //// Create a while loops that lets the user try to fix mistakes
            ////while (GetAnimeRecTitleExists == false)
            ////{
            ////    Console.WriteLine("Oops! Did you make a mistake? Remember to use correct capitalization and punctuation.");
            ////}

            //// ---------- Anime Info ---------- 
            //Anime chosenAnime = new Anime();
            //chosenAnime = GetAnimeRecAnimeInfo(animeTitleEncodedSpaces);

            //// ---------- Full Anime List ---------- 
            ////GetAnimeRecAnimeList();

            //// ---------- Recommended Anime ----------
            //GetAnimeRecRecommend(animeTitleEncodedSpaces);

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
