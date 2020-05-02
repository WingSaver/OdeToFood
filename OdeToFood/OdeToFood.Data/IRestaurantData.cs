using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
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

        public IEnumerable<Restaurant> GetAll()
        {
            //return from r in restaurants
            //       orderby r.
            var result = restaurants.OrderBy(or => or.Name);

            var result1 = from r in restaurants
                          orderby r.Name
                          select r;

            //return (from r in restaurants
            //        orderby r.Name
            //        select r);

            return result;
        }
    }
}
