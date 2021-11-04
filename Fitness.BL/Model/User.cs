using System;

namespace Fitness.BL.Model
{
    /// <summary>
    /// User.
    /// </summary>
    [Serializable]

    public class User
    {
        #region Properties
        public string Name { get; }

        public Gender Gender { get; }

        public DateTime BirthDate { get; }

        public double Weight { get; set; }

        public double Height { get; set; }
        #endregion
        /// <summary>
        /// Create new user.
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="gender">Gender</param>
        /// <param name="birthdate">Birthdate</param>
        /// <param name="weight">Weight</param>
        /// <param name="height">Height</param>
        public User(string name, Gender gender, DateTime birthdate, double weight, double height)
        {
        #region Tests
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Invalid name user", nameof(name));
            }

            if (gender == null)
            {
                throw new ArgumentNullException("Invalid gender user", nameof(gender));
            }

            if (birthdate < DateTime.Parse("01.01.1900") || birthdate >= DateTime.Now )
            {
                throw new ArgumentException ("Invalide birthdate", nameof(birthdate));
            }

            if (weight <= 0)
            {
                throw new ArgumentException ("Invalid weight", nameof(weight));
            }

            if(height <= 0)
            {
                throw new ArgumentException ("Invalid height", nameof(height));
            }
        #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthdate;
            Weight = weight;
            Height = height;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
