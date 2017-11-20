using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgramaMinuta
{
    class Tubulacao : EquipamentoOPI, ITubulacao
    {
        public double Comprimento { get; set; }
        public double ComprimentoEquivalente { get ; set ; }
        public double Diametro { get; set; }
        public string Material { get ; set ; }
        public double Rugosidade { get; set; }
        public double RugosidadeRelativa { get; set; }
        public double FatorAtrito { get; set; }
        public List<Singularidade> ListaSingulariedades { get; set ; }

        /// <summary>
        /// Calcula o número de Reyolds
        /// </summary>
        /// <param name="fluido">O Fluido que está na tubulação. </param>
        /// <param name="vazao">A vazão do fluido [m^3/s]. </param>
        /// <returns> O número de Rynolds [adm]. </returns>
        public double CalcReynolds(Fluido fluido, double vazao)
        {
            double re;

            re = (4 * fluido.densidade * vazao) / (Math.PI * fluido.viscosidade * this.Diametro);

            return re;
        }

        public double CalculaVazao()
        {
            throw new NotImplementedException();
        }
    }
}