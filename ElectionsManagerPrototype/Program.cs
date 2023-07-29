using ElectionsManagerPrototype.Presenters;
using ElectionsManagerPrototype.Simulators;
using ElectionsManagerPrototype.UI;
using System;

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
