#region Usings
using System.Globalization;
 
#endregion

namespace WSH.Web.Common.Google
{
    /// <summary>
    /// Location based on longitude and latitude
    /// </summary>
    public class LongLat:ILocation
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public LongLat() { }

        #endregion

        #region Properties

        /// <summary>
        /// Longitude
        /// </summary>
        public virtual double Longitude { get; set; }

        /// <summary>
        /// Latitude
        /// </summary>
        public virtual double Latitude { get; set; }

        #endregion

        #region Functions

        /// <summary>
        /// Exports the location as a string
        /// </summary>
        /// <returns>String of the location</returns>
        public override string ToString()
        {
            return Latitude.ToString("#.######", CultureInfo.InvariantCulture) + "," + Longitude.ToString("#.######", CultureInfo.InvariantCulture);
        }

        #endregion
    }
}
