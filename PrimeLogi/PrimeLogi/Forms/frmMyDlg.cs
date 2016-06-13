

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
        private int index { get; set; }
   
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
            index = this.comboBoxLogsList.SelectedIndex;

            RemoveControl();
            
            CreateControl(logList[index].locationList);
       }

        private void MouseDoubleClickOnLocationClick(object sender, MouseEventArgs mouseEventArgs)
        {
            ListBox lb = sender as ListBox;

            int index = lb.IndexFromPoint(mouseEventArgs.Location);
            string name = lb.Name;

            foreach (LocationInfo s in logList[this.index].locationList)
            {
                if (s.Name != lb.Name) continue;

                if (index <= s.FilesPathList.Length && index != ListBox.NoMatches)
                {
                    var path = s.FilesPathList[index];
                    
                    Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_DOOPEN, 0, path);

                    MessageBox.Show(string.Format("Node {0} load successful.", lb.Name), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
