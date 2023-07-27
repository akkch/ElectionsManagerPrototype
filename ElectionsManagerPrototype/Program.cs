using ElectionsManagerPrototype.Model;
using ElectionsManagerPrototype.Presenters;
using ElectionsManagerPrototype.Simulators;
using ElectionsManagerPrototype.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ElectionsManagerPrototype
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ElectionsSetupSimulator electionsSetupSimulator = new ElectionsSetupSimulator();
            ConsoleUI consoleUI = new ConsoleUI();

            ElectionsSetupPresenter SimSetupPresenter = new ElectionsSetupPresenter(electionsSetupSimulator, consoleUI);

            SimSetupPresenter.Run();

            Console.ReadKey();
        }
    }
}
