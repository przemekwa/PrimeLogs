// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogInfo.cs">GPL</copyright>
// <author>Przemek Walkowski</author>
// <date>15/05/2014</date>
// <summary>
// LogInfo
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PrimeLogi
{
    using System.Collections.Generic;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class LogInfo
    {
        public string Name { get; set; }

        public List<Location> locationList { get; set; } 

        public LogInfo()
        {
            locationList = new List<Location>();
        }
    }
}
