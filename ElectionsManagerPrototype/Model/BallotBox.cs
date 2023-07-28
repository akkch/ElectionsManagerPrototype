using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ElectionsManagerPrototype.Model
{
    /// <summary>
    /// BallotBox Class
    /// </summary>
    public class BallotBox
    {
        #region Properties----------------------------------------------------

        /// <summary>
        /// Ballot Box ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Ballot Box Address
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// Dictionary of voters related to this ballot box
        /// Key: Voter ID
        /// Value: Voter Instance
        /// </summary>
        public Dictionary<string, Voter> VotersList { get; set; }

        /// <summary>
        /// Elections for which the ballot box is intended
        /// </summary>
        public Elections AssElections { get; set; }

        #endregion//Properties

        #region Constructors--------------------------------------------------

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="id">Ballot box id</param>
        /// <param name="address">Ballot box address</param>
        /// <param name="votersList">Ballot box voters list</param>
        public BallotBox(string id, Address address, List<Voter> votersList)
        {
            Id = id;
            Address = address;
            VotersList = votersList.ToDictionary(voter => voter.Id); ;
            _AssociateVoters();
        }

        #endregion//Constructors

        #region Public Methods------------------------------------------------

        public void SetVote(string voterId, string positionName, string candidateId)
        {
            if(VotersList.ContainsKey(voterId))
            {
                if (VotersList[voterId].PositionsForVote.ContainsKey(positionName))
                { 

                }
            }
        }


        /// <summary>
        /// Override of built-in object method for correct using in this app
        /// </summary>
        /// <returns>Ballot Box as a string</returns>
        public override string ToString()
        {
            // Create a StringBuilder instance to concatenate substrings
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"#------Ballot Box details Starts------#");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"\tID {Id}");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("\t" + Address.ToString().Replace("\n", "\n\t"));
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"\tBallot Box belongs to Elections {AssElections.Id}");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"\t#------Voters list starts------#");
            stringBuilder.AppendLine();

            foreach (var voter in VotersList)
            {
                stringBuilder.AppendLine("\t" + voter.Value.ToString().Replace("\n", "\n\t"));
            }

            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"\t#------Voters list ends------#");
            stringBuilder.AppendLine();

            stringBuilder.AppendLine($"#------Ballot Box details Ends------#");

            return stringBuilder.ToString();
        }

        #endregion//Public Methods

        #region Private Methods-----------------------------------------------

        #region Event Handlers

        //  -   None

        #endregion//Event Handlers

        #region Helpers

        /// <summary>
        /// Associate all ballotBOx with this Elections
        /// </summary>
        private void _AssociateVoters()
        {
            foreach (KeyValuePair<string, Voter> kvp in VotersList)
            {
                string key = kvp.Key;
                Voter value = kvp.Value;
                value.AssBallotBox = this;

            }
        }

        #endregion//Helpers

        #endregion//Private Methods
    }
}
