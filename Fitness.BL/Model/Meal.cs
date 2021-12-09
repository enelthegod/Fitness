using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Model
{
    public class Meal
    {
        public DateTime Moment { get; }

        public Dictionary<Food, double> Products { get; }

        public User User { get; }

        public Meal (User user)
        {
            User = user ?? throw new ArgumentNullException("Fail--> empty or null",nameof(user));
            Moment = DateTime.UtcNow;
            Products = new Dictionary<Food, double>();
        }

        public void Add(Food food, double weight)
        {
     
            var product = Products.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));
            
            if(product == null)
            {
                Products.Add(food, weight);
            }
            else
            {
                Products[product] += weight;
            }
        }

    }
}
