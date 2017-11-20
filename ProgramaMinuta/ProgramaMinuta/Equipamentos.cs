using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgramaMinuta
{
    internal abstract class Equipamentos
    {
        /// <summary>
        /// Constante: Aceleração da gravidade [m/s^2]
        /// </summary>
        public double g = 9.80665; // aceleração da gravidade [m/s^2]

        /// <summary>
        /// Perda de carga no equipamento (m)
        /// </summary>
        public double perdaCarga; 
            
        /// <summary>
        /// Calcula a perda de carga no equpamento
        /// </summary>
        public virtual double CalculaPerdaCarga()
        {
            throw new System.NotImplementedException();
        }
    }
}