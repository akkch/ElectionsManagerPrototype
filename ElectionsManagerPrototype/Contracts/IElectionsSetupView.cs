using ElectionsManagerPrototype.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectionsManagerPrototype.Contracts
{
    /// <summary>
    /// Elections Setup View contract
    /// </summary>
    public interface IElectionsSetupView
    {
        #region Events--------------------------------------------------------

        /// <summary>
        /// Run simulation
        /// </summary>
        Action<string, int, int, int, int> RunSimulation { get; set; }

        #endregion//Events

        #region Public Methods------------------------------------------------

        /// <summary>
        /// Show main page
        /// </summary>
        void ShowMainPage();

        #endregion//Public Methods
    }
}
