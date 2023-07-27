using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectionsManagerPrototype.Model
{
    /// <summary>
    /// Address Class
    /// </summary>
    public class Address
    {
        #region Properties----------------------------------------------------

        /// <summary>
        /// City as part of address
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Street as part of address
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Home as part of address
        /// </summary>
        public string Home { get; set; }

        /// <summary>
        /// Apartment as part of address
        /// </summary>
        public string Apartment { get; set; }

        #endregion//Properties

        #region Constructors--------------------------------------------------

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="city">Address city</param>
        /// <param name="street">Address street</param>
        /// <param name="home">Address home</param>
        /// <param name="apartment">(Optional)Address apartment</param>
        public Address(string city, string street, string home, string apartment = null)
        {
            City = city;
            Street = street;
            Home = home;
            Apartment = apartment;
        }

        #endregion//Constructors

        #region Public Methods------------------------------------------------

        /// <summary>
        /// Override of built-in object method for correct using in this app
        /// </summary>
        /// <returns>Address as a string</returns>
        public override string ToString()
        {
            // Create a StringBuilder instance to concatenate substrings
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"#------Address details Starts------#");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"\tCity : {City}");
            stringBuilder.AppendLine($"\tStreet : {Street}");
            stringBuilder.AppendLine($"\tHome : {Home}");

            if(Apartment != null)
                stringBuilder.AppendLine($"\tApartment : {Apartment}");

            stringBuilder.AppendLine();
            stringBuilder.AppendLine("#------Address details Starts------#");

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Override of built-in object method for correct using in this app
        /// </summary>
        /// <param name="obj">Address as object</param>
        /// <returns>True/False if addresses are equals or not</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Address))
                return false;

            Address other = (Address)obj;

            // Compare all the properties for equality
            return string.Equals(City, other.City) &&
                   string.Equals(Street, other.Street) &&
                   string.Equals(Home, other.Home) &&
                   ((Apartment == null || other.Apartment == null) ? true : string.Equals(Apartment, other.Apartment));
        }

        /// <summary>
        /// Override of built-in object method for correct using in this app
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            // Implement a basic hash code generation
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (City != null ? City.GetHashCode() : 0);
                hash = hash * 23 + (Street != null ? Street.GetHashCode() : 0);
                hash = hash * 23 + (Home != null ? Home.GetHashCode() : 0);
                hash = hash * 23 + (Apartment != null ? Apartment.GetHashCode() : 0);
                return hash;
            }
        }

        #endregion//Public Methods
    }
}
