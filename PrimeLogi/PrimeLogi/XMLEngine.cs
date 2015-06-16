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
    using System.Diagnostics;
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
               
                foreach (XmlNode logNode in xml.GetElementsByTagName("log"))
                {
                        var logInfo = new LogInfo
                        {
                            Name = logNode.Attributes["name"].InnerText,
                        };

                        foreach (XmlNode locationNode in logNode.SelectNodes("location"))
                        {
                                var locationInfo = new LocationInfo
                                {
                                    Name = locationNode.Attributes["name"].InnerText,
                                    Path = locationNode.Attributes["path"].InnerText,
                                    Filter = locationNode.Attributes["filter"].InnerText
                                };
                                logInfo.locationList.Add(locationInfo);
                        }

                        logList.Add(logInfo);
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
