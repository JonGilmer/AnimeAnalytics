using System;
using System.Collections.Generic;
using System.Data;
using AnimeAnalytics.Models;
using Dapper;

namespace AnimeAnalytics
{
    public class AnimeRepo : IAnimeRepo
    {
        private readonly IDbConnection _conn;

        // Default Constructor
        public AnimeRepo(IDbConnection conn)
        {
            _conn = conn;
        }
    }
}
