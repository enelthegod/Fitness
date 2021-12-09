using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Services
{
    public class MealService : ServiceBase
    {
        private const string PRODUCTS_FILE_NAME = "products.dat";
        private const string MEALS_FILE_NAME = "meals.dat";
        private readonly User user;

        public List<Food> Products { get; }
        public Meal Meal { get; }

        public MealService(User user)
        {
            this.user = user ?? throw new ArgumentNullException("User fail-->empty", nameof(user));

            Products = GetAllProducts();
            Meal = GetMeal();
        }
        public void Add(Food food, double weight)
        {
            var product = Products.SingleOrDefault(f => f.Name == food.Name);
            if(food == null)
            {
                Products.Add(food);
                Meal.Add(food, weight);
                Save();
            }
            else
            {
                Meal.Add(food, weight);
                Save();
            }
        }

        private Meal GetMeal()
        {
            return Load<Meal>(MEALS_FILE_NAME) ?? new Meal(user);
        }

        private List<Food> GetAllProducts()
        {
             return Load<List<Food>>(PRODUCTS_FILE_NAME) ?? new List<Food>(); 
        }

        private void Save()
        {
            Save(PRODUCTS_FILE_NAME, Products);
            Save(MEALS_FILE_NAME, Meal);
        }
    }
}
