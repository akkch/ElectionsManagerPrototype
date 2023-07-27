using System.Net;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace ElectionsManagerPrototype.Model
{
    /// <summary>
    /// Base User Class
    /// </summary>
    public class User
    {
        #region Fields--------------------------------------------------------

        /// <summary>
        /// User ID(Israeli)
        /// </summary>
        private string _Id;

        /// <summary>
        /// User phone(Israeli)
        /// </summary>
        private string _Phone;

        #endregion//Fields

        #region Properties----------------------------------------------------

        /// <summary>
        /// User Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// User Address
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// User ID(Israeli)
        /// </summary>
        public string Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    if (User._IsValidID(value))
                    {
                        _Id = value;
                    }
                    else
                    {
                        throw new ArgumentException("Received ID is not valid");
                    }
                }
            }
        }

        /// <summary>
        /// User phone(Israeli)
        /// </summary>
        public string Phone
        {
            get
            {
                return _Phone;
            }
            set
            {
                if (_Phone != value)
                {
                    if (User._IsValidPhone(value))
                    {
                        _Phone = value;
                    }
                    else
                    {
                        throw new ArgumentException("Received phone is not valid");
                    }
                }
            }
        }

        /// <summary>
        /// User role in Elections Management System
        /// </summary>
        public Role RoleInSystem { get; set; }

        #endregion//Properties

        #region Constructors--------------------------------------------------

        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <param name="address"></param>
        /// <param name="phone"></param>
        /// <param name="roleIntSystem">User role in Elections Management System</param>
        public User(string name, string id, Address address, string phone, Role roleIntSystem)
        {
            Name = name;
            Id = id;
            Address = address;
            Phone = phone;
            RoleInSystem = roleIntSystem;
        }

        #endregion//Constructors

        #region Public Methods------------------------------------------------

        /// <summary>
        /// Override of built-in object method for correct using in this app
        /// </summary>
        /// <returns>User as a string</returns>
        public override string ToString()
        {
            // Create a StringBuilder instance to concatenate substrings
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"#------User details Starts------#");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"\tName : {Name}");
            stringBuilder.AppendLine($"\tID : {Id}");
            stringBuilder.AppendLine($"\tPhone : {Phone}");
            stringBuilder.AppendLine($"\tRole In System : {RoleInSystem}");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("\t" + Address.ToString().Replace("\n", "\n\t"));
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"#------User details Ends------#");

            return stringBuilder.ToString();
        }

        #endregion//Public Methods

        #region Private Methods-----------------------------------------------

        #region Event Handlers

        //  -   None

        #endregion//Event Handlers

        #region Helpers

        /// <summary>
        /// Validate Israeli ID
        /// </summary>
        /// <param name="idNumber">Israeli ID</param>
        /// <returns>True/False - Valid/Not valid</returns>
        private static bool _IsValidID(string idNumber)
        {
            // Check if the input is exactly 9 digits
            if (idNumber.Length != 9 || !_IsNumeric(idNumber))
            {
                return false;
            }

            // Convert the ID number to an array of digits
            int[] digits = new int[9];
            for (int i = 0; i < 9; i++)
            {
                digits[i] = int.Parse(idNumber[i].ToString());
            }

            // Calculate the control digit
            int sum = 0;
            for (int i = 0; i < 8; i++)
            {
                int digit = digits[i];
                if (i % 2 == 0)
                {
                    digit *= 1;
                }
                else
                {
                    digit *= 2;
                    if (digit > 9)
                    {
                        digit = (digit % 10) + 1;
                    }
                }
                sum += digit;
            }

            int controlDigit = (10 - (sum % 10)) % 10;

            // Check if the control digit matches the last digit of the ID number
            return controlDigit == digits[8];
        }

        /// <summary>
        /// Validate Israeli phone number
        /// </summary>
        /// <param name="phoneNumber">Israeli phone</param>
        /// <returns>True/False - Valid/Not valid</returns>
        private static bool _IsValidPhone(string phoneNumber)
        {
            // Define the regular expression pattern to match Israeli phone numbers
            string pattern = @"^(?:\+972|0)(?:-)?(\d{2})(?:-)?(\d{7})$";

            // Create a Regex object
            Regex regex = new Regex(pattern);

            // Check if the input matches the pattern
            Match match = regex.Match(phoneNumber);

            // Check if the input string is a valid Israeli phone number
            if (match.Success)
            {
                // If the phone number has an area code starting with 05, it should have 10 digits in total
                // Otherwise, the total number of digits should be 9
                int areaCode = int.Parse(match.Groups[1].Value);
                int numberLength = match.Groups[2].Value.Length;

                if (areaCode >= 5 && numberLength == 7)
                {
                    return true;
                }
                else if (areaCode < 5 && numberLength == 6)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Check if string its number
        /// </summary>
        /// <param name="value">string for check</param>
        /// <returns>True/False - Number/Not number</returns>
        private static bool _IsNumeric(string value)
        {
            return int.TryParse(value, out _);
        }

        #endregion//Helpers

        #endregion//Private Methods

        #region Nested Types--------------------------------------------------

        /// <summary>
        /// Possible roles in the system
        /// </summary>
        public enum Role
        {
            Candidate,
            PositionOwner,
            Voter,
            ElComMember,
            SystemAdmin
        }

        #endregion//Nested Types

    }
}
