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
        public string clasificacao
        {
            get => default(string);
            set
            {
            }
        }

        /// <summary>
        /// Densidade do fluido (kg/m^3)
        /// </summary>
        public double densidade
        {
            get => default(int);
            set
            {
            }
        }

        /// <summary>
        /// Temperatura do fluido (ºC)
        /// </summary>
        public double temperatura
        {
            get => default(int);
            set
            {
            }
        }

        /// <summary>
        /// Composição de cada componente em mol
        /// </summary>
        public System.Collections.Generic.Dictionary<string, double> composicao
        {
            get => default(int);
            set
            {
            }
        }

        /// <summary>
        /// Pressão do fluido (Pa)
        /// </summary>
        public double pressao
        {
            get => default(int);
            set
            {
            }
        }

        /// <summary>
        /// Indices do polinomio em função da temperatur (a0 + a1 + a2 + ...)
        /// </summary>
        public List<double> calorEspecifico
        {
            get => default(int);
            set
            {
            }
        }

        /// <summary>
        /// Indices do polinomio em função da temperatur (a0 + a1 + a2 + ...)
        /// </summary>
        public List<double> viscosidade
        {
            get => default(int);
            set
            {
            }
        }

        /// <summary>
        /// Entalpia (J)
        /// </summary>
        public double entalpia
        {
            get => default(int);
            set
            {
            }
        }

        /// <summary>
        /// Pressão de vapor do fluido (Pa)
        /// </summary>
        public double presaoVapor
        {
            get => default(int);
            set
            {
            }
        }
    }
}