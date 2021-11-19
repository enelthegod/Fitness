using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Controller.Tests
{
    [TestClass()]
    public class UserServiceTests
    {
        [TestMethod()]
        public void SetNewUserDataTests()
        {
            var userName = Guid.NewGuid().ToString();
            var birthdate = DateTime.Now.AddYears(- 18);
            var weight = 90;
            var height = 190;
            var gender = "man";
            var controller = new UserService(userName);

            controller.SetNewUserData(gender, birthdate, weight, height);
            var controller2 = new UserService(userName);


            Assert.AreEqual(userName, controller2.CurrentUser.Name);
            Assert.AreEqual(birthdate, controller2.CurrentUser.BirthDate);
            Assert.AreEqual(weight, controller2.CurrentUser.Weight);
            Assert.AreEqual(height, controller2.CurrentUser.Height);
            Assert.AreEqual(gender, controller2.CurrentUser.Gender.Name);

        }

        [TestMethod()]
        public void SaveTest()
        {
            //arrange 
            var userName = Guid.NewGuid().ToString();

            //act
            var controller = new UserService(userName);

            //assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);

        }
    }

}