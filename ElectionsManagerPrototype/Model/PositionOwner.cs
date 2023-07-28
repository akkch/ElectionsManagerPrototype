using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectionsManagerPrototype.Model
{
    /// <summary>
    /// Electoral Body Position Owner Class
    /// </summary>
    public class PositionOwner: PositionCandidate
    {
        #region Constructors--------------------------------------------------

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="name">Candidate name</param>
        /// <param name="id">Candidate Israeli ID</param>
        /// <param name="address">Candidate address</param>
        /// <param name="phone">Candidate Israeli phone</param>
        public PositionOwner(string name, string id, Address address, string phone) : base(name, id, address, phone, User.Role.PositionOwner)
        {

        }


        #endregion//Constructors

        #region Public Methods------------------------------------------------

        /// <summary>
        /// Override of built-in object method for correct using in this app
        /// </summary>
        /// <returns>Position owner as a string</returns>
        public override string ToString()
        {
            // Create a StringBuilder instance to concatenate substrings
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"#------Position Owner details Starts------#");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("\t" + base.ToString().Replace("\n", "\n\t"));
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"#------Position Owner details Ends------#");

            return stringBuilder.ToString();
        }

        #endregion//Public Methods
    }
}
