using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulOP
{
    public class MaterialTubulacao : Material
    {
        private double rugosidade;

        public double Rugosidade { get => rugosidade; }

        public MaterialTubulacao(double rugosidade, string componente = "NA") : base(componente)
        {
            this.rugosidade = rugosidade;
        }
    }
}
