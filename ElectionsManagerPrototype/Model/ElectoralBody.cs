using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectionsManagerPrototype.Model
{
    /// <summary>
    /// Electoral Body Class(such as school boards, city councils, etc.)
    /// </summary>
    public class ElectoralBody
    {
        #region Properties----------------------------------------------------

        /// <summary>
        /// Electoral Body Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Electoral Body Address
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// List of electoral positions
        /// </summary>
        public List<ElectoralBodyPosition> PositionsList { get; set; }

        /// <summary>
        /// Elections for which the ballot box is intended
        /// </summary>
        public Elections AssElections { get; set; }

        #endregion//Properties

        #region Constructors--------------------------------------------------

        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="name">Electoral body name</param>
        /// <param name="address">Electoral body address</param>
        /// <param name="positionsList">Electoral body positions list</param>
        public ElectoralBody(string name, Address address, List<ElectoralBodyPosition> positionsList)
        {
            Name = name;
            Address = address;

            _AssociatePositions(positionsList);
        }

        #endregion//Constructors

        #region Public Methods------------------------------------------------

        /// <summary>
        /// Override of built-in object method for correct using in this app
        /// </summary>
        /// <returns>Electoral Body as a string</returns>
        public override string ToString()
        {
            // Create a StringBuilder instance to concatenate substrings
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"#------Electoral Body details Starts------#");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"\tName : {Name}");
            stringBuilder.AppendLine($"\tElectoral Body belongs to Elections {AssElections.Id}");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("\t" + Address.ToString().Replace("\n", "\n\t"));
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"\t#------Positions list starts------#");
            stringBuilder.AppendLine();

            foreach (var position in PositionsList)
            {
                stringBuilder.AppendLine("\t" + position.ToString().Replace("\n", "\n\t"));
            }

            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"\t#------Positions list ends------#");
            stringBuilder.AppendLine();

            stringBuilder.AppendLine($"#------Electoral Body details Ends------#");

            return stringBuilder.ToString();
        }

        #endregion//Public Methods

        #region Private Methods-----------------------------------------------

        #region Event Handlers

        //  -   None

        #endregion//Event Handlers

        #region Helpers

        /// <summary>
        /// Associate all positions with this Electoral Body
        /// </summary>
        /// <param name="positionsList">List of positions for which the elections will be held</param>
        private void _AssociatePositions(List<ElectoralBodyPosition> positionsList)
        {
            PositionsList = positionsList;
            PositionsList.ForEach(p => { p.AssElectoralBody = this; });
        }

        #endregion//Helpers

        #endregion//Private Methods
    }
}
