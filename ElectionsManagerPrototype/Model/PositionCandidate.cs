using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectionsManagerPrototype.Model
{
    /// <summary>
    /// Electoral Body Position Candidate Class
    /// </summary>
    public class PositionCandidate: User
    {
        #region Properties----------------------------------------------------

        /// <summary>
        /// Votes count
        /// </summary>
        public long VotesCount { get; set; }

        /// <summary>
        /// Position for which the candidate is intended
        /// </summary>
        public ElectoralBodyPosition AssPosition { get; set; }

        #endregion//Properties

        #region Constructors--------------------------------------------------

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="name">Candidate name</param>
        /// <param name="id">Candidate Israeli ID</param>
        /// <param name="address">Candidate address</param>
        /// <param name="phone">Candidate Israeli phone</param>
        public PositionCandidate(string name, string id, Address address, string phone) : base(name, id, address, phone, User.Role.Candidate)
        {

        }

        #endregion//Constructors

        #region Public Methods------------------------------------------------

        /// <summary>
        /// Override of built-in object method for correct using in this app
        /// </summary>
        /// <returns>Voter as a string</returns>
        public override string ToString()
        {
            // Create a StringBuilder instance to concatenate substrings
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"#------Position Candidate details Starts------#");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"\tCandidate for the position {AssPosition.Name}");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("\t" + base.ToString().Replace("\n", "\n\t"));
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"#------Position Candidate details Ends------#");

            return stringBuilder.ToString();
        }

        #endregion//Public Methods
    }
}
