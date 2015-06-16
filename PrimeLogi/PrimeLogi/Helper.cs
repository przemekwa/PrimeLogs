using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PrimeLogi
{
    public static class Helper
    {
        /// <summary>
        /// Gets list of files
        /// </summary>
        /// <returns></returns>
        public  static string[] GetFiles(string path, string filter)
        {
            try
            {
                return Directory.GetFiles(path, filter);
            }
            catch (Exception)
            {
                return new string[0];
            }
        }
    }
}
