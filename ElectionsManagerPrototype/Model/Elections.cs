using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ElectionsManagerPrototype.Model
{
    /// <summary>
    /// Elections Class
    /// </summary>
    public class Elections
    {
        #region Fields--------------------------------------------------------

        /// <summary>
        /// Elections Start Date and Time(Will be received in constructor)
        /// </summary>
        private readonly DateTime _StartDateTime;

        /// <summary>
        /// Elections End Date and Time(Will be defined by closing elections - By Elections committee member)
        /// </summary>
        private DateTime _EndDateTime;

        /// <summary>
        /// Voting End Date and Time(Will be defined in constructor - By adding voting duration)
        /// </summary>
        private readonly DateTime _VotingEndDateTime;

        /// <summary>
        /// For call Date/Time listener
        /// </summary>
        private Timer _Timer;

        #endregion//Fields

        #region Properties----------------------------------------------------

        /// <summary>
        /// Elections ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Electoral body for which elections are held
        /// </summary>
        public ElectoralBody ElectoralBody { get; set; }

        /// <summary>
        /// List of ballot boxes where Voters can vote
        /// </summary>
        public List<BallotBox> BallotBoxesList { get; set; }

        /// <summary>
        /// Elections opened/closed indication
        /// </summary>
        public bool ElectionsOpened { get; set; }

        /// <summary>
        /// Voting opened/closed indication
        /// </summary>
        public bool VotingOpened { get; set; }

        #endregion//Properties

        #region Events--------------------------------------------------------

        /// <summary>
        /// Will be happen when elections start date/time is reached
        /// </summary>
        public event EventHandler StartDateTimeReached;

        /// <summary>
        /// Will be happen when elections end date/time is reached
        /// </summary>
        public event EventHandler EndDateTimeReached;

        #endregion//Events

        #region Constructors--------------------------------------------------

        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="id">Elections id</param>
        /// <param name="electoralBody">Elections electoral body</param>
        /// <param name="ballotBoxesList">Elections ballot boxes list</param>
        /// <param name="startDateTime">Elections start date/time</param>
        /// <param name="votingDuration">Voting duration in seconds</param>
        public Elections(int id, ElectoralBody electoralBody, List<BallotBox> ballotBoxesList, DateTime startDateTime, int votingDuration)
        {
            Id = id;
            _AssociateElectoralBody(electoralBody);
            _AssociateBallotBoxes(ballotBoxesList);
            _StartDateTime = startDateTime;
            _VotingEndDateTime = _StartDateTime.AddSeconds(votingDuration);
        }

        #endregion//Constructors

        #region Public Methods------------------------------------------------

        /// <summary>
        /// Run elections service
        /// </summary>
        public void RunService()
        {
            _Timer = new Timer(_DateTimeListener, null, 0, 1000);
        }

        /// <summary>
        /// Close elections
        /// </summary>
        public void Close()
        {
            ElectionsOpened = false;
            _EndDateTime = DateTime.Now;
        }

        /// <summary>
        /// Override of built-in object method for correct using in this app
        /// </summary>
        /// <returns>Ballot Box as a string</returns>
        public override string ToString()
        {
            // Create a StringBuilder instance to concatenate substrings
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"#------Elections details Starts------#");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"\tID {Id}");
            stringBuilder.AppendLine($"\tElections Status : {(ElectionsOpened ? "Opened" : "Closed")}");
            stringBuilder.AppendLine($"\tVoting Status : {(ElectionsOpened ? "Opened" : "Closed")}");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("\t" + ElectoralBody.ToString().Replace("\n", "\n\t"));
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"\t#------Ballot Boxes list starts------#");
            stringBuilder.AppendLine();

            foreach (var bBox in BallotBoxesList)
            {
                stringBuilder.AppendLine("\t" + bBox.ToString().Replace("\n", "\n\t"));
            }

            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"\t#------Ballot Boxes list ends------#");
            stringBuilder.AppendLine();

            stringBuilder.AppendLine($"#------Elections details Ends------#");

            return stringBuilder.ToString();
        }

        #endregion//Public Methods

        #region Private Methods-----------------------------------------------

        #region Event Handlers

        /// <summary>
        /// Dat/Time Listener, for raise Elections opened/closed events
        /// </summary>
        private void _DateTimeListener(object state)
        {
            DateTime now = DateTime.Now;

            if (now >= _StartDateTime && !ElectionsOpened)
            {
                _ElectionsOpened();
            }
            else if (now >= _VotingEndDateTime)
            {
                _VotingClosed();

                // Stop the timer since the end date is reached
                _Timer.Dispose();
            }
        }

        /// <summary>
        /// Associate all ballotBox with this Elections
        /// </summary>
        /// <param name="ballotBoxesList">List of ballot boxes which related to this elections</param>
        private void _AssociateBallotBoxes(List<BallotBox> ballotBoxesList)
        {
            BallotBoxesList = ballotBoxesList;
            BallotBoxesList.ForEach(b => { b.AssElections = this; });
        }

        /// <summary>
        /// Associate Electoral Body with this Elections
        /// </summary>
        /// <param name="ballotBoxesList">The electoral body for which the elections will be held</param>
        private void _AssociateElectoralBody(ElectoralBody electoralBody)
        {
            ElectoralBody = electoralBody;
            ElectoralBody.AssElections = this;
        }

        #endregion//Event Handlers

        #region Helpers

        private void _ElectionsOpened()
        {
            ElectionsOpened = true;
            VotingOpened = true;
        }

        private void _VotingClosed()
        {
            VotingOpened = false;
            Console.WriteLine("Voting was closed");
        }

        #endregion//Helpers

        #endregion//Private Methods
    }
}