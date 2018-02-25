using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimulOP
{
    class Valvula : Singularidade
    {
        private double comprimentoEqv;
        private string tipo = "Valvula";

        /// <summary>
        /// Constructor para o objeto Valvula
        /// </summary>
        /// <param name="comprimentoEqv">Comprimento equivalente da singulariedade [m]</param>
        public Valvula(double comprimentoEqv) : base(comprimentoEqv, "Valvula")
        {
            this.comprimentoEqv = comprimentoEqv;
        }
    }
}