using System;
using System.Windows.Forms;

namespace SimulOP.Forms
{
    /// <summary>
    /// Forms Popout de ajuda.
    /// </summary>
    public partial class FormsPopOut : Form
    {
        public FormsPopOut(string ajuda)
        {
            InitializeComponent();

            if (ajuda != "")
            {
                txbAjuda.Text = ajuda;
            }
            else
            {
                txbAjuda.Text = "AJUDA NÃO ENCONTRADA!!";
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
