﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PrimeLogi.cs">GPL</copyright>
// </copyright>
// <author>Przemek Walkowski</author>
// <date>15/05/2014</date>
// <summary>
// Object for enviroment log.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PrimeLogi
{
    using System;
    using System.IO;

    /// <summary>
    /// Class for enviroment log.
    /// </summary>
    public class Location
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
        public string[] FilesPathList
        {
            get
            {
                return GetFiles();
            }
        }

        /// <summary>
        /// Gets list of files
        /// </summary>
        /// <returns></returns>
        private string[] GetFiles()
        {
            try
            {
                return Directory.GetFiles(this.Path, this.Filter);
            }
            catch (Exception)
            {
                return new string[0];
            }
        }
    }
}