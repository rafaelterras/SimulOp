using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgramaMinuta
{
    class Tubulacao : EquipamentoOPI, ITubulacao
    {
        public double comprimento { get; set; }
        public double comprimentoEquivalente { get ; set ; }
        public double diametro { get; set; }
        public string material { get ; set ; }
        public double rugosidade { get; set; }
        public double rugosidadeRelativa { get; set; }
        public double fatorAtrito { get; set; }
        public double elevacao { get; set; }
        public List<Singularidade> listaSingulariedades { get; set ; }
        new private double perdaCarga { get; set; }


        /// <summary>
        /// Insere a perda de carga da tubulação conforme o fluido e vazão
        /// </summary>
        /// <param name="fluido">O Fluido que está na tubulação. </param>
        /// <param name="vazao">A vazão do fluido [m^3/s]. </param>
        public void SetPerdaCarga(Fluido fluido, double vazao)
        {
            this.perdaCarga = CalculaPerdaCarga(fluido, vazao);
        }

        /// <summary>
        /// Retorna a perda de carga na tubulação
        /// </summary>
        /// <returns> A peda de carga na tubulação [m]. </returns>
        public double GetPerdaCarga()
        {
            return this.perdaCarga;
        }

        /// <summary>
        /// Calcula o número de Reyolds
        /// </summary>
        /// <param name="fluido">O Fluido que está na tubulação. </param>
        /// <param name="vazao">A vazão do fluido [m^3/s]. </param>
        /// <returns> O número de Rynolds [adm]. </returns>
        public double CalcReynolds(Fluido fluido, double vazao)
        {
            double re;

            re = (4 * fluido.densidade * vazao) / (Math.PI * fluido.viscosidade * this.diametro);

            return re;
        }
        /// <summary>
        /// Calcula o fator de atrito de acordo com a correlação de Fanning.
        /// </summary>
        /// <param name="fluido">O Fluido que está na tubulação. </param>
        /// <param name="vazao">A vazão do fluido [m^3/s]. </param>
        /// <returns> O fator de atrito [adm]. </returns>
        public double CalcFAtrito(Fluido fluido, double vazao)
        {
            double Re = CalcReynolds(fluido, vazao);
            double A1 = Math.Pow(7 / Re, 0.9);
            double A2 = 0.27 * this.rugosidadeRelativa;
            double A = Math.Pow(-2.475 * Math.Log(A1 + A2), 16);
            double B = Math.Pow((37530 / Re), 16.0);

            double fA1 = Math.Pow(8 / Re, 12);
            double fA2 = 1 / Math.Pow(A + B, 3.0 / 2.0);

            double fA = 2 * Math.Pow(fA1 + fA2, 1.0 / 12.0);

            //Console.WriteLine("fA = {0}", fA);
            
            return fA;
            
        }

        /// <summary>
        /// Cálcula a perda de carga da tubulação
        /// </summary>
        /// <param name="fluido">O Fluido que está na tubulação. </param>
        /// <param name="vazao">A vazão do fluido [m^3/s]. </param>
        /// <returns> A perda de carga [m]. </returns>
        public double CalculaPerdaCarga(Fluido fluido, double vazao)
        {
            double fAtrito = CalcFAtrito(fluido, vazao);
            double comprimetoTotal = this.comprimento + this.comprimentoEquivalente;
            double hf1 = (32 / Math.Pow(Math.PI, 2));
            double hf2 = fAtrito * comprimetoTotal * Math.Pow(vazao, 2) / (Math.Pow(this.diametro, 5.0) * g);

            this.perdaCarga = hf1 * hf2;

            return this.perdaCarga;
        }

        /// <summary>
        /// Cálcula o comprimento equivalente das singularidades
        /// </summary>
        /// <param name="lista">A lista de singularidades da tubulação. </param>
        /// <returns> O comprimento equivalente das singularidades [m]. </returns>
        public void ComprEqSing()
        {
            double comprEq = 0;

            foreach(Singularidade sin in this.listaSingulariedades)
            {
                comprEq = comprEq + sin.comprimentoEqv;
            }

            this.comprimentoEquivalente = comprEq;

        }


        public double CalculaVazao()
        {
            throw new NotImplementedException();
        }
    }
}