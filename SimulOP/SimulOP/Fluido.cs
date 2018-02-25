using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimulOP
{
    public class Fluido
    {
        #region Inicialização das variaveis e do Constructor
        private string clasificacao;
        private double densidade;
        private double temperatura;
        private Dictionary<string, double> composicao;
        private double pressao;
        private List<double> calorEspecifico;
        private double viscosidade;
        private double entalpia;
        private double presaoVapor;

        /// <summary>
        /// Se é um fluido newtoniano ("newton"), ou é não newtoniano ("naoNewton")
        /// </summary>
        public string Clasificacao { get => clasificacao; set => clasificacao = value; }
   
        /// <summary>
        /// Densidade do fluido [kg/m^3]
        /// </summary>
        public double Densidade { get => densidade; set => densidade = value; }
       
        /// <summary>
        /// Temperatura do fluido [ºC]
        /// </summary>
        public double Temperatura { get => temperatura; set => temperatura = value; }

        /// <summary>
        /// Composição de cada componente em mol
        /// </summary>
        public Dictionary<string, double> Composicao { get => composicao; set => composicao = value; }

        /// <summary>
        /// Pressão do fluido [Pa]
        /// </summary>
        public double Pressao { get => pressao; set => pressao = value; }

        /// <summary>
        /// Indices do polinomio em função da temperatur (a0 + a1 + a2 + ...)
        /// </summary>
        public List<double> CalorEspecifico { get => calorEspecifico; set => calorEspecifico = value; }
        
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
        /// Constructor para o objeto Fluido. Por enquanto só está sendo necessário os valores para o cálculo de bomba
        /// </summary>
        /// <param name="densidade">Densidade do fluido [kg/m^3]</param>
        /// <param name="viscosidade">Viscosidade [Pa*s]</param>
        public Fluido(double densidade, double viscosidade)
        {
            this.densidade = densidade;
            this.viscosidade = viscosidade;
        }
        #endregion
    }
}