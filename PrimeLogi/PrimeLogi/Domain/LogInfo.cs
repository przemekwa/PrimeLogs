// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogInfo.cs">GPL</copyright>
// <author>Przemek Walkowski</author>
// <date>15/05/2014</date>
// <summary>
// LogInfo
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PrimeLogi.Domain
{
    using System.Collections.Generic;

    /// <summary>
    /// Class with log information
    /// </summary>
    public class LogInfo
    {
        /// <summary>
        /// Gets or sets name of the log
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets list with location
        /// </summary>
        public List<LocationInfo> LocationList { get; set; } 

        public LogInfo()
        {
            LocationList = new List<LocationInfo>();
        }
    }
}
