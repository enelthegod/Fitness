using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fitness.BL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitness.BL.Service;
using Fitness.BL.Model;

namespace Fitness.BL.Services.Tests
{
    [TestClass()]
    public class MealServiceTests
    {
        [TestMethod()]
        public void AddTest()
        {
            var userName = Guid.NewGuid().ToString();
            var productName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userService = new UserService(userName);
            var mealService = new MealService(userService.CurrentUser);
            var product = new Food(productName, rnd.Next(50, 500), rnd.Next(50, 500));
        }
    }
}