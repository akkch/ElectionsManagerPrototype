using static ElectionsManagerPrototype.Model.User;

namespace ElectionsManagerPrototype.Model
{
    /// <summary>
    /// Elections Committee Member Class
    /// </summary>
    public class ElComMember : User
    {
        #region Constructors--------------------------------------------------

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="name">Elections Committee Member name</param>
        /// <param name="id">Elections Committee Member Israeli ID</param>
        /// <param name="address">Elections Committee Member address</param>
        /// <param name="phone">Elections Committee Member Israeli phone</param>
        public ElComMember(string name, string id, Address address, string phone, Role role) : base(name, id, address, phone, role)
        {
        }

        #endregion//Constructors

    }
}
