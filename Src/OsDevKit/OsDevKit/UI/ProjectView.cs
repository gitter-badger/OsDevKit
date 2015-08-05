using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OsDevKit.UI
{
    public partial class ProjectView : Form
    {
        public ProjectView()
        {
            InitializeComponent();
        }

        ProjectFile buffer = new ProjectFile();

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Global.CurrentProjectFile != null)
            {
                if (buffer != Global.CurrentProjectFile)
                {
                    treeView1.Nodes.Clear();
                    treeView1.Nodes.Add(Global.CurrentProjectFile.Name);
                    foreach (var i in Global.CurrentProjectFile.Files)
                    {
                        treeView1.Nodes[0].Nodes.Add(i);
                    }
                    buffer = Global.CurrentProjectFile;
                    treeView1.ExpandAll();
                }
            }

        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            bool FoundMdiEditor = false;
            var sel = treeView1.SelectedNode.Text;
            foreach (var i in this.MdiParent.MdiChildren)
            {
                if (i is Editor)
                {
                    if ((i as Editor).FileName == sel)
                    {
                        i.BringToFront();
                        FoundMdiEditor = true;
                    }

                }
            }
            if (!FoundMdiEditor)
            {
                var f = new Editor();
                f.FileName = sel;
                f.MdiParent = this.MdiParent;
                f.Show();
            }


        }
    }
}
