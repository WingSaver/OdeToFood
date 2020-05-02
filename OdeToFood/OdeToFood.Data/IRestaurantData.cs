using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{Id=1, Name="Pizz Hut", Cuisine=CuisineType.Italian, Location="Burwood"},
                new Restaurant{Id=2, Name="China Bar", Cuisine=CuisineType.None, Location="Box Hill"},
                new Restaurant{Id=3, Name="TarcoBell", Cuisine=CuisineType.Mexican, Location="Ringwood"},
                new Restaurant{Id=4, Name="Kazaan", Cuisine=CuisineType.Indian, Location="Knox"}
            };
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            //return from r in restaurants
            //       orderby r.
            //var result = restaurants.OrderBy(or => or.Name);
            //var result = restaurants.Where(or=> string.IsNullOrEmpty(or.Name) || or.Name.StartsWith(name)).OrderBy(or => or.Name);

            var result1 = from r in restaurants
                          where string.IsNullOrEmpty(name) || r.Name.ToLower().StartsWith(name.ToLower())
                          orderby r.Name
                          select r;

            //return (from r in restaurants
            //        orderby r.Name
            //        select r);

            return result1;
        }
    }
}
