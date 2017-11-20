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
        /// <summary>
        /// Calcula o fator de atrito de acordo com a correlação de [CHECAR A CORRELAÇÃO!!!]
        /// </summary>
        /// <param name="fluido">O Fluido que está na tubulação. </param>
        /// <param name="vazao">A vazão do fluido [m^3/s]. </param>
        /// <returns> O fator de atrito [adm]. </returns>
        public double CalcFAtrito(Fluido fluido, double vazao)
        {
            double Re = CalcReynolds(fluido, vazao);
            double A = Math.Pow(-2.475 * Math.Log(Math.Pow(7 / Re, 0.9) + 0.27 * (this.RugosidadeRelativa)), 16);
            double B = Math.Pow((37560 / Re), 16);

            double fA = 2 * Math.Pow(Math.Pow(8 / Re, 12) + (1 / Math.Pow(A + B, 3.0 / 2.0)), 1.0 / 12.0);

            return fA;
        }


        public double CalculaVazao()
        {
            throw new NotImplementedException();
        }
    }
}