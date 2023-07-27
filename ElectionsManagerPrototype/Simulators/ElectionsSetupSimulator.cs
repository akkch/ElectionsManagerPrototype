using ElectionsManagerPrototype.Contracts;
using ElectionsManagerPrototype.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElectionsManagerPrototype.Simulators
{
    /// <summary>
    /// Class which simulate System Admin Behavior in "Preparations for Elections" Use Case
    /// Example for simulation : Elections to School
    /// </summary>
    public class ElectionsSetupSimulator: IElectionsSetupModel
    {
        #region Properties----------------------------------------------------

        /// <summary>
        /// Link to elections instance
        /// </summary>
        public Elections ToScoolBoard { get; set; }

        /// <summary>
        /// The type of electoral body for which the election is being modeled(such as school boards, city councils, etc.)
        /// </summary>
        private string _ElectoralBodyName { get; set; }

        /// <summary>
        /// The number of candidates for the position for which the election will be simulated
        /// </summary>
        private int _NumOfCandidates { get; set; }

        /// <summary>
        /// Number of ballot boxes to be used in the election simulation
        /// </summary>
        private int _NumOfBbox { get; set; }

        /// <summary>
        /// Number of voters per ballot box to be involved in the election simulation
        /// </summary>
        private int _NumOfVotersPerBbox { get; set; }

        /// <summary>
        /// The number and positions that will be involved in the election simulation
        /// </summary>
        private int _NumOfPositions { get; set; }

        #endregion//Properties

        #region Constructors--------------------------------------------------

        /// <summary>
        /// Run simulation
        /// </summary>
        /// <param name="electoralBodyName">The type of electoral body for which the election is being modeled(such as school boards, city councils, etc.)</param>
        /// <param name="numOfCandidates">The number of candidates for the position for which the election will be simulated</param>
        /// <param name="numOfBbox">Number of ballot boxes to be used in the election simulation</param>
        /// <param name="numOfVotersPerBbox">Number of voters per ballot box to be involved in the election simulation</param>
        /// <param name="numOfPositions">The number and positions that will be involved in the election simulation</param>
        public void RunSimulation(string electoralBodyName, int numOfCandidates, int numOfBbox, int numOfVotersPerBbox, int numOfPositions)
        {
            _ElectoralBodyName = electoralBodyName;
            _NumOfCandidates = numOfCandidates;
            _NumOfBbox = numOfBbox;
            _NumOfVotersPerBbox = numOfVotersPerBbox;
            _NumOfPositions = numOfPositions;

            ElectoralBody Scool = _GetElectoralBody();
            List<BallotBox> toScoolBallotBoxesList = _GetBallotBoxes(Scool);

            ToScoolBoard = new Elections(123456789, Scool, toScoolBallotBoxesList, DateTime.Now, DateTime.Now.AddMinutes(2));

            Console.WriteLine("Preparation of simulation results");

            for (int i = 0; i < 5; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
            
            Console.WriteLine(ToScoolBoard);

            Console.WriteLine("Press any key for continue");
            Console.ReadKey();

        }

        #endregion//Constructors

        #region Private Methods-----------------------------------------------

        #region Event Handlers

        //  -   None

        #endregion//Event Handlers

        #region Helpers

        /// <summary>
        /// Simulation of Electoral Body Definition
        /// </summary>
        /// <returns>Simulated Electoral Body</returns>
        private ElectoralBody _GetElectoralBody()
        {
            List<ElectoralBodyPosition> positions = new List<ElectoralBodyPosition>();

            for (int i = 0; i < _NumOfPositions; i++)
            {
                positions.Add(_GetPosition(i));
            }

            Address addr = new Address(_ElectoralBodyName + "City", _ElectoralBodyName + "Street", "1");

            return new ElectoralBody(_ElectoralBodyName, addr, positions);
        }

        /// <summary>
        /// Simulation of Electoral Position Definition
        /// </summary>
        /// <param name="iPositionNumber">Position number</param>
        /// <returns>Simulated Electoral Position</returns>
        private ElectoralBodyPosition _GetPosition(int iPositionNumber)
        {
            List<PositionCandidate> candidates = _GetCandidates(iPositionNumber);

            Address addr = new Address($"Position_{iPositionNumber}_Owner_City", $"Position_{iPositionNumber}_Owner_Street", iPositionNumber.ToString());
            PositionOwner owner = new PositionOwner($"Position_{iPositionNumber}_Owner_Name", GenerateValidID(), addr, "054304845" + iPositionNumber);

            return new ElectoralBodyPosition($"Position_{iPositionNumber}_Name", $"Position_{iPositionNumber}_Description", owner, candidates);
        }

        /// <summary>
        /// Simulation of Position Candidates Definition
        /// </summary>
        /// <param name="iPositionNumber">Position number</param>
        /// <returns>List of candidates to requested position</returns>
        private List<PositionCandidate> _GetCandidates(int iPositionNumber)
        {
            List<PositionCandidate> candidates = new List<PositionCandidate>();

            for (int i = 0; i < _NumOfCandidates; i++)
            {
                Address addr = new Address($"Position_{iPositionNumber}_Candidate_{i}_City", $"Position_{iPositionNumber}_Candidate_{i}_Street", iPositionNumber + i.ToString());
                candidates.Add(new PositionCandidate($"Position_{iPositionNumber}_Candidate_{i}_Name" + iPositionNumber + i, GenerateValidID(), addr, "05430484" + iPositionNumber + i));
            }

            return candidates;
        }

        /// <summary>
        /// Simulation of Ballot Boxes Definition
        /// </summary>
        /// <param name="elBody">Electoral body for which need to define Ballot Boxes</param>
        /// <returns>List of Ballot Boxes</returns>
        private List<BallotBox> _GetBallotBoxes(ElectoralBody elBody)
        {
            List<BallotBox> ballotBoxes = new List<BallotBox>();

            for (int ballotBoxId = 0; ballotBoxId < _NumOfBbox; ballotBoxId++)
            {
                Address addr = new Address($"BallotBox_{ballotBoxId}_City", $"BallotBox_{ballotBoxId}_Street", "1");
                ballotBoxes.Add(new BallotBox(ballotBoxId.ToString(), addr, _GetVoters(ballotBoxId, elBody)));
            }

            return ballotBoxes;
        }

        /// <summary>
        /// Simulation of voters Definition for specific Ballot Box
        /// </summary>
        /// <param name="ballotBoxId">Ballot Box ID</param>
        /// <param name="elBody">Electoral Body</param>
        /// <returns>List of Voters</returns>
        private List<Voter> _GetVoters(int ballotBoxId, ElectoralBody elBody)
        {
            List<Voter> voters = new List<Voter>();

            for (int i = 0; i < _NumOfVotersPerBbox; i++)
            {
                Address addr = new Address($"Voter_{i}_BallotBox_{ballotBoxId}_City", $"Voter_{i}_BallotBox_{ballotBoxId}_Street", ballotBoxId.ToString());
                voters.Add(new Voter($"Voter_{i}_BallotBox_{ballotBoxId}_Name", $"1234567{ballotBoxId}{i}", addr, "05430484" + ballotBoxId + i, elBody.PositionsList.Take(i).ToList()));
            }

            return voters;
        }

        /// <summary>
        /// Generate Israeli ID whichc will pass validation
        /// </summary>
        /// <returns></returns>
        private string GenerateValidID()
        {
            Random random = new Random();
            int[] digits = new int[8];

            // Generate the first 8 digits randomly (1 to 9)
            for (int i = 0; i < 8; i++)
            {
                digits[i] = random.Next(1, 10);
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

            // Append the control digit to the ID number
            string validIDNumber = string.Join("", digits) + controlDigit;

            return validIDNumber;
        }

        #endregion//Helpers

        #endregion//Private Methods
    }
}
