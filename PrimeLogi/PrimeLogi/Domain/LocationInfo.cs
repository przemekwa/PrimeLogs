// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PrimeLogi.cs">GPL</copyright>
// </copyright>
// <author>Przemek Walkowski</author>
// <date>15/05/2014</date>
// <summary>
// Object for enviroment log.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PrimeLogi.Domain
{
    /// <summary>
    /// Class for enviroment log.
    /// </summary>
    public class LocationInfo
    {
        /// <summary>
        /// Gets or sets regular sets. Only [*],[.] and [?] is valid.
        /// </summary>
        public string Filter { get; set; }

        /// <summary>
        /// Gets or sets name for the enviroment 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets path to files
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Gets list of files in path
        /// </summary>
        public string[] FilesPathList => Helper.GetFiles(this.Path, this.Filter);
    }
}