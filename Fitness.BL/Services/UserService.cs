using Fitness.BL.Model;
using Fitness.BL.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness.BL.Service
{
    public class UserService : ServiceBase
    {
        private const string USERS_FILE_NAME = "users.dat";
        public List<User> User {get;} 

        public User CurrentUser { get; }

        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Create new user controller.
        /// </summary>
        /// <param name="user"></param>
        public UserService(string userName)
        {
            if(string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Incorrect User name", nameof(userName));
            }

            User = GetUserData();

            CurrentUser = User.SingleOrDefault(u => u.Name == userName);
            
            if(CurrentUser == null)
            {
                CurrentUser = new User(userName);
                User.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }

        }         
        private List<User> GetUserData()
        {
            return Load<List<User>>(USERS_FILE_NAME) ?? new List<User>();
        }

        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }
        /// <summary>
        /// Save user file.
        /// </summary>
        public void Save()
        {
            Save(USERS_FILE_NAME, User);
        }

    }
}
