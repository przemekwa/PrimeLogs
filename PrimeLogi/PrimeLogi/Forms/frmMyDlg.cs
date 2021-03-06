﻿

using PrimeLogi.Domain;

namespace PrimeLogi
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using NppPluginNET;

    public partial class frmMyDlg : Form
    {
        /// <summary>
        /// List of all control 
        /// </summary>
        private readonly List<Control> controlList;

        /// <summary>
        /// List of all logs in config file
        /// </summary>
        private List<LogInfo> logList;

        /// <summary>
        /// Xml engine
        /// </summary>
        private XmlEngine xmlEngine;

        /// <summary>
        /// 
        /// </summary>
        private int indexFromLogList { get; set; }
   
        public frmMyDlg()
        {
            InitializeComponent();

            this.xmlEngine = new XmlEngine();
            this.controlList = new List<Control>();
            this.logList = new List<LogInfo>();

            RefreshUi();
        }

        public void RefreshUi()
        {
            comboBoxLogsList.Items.Clear();

            logList = this.xmlEngine.GetLogs();

            logList.ForEach(log => comboBoxLogsList.Items.Add(log.Name));
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexFromLogList = this.comboBoxLogsList.SelectedIndex;

            this.RemoveControl();
            
            CreateControl(logList[indexFromLogList].LocationList);
       }

        private void MouseDoubleClickOnLocationClick(object sender, MouseEventArgs mouseEventArgs)
        {
            var lb = sender as ListBox;

            var fileLocationIndex = lb.IndexFromPoint(mouseEventArgs.Location);

            foreach (var location in logList[this.indexFromLogList].LocationList)
            {
                if (location.Name != lb.Name) continue;

                if (fileLocationIndex <= location.FilesPathList.Length && fileLocationIndex != ListBox.NoMatches)
                {
                    var path = location.FilesPathList[fileLocationIndex];
                    
                    Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_DOOPEN, 0, path);

                    MessageBox.Show($"Node {lb.Name} load successful.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    break;
                }
            } 
        }

        private void RemoveControl()
        {
            foreach (var o in controlList)
            {
                if (this.tableLayoutPanel1.Controls.Contains(o))
                {
                    this.tableLayoutPanel1.Controls.Remove(o);
                    o.Dispose();
                }
            }
        }

        private void CreateControl(IList<LocationInfo> locationList)
        {
            for (var i = 0; i < locationList.Count; i++)
            {
                var gb = new GroupBox
                {
                    Text = locationList[i].Name,
                    Margin = new Padding(0,0,20,0),
                    Anchor = (AnchorStyles.Right | AnchorStyles.Left) 
                };

                var lb = new ListBox
                {
                    Dock = DockStyle.Fill,
                    Name = locationList[i].Name
                };

                lb.MouseDoubleClick += MouseDoubleClickOnLocationClick;

                foreach (var filePath in locationList[i].FilesPathList)
                {
                    lb.Items.Add(filePath.Substring(filePath.LastIndexOf(@"\", StringComparison.InvariantCulture) + 1));
                }

                gb.Controls.Add(lb);
                
                tableLayoutPanel1.Controls.Add(gb, 0, i);
               
                controlList.Add(gb);
            }

            var emptyPanel = new Panel();

            controlList.Add(emptyPanel);

            tableLayoutPanel1.Controls.Add(emptyPanel, 0, locationList.Count);
        }

        private void frmMyDlg_Load(object sender, EventArgs e)
        {

        }
    }
}
