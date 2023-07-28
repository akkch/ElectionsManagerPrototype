using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectionsManagerPrototype.Model
{
    /// <summary>
    /// Voter Class
    /// </summary>
    public class Voter : User
    {
        #region Properties----------------------------------------------------

        /// <summary>
        /// Ballot box where the voter need vote
        /// </summary>
        public BallotBox AssBallotBox { get; set; }


        /// <summary>
        /// Dictionary of positions for which voter cab vote
        /// Key: Position Name
        /// Value: Position Instance
        /// </summary>
        public Dictionary<string, ElectoralBodyPosition> PositionsForVoteDict { get; set; }

        #endregion//Properties

        #region Constructors--------------------------------------------------

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="name">Voter name</param>
        /// <param name="id">Voter Israeli ID</param>
        /// <param name="address">Voter address</param>
        /// <param name="phone">Voter Israeli phone</param>
        /// <param name="positionsForVote">Dictionary of positions for which voter cab vote</param>
        public Voter(string name, string id, Address address, string phone, Dictionary<string, ElectoralBodyPosition> positionsForVote) : base(name, id, address, phone, User.Role.Voter)
        {
            PositionsForVoteDict = positionsForVote;
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

            stringBuilder.AppendLine($"#------Voter details Starts------#");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"\tVoter belogns to ballot box : {AssBallotBox.Id}");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("\t" + base.ToString().Replace("\n", "\n\t"));
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"\t#------List of possible votes starts------#");
            stringBuilder.AppendLine();

            foreach (var position in PositionsForVoteDict)
            {
                stringBuilder.AppendLine($"\tPosition for vote : {position.Value.Name}");
            }

            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"\t#------List of possible votes ends------#");
            stringBuilder.AppendLine();

            stringBuilder.AppendLine($"#------Voter details Ends------#");

            return stringBuilder.ToString();
        }

        #endregion//Public Methods
    }
}
