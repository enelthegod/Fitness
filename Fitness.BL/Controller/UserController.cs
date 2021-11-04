using Fitness.BL.Model;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// User controller.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Programm user.
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Create new user controller.
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName, string genderName,DateTime birthday, double weight, double height)
        {
            //TODO:Tests
            var gender = new Gender(genderName);
            User = new User(userName, gender, birthday, weight, height);
        }
        /// <summary>
        /// Save user file.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }

        /// <summary>
        /// Get users file.
        /// </summary>
        /// <returns>Programm user.</returns>
        public UserController()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if( formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }
                //TODO: user-->what else?
            }
        }
    }
}
