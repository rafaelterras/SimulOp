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
    public partial class FormsTrocadorOleoAPI : Form
    {
        private MaterialOleoAPI oleoQuente;
        private FluidoOPII fluidoQuente;

        public FormsTrocadorOleoAPI()
        {
            InitializeComponent();
        }

        void CalculaTudo()
        {
            oleoQuente = new MaterialOleoAPI(Convert.ToDouble(numericUpDown1.Value), 10.0);
            fluidoQuente = new FluidoOPII(oleoQuente, 10.0);

            

        }
    }
}
