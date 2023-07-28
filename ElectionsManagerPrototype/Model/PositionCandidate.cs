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
        /// Elections result(True/False - win/loose)
        /// </summary>
        public bool WinInElections { get; set; }

        /// <summary>
        /// Position for which the candidate is intended
        /// </summary>
        public ElectoralBodyPosition AssPosition { get; set; }

        /// <summary>
        /// Votes count
        /// Key: Ballot Box ID
        /// Value: VotesCount
        /// </summary>
        public Dictionary<string, long> BallotBoxVotesDict { get; set; } = new Dictionary<string, long>();

        #endregion//Properties

        #region Constructors--------------------------------------------------

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="name">Candidate name</param>
        /// <param name="id">Candidate Israeli ID</param>
        /// <param name="address">Candidate address</param>
        /// <param name="phone">Candidate Israeli phone</param>
        public PositionCandidate(string name, string id, Address address, string phone, Role role) : base(name, id, address, phone, role)
        {
        }

        #endregion//Constructors

        #region Public Methods------------------------------------------------

        /// <summary>
        /// Add vote to candidate
        /// </summary>
        /// <param name="bBoxId">Ballot Box ID, which request vote</param>
        /// <exception cref="ArgumentException">Raised when not exist Ballot Box Id was requested</exception>
        public void AddVote(string bBoxId)
        {
            if(BallotBoxVotesDict.ContainsKey(bBoxId))
            {
                BallotBoxVotesDict[bBoxId]++;
            }
            else
            {
                throw new ArgumentException("Wrong ballot box id was received");
            }
        }

        /// <summary>
        /// get the number of votes for a candidate, which are received from the ballot box by its ID
        /// </summary>
        /// <param name="bBoxId">Ballot Box ID, for which request number of votes</param>
        /// <exception cref="ArgumentException">Raised when not exist Ballot Box Id was requested</exception>
        public long GetVotes(string bBoxId)
        {
            if (BallotBoxVotesDict.ContainsKey(bBoxId))
            {
                return BallotBoxVotesDict[bBoxId];
            }
            else
            {
                throw new ArgumentException("Wrong ballot box id was received");
            }
        }

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
