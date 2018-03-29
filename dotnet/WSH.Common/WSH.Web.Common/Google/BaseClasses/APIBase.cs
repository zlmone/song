#region Usings

#endregion

namespace WSH.Web.Common.Google
{
    /// <summary>
    /// Google API base class
    /// </summary>
    public abstract class APIBase
    {
        #region Properties

        /// <summary>
        /// API Key
        /// </summary>
        public virtual string Key { get; set; }

        /// <summary>
        /// API Location
        /// </summary>
        public abstract string APILocation { get; }

        /// <summary>
        /// Should this use https?
        /// </summary>
        public virtual bool UseHTTPS { get; set; }

        #endregion

        #region Functions

        /// <summary>
        /// Converts the API base class to a string
        /// </summary>
        /// <returns>The API base class as a string</returns>
        public override string ToString()
        {
            return string.IsNullOrEmpty(Key) ? "" : ("&key=" + Key);
        }

        #endregion
    }
}
