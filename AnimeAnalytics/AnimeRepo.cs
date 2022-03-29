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


        //public IEnumerable<Anime> GetAnime()
        //{
        //    return _conn.Query<Anime>("SELECT * FROM bestbuy.products;");
        //}

        //public Anime GetAnime(int id)
        //{
        //    return _conn.QuerySingleOrDefault<Anime>("SELECT * FROM bestbuy.products WHERE ProductID = @id;", new { id = id });
        //}

        //public void InsertAnime(Anime anime_var)
        //{
        //    _conn.Execute("INSERT INTO bestbuy.products (Name, Price, CategoryID, OnSale, StockLevel)" +
        //    " VALUES (@Name, @Price, @CategoryID, @OnSale, @StockLevel);", new
        //    {
        //        name = anime_var.Name,
        //        price = anime_var.Price,
        //        categoryID = anime_var.CategoryID,
        //        onSale = anime_var.OnSale,
        //        stockLevel = anime_var.StockLevel
        //    });
        //}

        //public void UpdateAnime(Anime anime_var)
        //{
        //    _conn.Execute("UPDATE bestbuy.products SET Name = @name, Price = @price, OnSale = @onSale, StockLevel = @stockLevel WHERE ProductID = @id",
        //    new { name = anime_var.Name, price = anime_var.Price, onSale = anime_var.OnSale, stockLevel = anime_var.StockLevel, id = anime_var.ProductID });
        //}

        //public void DeleteAnime(Anime anime_var)
        //{
        //    _conn.Execute("DELETE from bestbuy.products WHERE ProductID = @id", new { id = anime_var.ProductID });
        //    _conn.Execute("DELETE from bestbuy.reviews WHERE ProductID = @id", new { id = anime_var.ProductID });
        //    _conn.Execute("DELETE from bestbuy.sales WHERE ProductID = @id", new { id = anime_var.ProductID });
        //}

    }
}
