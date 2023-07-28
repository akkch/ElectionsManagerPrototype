

using ElectionsManagerPrototype.Contracts;
using System;
using System.Text;
using System.Threading;

namespace ElectionsManagerPrototype.UI
{
    /// <summary>
    /// Elections Management App Elections setup console UI
    /// </summary>
    public class ConsoleUI: IElectionsSetupView
    {
        #region Events--------------------------------------------------------

        /// <summary>
        /// Run simulation action
        /// </summary>
        public Action<string, int, int, int, int> RunSimulation { get; set; }

        /// <summary>
        /// Input validation callback delegate
        /// </summary>
        /// <param name="inputChar">Char for validation</param>
        /// <returns>Valid/Not valid</returns>
        delegate bool CallbackIsValidChar(char inputChar);

        #endregion//Events

        #region Public Methods------------------------------------------------

        /// <summary>
        /// Show main page
        /// </summary>
        public void ShowMainPage()
        {
            string choice = "";

            while (!choice.Equals("q"))
            {

                Console.Clear();
                Console.WriteLine($"Elections Management Information System Simulator");
                Console.WriteLine("Hello System Admin, you are logged in");
                Console.WriteLine($"Please enter 1 for simulation setup or Q for exit");
                choice = Console.ReadLine().ToLower();

                switch (choice)
                {
                    case "1":
                        _ShowSimulationConfigPage();
                        break;
                    case "q":
                        break;
                    default:
                        Console.WriteLine($"Wrong choice, please try again");
                        break;
                }
            }

        }

        #endregion//Public Methods

        #region Private Methods-----------------------------------------------

        #region Event Handlers

        //  -   None

        #endregion//Event Handlers

        #region Helpers

        /// <summary>
        /// Show simulation setup page
        /// </summary>
        private void _ShowSimulationConfigPage()
        {
            string ElectoralBodyName = "";
            int numOfCandidates;
            int numOfBbox;
            int numOfVotersPerBbox;
            int numOfPositions;

            Console.WriteLine($"Please Enter the type of electoral body for which the election is being modeled(such as school boards, city councils, etc.) - Must be Alphabetically");
            ElectoralBodyName = _GetValidInput(char.IsLetter);
            Console.WriteLine();

            Console.WriteLine($"Please Enter the number of candidates for the position for which the election will be simulated(Must be Numeric)");
            numOfCandidates = int.Parse(_GetValidInput(char.IsDigit));
            Console.WriteLine();

            Console.WriteLine($"Please Enter number of ballot boxes to be used in the election simulation(Must be Numeric)");
            numOfBbox = int.Parse(_GetValidInput(char.IsDigit));
            Console.WriteLine();

            Console.WriteLine($"Please Enter number of voters per ballot box to be involved in the election simulation(Must be Numeric)");
            numOfVotersPerBbox = int.Parse(_GetValidInput(char.IsDigit));
            Console.WriteLine();

            Console.WriteLine($"Please Enter number of positions that will be involved in the election simulation");
            numOfPositions = int.Parse(_GetValidInput(char.IsDigit));
            Console.WriteLine();

            Console.WriteLine("Simulation was configured successfully");
            Thread.Sleep(2000);

            RunSimulation?.Invoke(ElectoralBodyName, numOfCandidates, numOfBbox, numOfVotersPerBbox, numOfPositions);
        }

        /// <summary>
        /// Validate input according to received callback validation function
        /// </summary>
        /// <param name="isValidCharCallback">Callback function for input validation</param>
        /// <returns></returns>
        private string _GetValidInput(CallbackIsValidChar isValidCharCallback)
        {
            StringBuilder inputBuilder = new StringBuilder();

            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(intercept: true);
                char inputChar = keyInfo.KeyChar;

                if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (inputBuilder.Length > 0)
                    {
                        // Remove the last character from the inputBuilder
                        inputBuilder.Remove(inputBuilder.Length - 1, 1);

                        // Move the cursor back and overwrite the character with a space
                        Console.Write("\b \b");
                    }
                }
                else if (isValidCharCallback(inputChar))
                    {
                        inputBuilder.Append(inputChar);
                        Console.Write(inputChar);
                    }

            } while (keyInfo.Key != ConsoleKey.Enter || inputBuilder.Length < 1);

            return inputBuilder.ToString();
        }

        #endregion//Helpers

        #endregion//Private Methods
    }
}
