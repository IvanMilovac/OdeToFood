using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {

        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                 new Restaurant {Id=1, Name="Ivan's favorit place", Cuisine=CuisineType.Italian},
                 new Restaurant {Id=2, Name="Lucija's favorit place", Cuisine=CuisineType.Franch},
                 new Restaurant {Id=3, Name="Our's favorit place", Cuisine=CuisineType.Indian},
            };
        }
        
        public void Add(Restaurant restaurant)
        {
            restaurant.Id = restaurants.Max(r => r.Id)+1;
            restaurants.Add(restaurant);
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(r=>r.Name);
        }

        public Restaurant Get(int id)
        {
            return restaurants.FirstOrDefault(r=>r.Id==id);
        }

        public void Update(Restaurant restaurant)
        {
            var existing = Get(restaurant.Id);
            if(existing!=null)
            {
                existing.Name = restaurant.Name;
                existing.Cuisine = restaurant.Cuisine;
            }
        }

        public void Delete(int id)
        {
            var restaurant = Get(id);
            if(restaurant!=null)
            {
                restaurants.Remove(restaurant);
            }
        }
    }
}
