using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PrimeLogi
{
    public static class Helper
    {
        public static readonly string CONFIGFILENAME = "PrimeLogi.xml";

        /// <summary>
        /// Gets list of files
        /// </summary>
        /// <returns></returns>
        [DebuggerNonUserCode]
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

        public static void CheckOrCreateConfigFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Dispose();

                var fileInfo = new FileInfo(filePath);

                MessageBox.Show(
                    string.Format(
                        "Utworzono plik konfiguracyjny. Lokalizacja pliku {0}", fileInfo.FullName),
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
    }
}
