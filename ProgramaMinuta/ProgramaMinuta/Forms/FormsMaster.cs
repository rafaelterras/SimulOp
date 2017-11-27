using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramaMinuta
{
    public partial class FormsMaster : Form
    {
        public FormsMaster()
        {
            InitializeComponent();
        }

        private void FormsMaster_Load(object sender, EventArgs e)
        {
            Forms.FormsInício newMDIChild = new Forms.FormsInício();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void simplesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FormsModelOp newMDIChild = new Forms.FormsModelOp();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }
    }
}
