﻿using System.Collections.Generic;
using System.Linq;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private readonly List<Restaurant> _restaurants;

        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>()
            {
                new Restaurant {Id = 1, Name = "Pavel`s Pizza", Location = "Haifa", Cuisine = CuisineType.Italian},
                new Restaurant {Id = 2, Name = "Cinnamon Club", Location = "London", Cuisine = CuisineType.Indian},
                new Restaurant {Id = 3, Name = "La Costa", Location = "California", Cuisine = CuisineType.Mexican}
            };
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return _restaurants.Where(r => string.IsNullOrEmpty(name) || r.Name.StartsWith(name)).OrderBy(r => r.Name);
        }

        public Restaurant GetById(int id)
        {
            return _restaurants.SingleOrDefault(r => r.Id == id);
        }
    }
}