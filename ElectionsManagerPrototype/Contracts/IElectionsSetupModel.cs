using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectionsManagerPrototype.Contracts
{
    /// <summary>
    /// Elections Setup Model contract
    /// </summary>
    public interface IElectionsSetupModel
    {
        #region Public Methods------------------------------------------------

        /// <summary>
        /// Run simulation
        /// </summary>
        void RunSimulation(string ElectoralBodyName, int numOfCandidates, int numOfBbox, int numOfVotersPerBbox, int numOfPositions);

        #endregion//Public Methods
    }
}
