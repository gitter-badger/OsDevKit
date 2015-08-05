using Newtonsoft.Json;
using OsDevKit.UI;
using OsDevKit.UI.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OsDevKit
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void fileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var f = new Editor();
            f.MdiParent = this;
            f.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var f = new ProjectView();
            f.MdiParent = this;
            f.Show();

            var f1 = new Output();
            f1.MdiParent = this;
            f1.Show();
        }

        private void projectViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new ProjectView();
            f.MdiParent = this;
            f.Show();
        }

        private void projectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dlg = new New_Project();
            dlg.ShowDialog();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Project File (*.proj)|*.proj";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Global.CurrentProjectFile = JsonConvert.DeserializeObject<ProjectFile>(File.ReadAllText(dlg.FileName));
                Global.CurrentProjectFilePath = new FileInfo (dlg.FileName).DirectoryName;
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Compiler.Compile();
        }

        private void outputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new Output();
            f.MdiParent = this;
            f.Show();
        }

        private async void toolStripButton2_Click(object sender, EventArgs e)
        {
            var f = new Debug();
            f.MdiParent = this;
            f.Show();
            Global.SerialPipe.StartPipe();
            

        }

        private void debugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new Debug();
            f.MdiParent = this;
            f.Show();
        }
    }
}
