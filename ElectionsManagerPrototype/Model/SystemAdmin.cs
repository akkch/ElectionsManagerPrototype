using static ElectionsManagerPrototype.Model.User;

namespace ElectionsManagerPrototype.Model
{
    /// <summary>
    /// Elections Management System Administrator Class
    /// </summary>
    public class SystemAdmin : User
    {
        #region Constructors--------------------------------------------------

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="name">System Admin name</param>
        /// <param name="id">System Admin Israeli ID</param>
        /// <param name="address">System Admin address</param>
        /// <param name="phone">System Admin Israeli phone</param>
        public SystemAdmin(string name, string id, Address address, string phone, Role role) : base(name, id, address, phone, role)
        {
        }

        #endregion//Constructors

    }
}
