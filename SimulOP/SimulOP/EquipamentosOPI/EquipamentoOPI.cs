﻿using System;

namespace SimulOP
{
    /// <summary>
    /// Classe abstrata para representar todos os equipamentos de OPI.
    /// </summary>
    public abstract class EquipamentoOPI : Equipamentos
    {
        /// <summary>
        /// Enum para representar o número Schedule de uma tubulação.
        /// </summary>
        public enum SchNum
        {
            Sch20 = 0,
            Sch40 = 1,
            Sch80 = 2,
            Sch100 = 3,
        }

        /// <summary>
        /// Enum para representar diametros de tubulações em polegadas (para uso em conjunto do número Schedule).
        /// </summary>
        public enum DiamPol
        {
            pol1 = 0,
            pol1_5 = 1,
            pol2 = 2,
            pol4 = 3,
            pol10 = 4,
            pol20 = 5,
        }

        /// <summary>
        /// Calcula o número de Reyolds.
        /// </summary>
        /// <param name="densidade">A densidade do fluido [Kg/m^3].</param>
        /// <param name="viscosidade">A viscosidade do fluido [Pa*s].</param>
        /// <param name="vazao">A vazão do fluido [m^3/s].</param>
        /// <param name="diametro">O diametro da tubulação [m].</param>
        /// <returns> O número de Rynolds [adm].</returns>
        public virtual double CalcReynolds(double densidade, double viscosidade, double vazao, double diametro)
        {
            double Re;

            Re = (4 * densidade * vazao) / (Math.PI * viscosidade * diametro);

            return Re;
        }
    }
}