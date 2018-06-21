using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulOP.Forms
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

        private void comSingularidadeEBombaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FormsAutoBomba newMDIChild = new Forms.FormsAutoBomba();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void exercicioResolvidoOP1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FormsExercicioOP1 newMDIChild = new Forms.FormsExercicioOP1();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void contínuaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FormsColunaMcCabeThiele newMDIChild = new Forms.FormsColunaMcCabeThiele();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }
    }
}
