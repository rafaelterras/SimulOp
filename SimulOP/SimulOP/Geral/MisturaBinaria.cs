using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulOP
{
    /// <summary>
    /// Representa uma mistura binária de componentes puros
    /// </summary>
    public class MisturaBinaria
    {
        private FluidoIdealOPIII fluidoLK;
        private FluidoIdealOPIII fluidoHK;
        private string[] componentes = new string[2];
        private double pressao;
        private double[] composicaoLiq = new double[2];
        private double[] composicaoVap = new double[2];
        private double alpha;
        private double temperatura;

        /// <summary>
        /// Fluido puro mais volátil (Light Key)
        /// </summary>
        public FluidoIdealOPIII FluidoLK { get => fluidoLK; }
        /// <summary>
        /// Fluido puro menos volátil (Heavy Key)
        /// </summary>
        public FluidoIdealOPIII FluidoHK { get => fluidoHK; }
        /// <summary>
        /// Nomes dos componentes puros da mistura [Light Ky, Heavy Key]
        /// </summary>
        public string[] Componentes { get => componentes; }
        /// <summary>
        /// Pressão da mistura [Pa]
        /// </summary>
        public double Pressao { get; set; }
        /// <summary>
        /// Composição da fase líquida [Light Key, Heahy Key]
        /// </summary>
        public double[] ComposicaoLiq
        {
            get => composicaoLiq;
            set
            {
                this.composicaoLiq = value;
            }
            
        }

        /// <summary>
        /// Composição da fase vapor [Light Key, Heahy Key]
        /// </summary>
        public double[] ComposicaoVap { get => composicaoVap; set => composicaoVap = value; }
        /// <summary>
        /// Coeficiente de volatividade relativa Alpha_{1,2}
        /// </summary>
        public double Alpha { get => alpha; }
        /// <summary>
        /// Temperatura da mistura
        /// </summary>
        public double Temperatura
        {
            get => temperatura;
            set // Seta a temperatura para a misturas e para os componentes puros
            {
                this.temperatura = value;
                fluidoLK.Temperatura = value;
                FluidoHK.Temperatura = value;
            }
        }

        /// <summary>
        /// Constructor para a mistura binária
        /// </summary>
        /// <param name="fluidoLK">Fluido puro mais volátil (Light Key)</param>
        /// <param name="fluidoHK">Fluido puro menos volátil (Heavy Key)</param>
        /// <param name="cLK">Concentração do Light Ky na fase líquida</param>
        /// <param name="temperatura">Temperatura da mistura [K]</param>
        /// <param name="pressao">Pressão da mistura [Pa]</param>
        public MisturaBinaria(FluidoIdealOPIII fluidoLK, FluidoIdealOPIII fluidoHK, double cLK, double temperatura, double pressao)
        {
            // Fluido mais volátil
            this.fluidoLK = fluidoLK;
            this.componentes[0] = fluidoLK.Material.Componente;

            // Fluido menos volátil
            this.fluidoHK = fluidoHK;
            this.componentes[1] = fluidoHK.Material.Componente;

            // Propriedades termodinâmicas, irão também alterar nos fluido puros (FluidoLK e FluidoHK)
            this.Temperatura = temperatura;
            this.Pressao = pressao;

            // Composisão na fase Líquida
            this.composicaoLiq = new double[2] { cLK, 1 - cLK };

            // Atualiza a composição na fase Vapor da mistura
            this.CalculaVapRaoult(cLK);
        }

        /// <summary>
        /// Calcula a concentração na fase vapor com base na concentração do Light Key na fase líquida
        /// Assumindo a Lei de Raoult (Gás e Líquido ideais)
        /// </summary>
        /// <param name="xLK">Concentração do Light Key na fase Líquida</param>
        public void CalculaVapRaoult(double xLK)
        {
            // Seta os valores das concentrações na fase Líquida
            this.composicaoLiq[0] = xLK;
            this.composicaoLiq[1] = 1 - xLK;

            // Calcula e atualiza o coeficiente de volatividade relativa
            this.alpha = fluidoLK.PresaoVapor / fluidoHK.PresaoVapor;
            
            // Calcula com base na equação de Raoult a cencentração do Light Key 
            double yLK = (this.alpha * xLK) / (1 + xLK * (this.alpha - 1));

            this.composicaoVap[0] = yLK;
            this.composicaoVap[1] = yLK - 1;
        }

        public double CalculaVap(double xLK)
        {
            // Calcula e atualiza o coeficiente de volatividade relativa
            this.alpha = fluidoLK.PresaoVapor / fluidoHK.PresaoVapor;

            // Calcula com base na equação de Raoult a cencentração do Light Key 
            double yLK = (this.alpha * xLK) / (1 + xLK * (this.alpha - 1));

            return yLK;
        }

    }
}
