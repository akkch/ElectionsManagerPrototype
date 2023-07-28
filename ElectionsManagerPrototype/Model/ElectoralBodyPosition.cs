using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectionsManagerPrototype.Model
{
    /// <summary>
    /// Electoral Body Position Class
    /// </summary>
    public class ElectoralBodyPosition
    {
        #region Properties----------------------------------------------------

        /// <summary>
        /// Position Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Position Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Position Owner
        /// </summary>
        public PositionOwner Owner { get; set; }

        /// <summary>
        /// Position Candidates
        /// Key: Candidate ID
        /// Value Candidate Instance
        /// </summary>
        public Dictionary<string, PositionCandidate> CandidatesList { get; set; }

        /// <summary>
        /// Electoral Body of this position
        /// </summary>
        public ElectoralBody AssElectoralBody { get; set; }

        #endregion//Properties

        #region Constructors--------------------------------------------------

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="name">Electoral body position name</param>
        /// <param name="description">Electoral body position description</param>
        /// <param name="owner">Electoral body position owner</param>
        /// <param name="candidatesList">Electoral body position candidates list</param>
        public ElectoralBodyPosition(string name, string description, PositionOwner owner, Dictionary<string, PositionCandidate> candidatesList)
        {
            Name = name;
            Description = description;

            _AssociateOwner(owner);
            _AssociateCandidates(candidatesList);
        }

        #endregion//Constructors

        #region Public Methods------------------------------------------------

        /// <summary>
        /// Override of built-in object method for correct using in this app
        /// </summary>
        /// <returns>Electoral Body Position as a string</returns>
        public override string ToString()
        {
            // Create a StringBuilder instance to concatenate substrings
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"#------Electoral Body Position details Starts------#");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"\tName : {Name}");
            stringBuilder.AppendLine($"\tDescription : {Description}");
            stringBuilder.AppendLine($"\tElectoral Body Position belongs to Electoral Body : {AssElectoralBody.Name}");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("\t" + Owner.ToString().Replace("\n", "\n\t"));
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"\t#------Candidates list starts------#");
            stringBuilder.AppendLine();

            foreach (var candidate in CandidatesList)
            {
                stringBuilder.AppendLine("\t" + candidate.ToString().Replace("\n", "\n\t"));
            }

            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"\t#------Candidates list ends------#");
            stringBuilder.AppendLine();

            stringBuilder.AppendLine($"#------Electoral Body Position details Ends------#");

            return stringBuilder.ToString();
        }

        #endregion//Public Methods

        #region Private Methods-----------------------------------------------

        #region Event Handlers

        //  -   None

        #endregion//Event Handlers

        #region Helpers

        /// <summary>
        /// Associate owner of this position
        /// </summary>
        /// <param name="owner">Current owner of this position</param>
        private void _AssociateOwner(PositionOwner owner)
        {
            Owner = owner;
            owner.AssPosition = this;
        }

        /// <summary>
        /// Associate all candidates for this position
        /// </summary>
        /// <param name="candidatesList">Dictionary with candidates for this position</param>
        private void _AssociateCandidates(Dictionary<string, PositionCandidate> candidatesList)
        {
            CandidatesList = candidatesList;
            foreach (var candidate in CandidatesList)
            {
                candidate.Value.AssPosition = this;
            }
        }

        #endregion//Helpers

        #endregion//Private Methods
    }
}
