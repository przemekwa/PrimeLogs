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
        public static readonly string[] CONFIGFILEVALUES = new[] { "<PrimeLogi>", " <log name=\"LogName\">", "  <location name=\"LocationName\" path=\"\" filter=\"*.txt\" ></location>", " </log>","</PrimeLogi>" };

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

        public static bool CheckConfigFile(string fielPath)
        {
            return File.Exists(fielPath);
        }

        public static FileInfo CreateConfigFile(string filePath)
        {
            File.WriteAllLines(filePath, CONFIGFILEVALUES);

            return new FileInfo(filePath);
        }

        public static void CheckOrCreateConfigFile(string filePath)
        {
            if (!CheckConfigFile(filePath))
            {
                MessageBox.Show(
                    string.Format("Utworzono standardowy plik konfiguracyjny w {0}", CreateConfigFile(filePath).FullName),
                    "Informacja",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
    }
}
