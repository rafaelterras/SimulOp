using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimulOP
{
    public class Fluido
    {
        #region Inicialização das variaveis e do Constructor
        private double densidade;
        private double temperatura;
        private string componente;
        private double pressao;
        private double[] calorEspecifico;
        private double viscosidade;
        private double entalpia;
        private double presaoVapor;
        private double[] coefAntoine;

        /// <summary>
        /// Densidade do fluido [kg/m^3]
        /// </summary>
        public double Densidade { get => densidade; set => densidade = value; }
       
        /// <summary>
        /// Temperatura do fluido [ºC]
        /// </summary>
        public double Temperatura { get => temperatura; set => temperatura = value; }

        /// <summary>
        /// Componente puro do fluido (ex. Benzeno, Água...)
        /// </summary>
        public string Componente { get => componente; set => componente = value; }

        /// <summary>
        /// Pressão do fluido [Pa]
        /// </summary>
        public double Pressao { get => pressao; set => pressao = value; }

        /// <summary>
        /// Indices do polinomio em função da temperatur (a0 + a1 + a2 + ...)
        /// </summary>
        public double[] CalorEspecifico { get => calorEspecifico; set => calorEspecifico = value; }
        
        /// <summary>
        /// Viscosidade [Pa*s]
        /// </summary>
        public double Viscosidade { get => viscosidade; set => viscosidade = value; }
 
        /// <summary>
        /// Entalpia [J]
        /// </summary>
        public double Entalpia { get => entalpia; set => entalpia = value; }
        
        /// <summary>
        /// Pressão de vapor do fluido [Pa]
        /// </summary>
        public double PresaoVapor { get => presaoVapor; set => presaoVapor = value; }

        /// <summary>
        /// Coeficiente de Antoine para calculo de pressão de vapor [A,B,C]
        /// </summary>
        public double[] CoefAntoine { get => coefAntoine; set => coefAntoine = value; }

        /// <summary>
        /// Constructor para o objeto Fluido, levando em conta os valores necessário para o cálculo de bomba
        /// </summary>
        /// <param name="densidade">Densidade do fluido [kg/m^3]</param>
        /// <param name="viscosidade">Viscosidade [Pa*s]</param>
        public Fluido(double densidade, double viscosidade)
        {
            this.densidade = densidade;
            this.viscosidade = viscosidade;
        }

        /// <summary>
        /// Constructor para o objeto Fluido, levando em conta os valores necessário para os de OPIII
        /// </summary>
        /// <param name="temperatura">Temperatura do Fluido [K]</param>
        /// <param name="pressao">Pressão do Fluido [Pa]</param>
        /// <param name="coefAntoine">Coeficientes de Antoine [A,B,C]</param>
        public Fluido(double temperatura, double pressao, double[] coefAntoine)
        {
            this.temperatura = temperatura;
            this.pressao = pressao;
            this.coefAntoine = coefAntoine;
            CalculaPvapAntoine();
        }

        #endregion

        /// <summary>
        /// Calculo da pressão de vapor pela equação de Antonine, para liquidos e gases ideais
        /// </summary>
        public void CalculaPvapAntoine()
        {
            double Pvap = Math.Pow(10.0, this.coefAntoine[0] - (this.coefAntoine[1] / (this.coefAntoine[2] + this.temperatura)));

            this.presaoVapor = Pvap;
        }

    }
}