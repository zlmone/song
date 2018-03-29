#region Usings
#endregion

namespace WSH.Web.Common.Google
{
    /// <summary>
    /// Designates an address
    /// </summary>
    public class Address : ILocation
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public Address() { }

        #endregion

        #region Properties

        /// <summary>
        /// Physical address
        /// </summary>
        public virtual string PhysicalAddress { get; set; }

        #endregion

        #region Functions

        /// <summary>
        /// Converts the location to a string
        /// </summary>
        /// <returns>The address as a string</returns>
        public override string ToString()
        {
            return PhysicalAddress;
        }

        #endregion
    }
}