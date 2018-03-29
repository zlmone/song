#region Usings
using System.Collections.Generic;
using System.Globalization;
 
#endregion

namespace WSH.Web.Common.Google
{
    /// <summary>
    /// Static Maps API helper
    /// </summary>
    public class Map:APIBase
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public Map()
            : base()
        {
            Zoom = 12;
            Width = 100;
            Height = 100;
            Scale = 1;
            Format = ImageFormat.PNG;
            MapType = MapType.RoadMap;
            Sensor = false;
            Markers = new List<Markers>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// API location
        /// </summary>
        public override string APILocation { get { return (UseHTTPS ? "https://" : "http://") + "maps.googleapis.com/maps/api/staticmap"; } }

        /// <summary>
        /// Center of the map
        /// </summary>
        public ILocation Center { get; set; }

        /// <summary>
        /// Zoom level (should be between 0 and 21
        /// </summary>
        public int Zoom { get; set; }

        /// <summary>
        /// Width of the map
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Height of the map
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Scale of the map (values are 1, 2, and 4 for business customers)
        /// </summary>
        public int Scale { get; set; }

        /// <summary>
        /// Image format
        /// </summary>
        public ImageFormat Format { get; set; }

        /// <summary>
        /// Map type
        /// </summary>
        public MapType MapType { get; set; }

        /// <summary>
        /// Language for the map to use
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Displays appropriate borders based on geo-political sensitivities (uses two-character ccTLD values)
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// A list of markers
        /// </summary>
        public ICollection<Markers> Markers { get; private set; }

        /// <summary>
        /// Determines if a sensor is used to determine the user's location
        /// </summary>
        public bool Sensor { get; set; }

        #endregion

        #region Functions

        /// <summary>
        /// Converts the map data to a URL
        /// </summary>
        /// <returns>The map as a URL</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase")]
        public override string ToString()
        {
            string Result = "sensor=" + Sensor.ToString(CultureInfo.InvariantCulture).ToLower(CultureInfo.InvariantCulture)
                + (Center==null ? "" : ("&center=" + Center.ToString()))
                + "&zoom=" + Zoom.ToString(CultureInfo.InvariantCulture)
                + "&size=" + (Width.ToString(CultureInfo.InvariantCulture) + "x" + Height.ToString(CultureInfo.InvariantCulture))
                + "&scale=" + Scale.ToString(CultureInfo.InvariantCulture)
                + "&format=" + Format.ToString().ToLower(CultureInfo.InvariantCulture)
                + "&maptype=" + MapType.ToString().ToLower(CultureInfo.InvariantCulture)
                + (string.IsNullOrEmpty(Language) ? "" : "&language=" + Language)
                + (string.IsNullOrEmpty(Region) ? "" : "&region=" + Region);
            foreach (Markers Marker in Markers)
                Result += "&" + Marker.ToString();
            Result += base.ToString();
            return APILocation + "?" + Result;
        }

        #endregion
    }
}
