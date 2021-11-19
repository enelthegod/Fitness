using System;

namespace Fitness.BL.Model
{

    [Serializable]
    
    public class User
    {
        #region Properties
        public string Name { get; }

        public Gender Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public double Weight { get; set; }

        public double Height { get; set; }

        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }
        //DateTime nowDate = DateTie.Today;
        //int age = nowDate.Year - birthDate.Year;
        //if(birthdate > nowDate.AddYears(-age)) age--;
        #endregion

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

        public User(string name) 
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Incorrect user name", nameof(name));
            }

            Name = name;
        }
        public override string ToString()
        {
            return Name + " " +Age ;
        }
    }
}
