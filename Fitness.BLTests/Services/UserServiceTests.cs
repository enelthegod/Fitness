using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fitness.BL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Service.Tests
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
            var service = new UserService(userName);

            service.SetNewUserData(gender, birthdate, weight, height);
            var service2 = new UserService(userName);


            Assert.AreEqual(userName, service2.CurrentUser.Name);
            Assert.AreEqual(birthdate, service2.CurrentUser.BirthDate);
            Assert.AreEqual(weight, service2.CurrentUser.Weight);
            Assert.AreEqual(height, service2.CurrentUser.Height);
            Assert.AreEqual(gender, service2.CurrentUser.Gender.Name);

        }

        [TestMethod()]
        public void SaveTest()
        {
            //arrange 
            var userName = Guid.NewGuid().ToString();

            //act
            var service = new UserService(userName);

            //assert
            Assert.AreEqual(userName, service.CurrentUser.Name);

        }
    }

}