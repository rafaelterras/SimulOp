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
        private double condutividade;

        public double Rugosidade { get => rugosidade; }
        public double Condutividade { get => condutividade; }

        public MaterialTubulacao(double rugosidade, double condutividade, string componente = "NA") : base(componente)
        {
            this.rugosidade = rugosidade;
            this.condutividade = condutividade;
        }
    }
}
