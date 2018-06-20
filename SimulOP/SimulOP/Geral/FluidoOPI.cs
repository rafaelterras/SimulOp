using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimulOP
{
    public class FluidoOPI
    {
        #region Inicialização das variaveis e do Constructor
        private MaterialFluidoOPI material;

        /// <summary>
        /// Material do fluido (seguindo a IMaterialFluidoOPI)
        /// </summary>
        public MaterialFluidoOPI Material { get => material; }
                      
        /// <summary>
        /// Constructor para o objeto Fluido, levando em conta os valores necessário para o cálculo de bomba
        /// </summary>
        /// <param name="densidade">Densidade do fluido [kg/m^3]</param>
        /// <param name="viscosidade">Viscosidade [Pa*s]</param>
        public FluidoOPI(MaterialFluidoOPI material)
        {
            this.material = material;
        }

        public FluidoOPI(double densidade, double viscosidade)
        {
            material = new MaterialFluidoOPI("[Não especificado]", densidade, viscosidade);
        }


        #endregion

        public double ConvertePressaoEmM(double pressao)
        {
            double pressaoM;

            pressaoM = pressao / (this.material.Densidade * Equipamentos.g);
            return pressaoM;
        }

    }
}