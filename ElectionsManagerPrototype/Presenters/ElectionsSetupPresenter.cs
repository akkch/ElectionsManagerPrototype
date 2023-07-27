
using ElectionsManagerPrototype.Contracts;

namespace ElectionsManagerPrototype.Presenters
{
    /// <summary>
    /// Elections Management App Elections setup presenter
    /// </summary>
    public class ElectionsSetupPresenter
    {
        #region Properties----------------------------------------------------

        /// <summary>
        /// Link to presenter model
        /// </summary>
        private IElectionsSetupModel _Model;

        /// <summary>
        /// Link to presenter view
        /// </summary>
        private IElectionsSetupView _View;

        #endregion//Properties

        #region Constructors--------------------------------------------------

        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="model">Link to presenter model</param>
        /// <param name="view">Link to presenter view</param>
        public ElectionsSetupPresenter(IElectionsSetupModel model, IElectionsSetupView view)
        { 
            _Model= model;
            _View= view;

            _View.RunSimulation += _Model.RunSimulation;
        }

        #endregion//Constructors

        #region Public Methods------------------------------------------------

        /// <summary>
        /// Run presenter
        /// </summary>
        public void Run()
        {
            _View.ShowMainPage();
        }

        #endregion//Public Methods

    }
}
