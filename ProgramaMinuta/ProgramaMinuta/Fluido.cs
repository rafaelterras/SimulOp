using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgramaMinuta
{
    public class Fluido
    {
        /// <summary>
        /// Se é um fluido newtoniano ("newton"), ou é não newtoniano ("naoNewton")
        /// </summary>
        public string clasificacao { get; set; }
   
        /// <summary>
        /// Densidade do fluido (kg/m^3)
        /// </summary>
        public double densidade { get; set; }
       
        /// <summary>
        /// Temperatura do fluido (ºC)
        /// </summary>
        public double temperatura { get; set; }

        /// <summary>
        /// Composição de cada componente em mol
        /// </summary>
        public Dictionary<string, double> composicao { get; set; }

        /// <summary>
        /// Pressão do fluido (Pa)
        /// </summary>
        public double pressao { get; set; }

        /// <summary>
        /// Indices do polinomio em função da temperatur (a0 + a1 + a2 + ...)
        /// </summary>
        public List<double> calorEspecifico { get; set; }
        
        /// <summary>
        /// Viscosidade em Pa*s
        /// </summary>
        public double viscosidade { get; set; }
 
        /// <summary>
        /// Entalpia (J)
        /// </summary>
        public double entalpia { get; set; }
        
        /// <summary>
        /// Pressão de vapor do fluido (Pa)
        /// </summary>
        public double presaoVapor { get; set; }
    }
}