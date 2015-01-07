// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XEngine.cs">GPL</copyright>
// <author>Przemek Walkowski</author>
// <date>15/05/2014</date>
// <summary>
// XML parser
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PrimeLogi
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.Xml;

    /// <summary>
    /// Main class for XML operation.
    /// </summary>
    public class XMLEngine
    {
        /// <summary>
        /// Get Log node form xml file.
        /// </summary>
        /// <returns>List of log</returns>
        public List<LogInfo> GetLogs()
        {
            var logList = new List<LogInfo>();

            var xml = new XmlDocument();
            
            try
            {
                xml.Load("PrimeLogi.xml");
               
                var logsNodes = xml.GetElementsByTagName("log");

                foreach (XmlNode logNode in logsNodes)
                {
                        var log = new LogInfo
                        {
                            Name = logNode.Attributes["name"].InnerText,
                        };

                        var locationNodes = logNode.SelectNodes("location");

                        foreach (XmlNode locationNode in locationNodes)
                        {
                                var sro = new Location
                                {
                                    Name = locationNode.Attributes["name"].InnerText,
                                    Path = locationNode.Attributes["path"].InnerText,
                                    Filter = locationNode.Attributes["filter"].InnerText
                                };
                                log.locationList.Add(sro);
                        }

                        logList.Add(log);
                }
            }
            catch (Exception el)
            {
                MessageBox.Show(el.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return logList;
        }
    }
}
