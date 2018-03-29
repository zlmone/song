#region Usings
using System;
using System.Collections.Generic;
using System.Globalization;
 
#endregion

namespace WSH.Web.Common.Google
{
    /// <summary>
    /// Holds data for displaying a set of markers on a map
    /// </summary>
    public class Markers
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public Markers() 
        { 
            MarkerList = new List<ILocation>(); 
            Size=MarkerSize.Small;
            Color="0xFF0000";
            Label="";
        }

        #endregion

        #region Properties

        /// <summary>
        /// Marker list
        /// </summary>
        public ICollection<ILocation> MarkerList { get;private set; }

        /// <summary>
        /// Marker size
        /// </summary>
        public MarkerSize Size { get; set; }

        /// <summary>
        /// Marker color (24 bit hex color values)
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Single uppercase alphanumeric character
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Custom icon (may be PNG, JPEG, or GIF but PNG is recommended)
        /// </summary>
        public Uri CustomIcon { get; set; }

        /// <summary>
        /// Should a shadow be generated from the custom icon?
        /// </summary>
        public bool CustomIconShadow { get; set; }

        #endregion

        #region Functions

        /// <summary>
        /// Exports the location as an url encoded string
        /// </summary>
        /// <returns>Url encoded string of the location</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase")]
        public override string ToString()
        {
            string ReturnValue = "size:" + Size.ToString().ToLower(CultureInfo.InvariantCulture)
                    + (string.IsNullOrEmpty(Color) ? "" : "|color:" + Color)
                    + (string.IsNullOrEmpty(Label) ? "" : "|label:" + Label.ToUpper(CultureInfo.InvariantCulture))
                    + (CustomIcon==null ? "" : ("|icon:" + CustomIcon + "|shadow:" + CustomIconShadow.ToString().ToLower(CultureInfo.InvariantCulture)));
            foreach (ILocation Marker in MarkerList)
                ReturnValue += "|" + Marker.ToString();
            return "markers=" + ReturnValue;
        }

        #endregion
    }
}
