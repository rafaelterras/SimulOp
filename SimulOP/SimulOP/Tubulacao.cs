using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimulOP
{
    class Tubulacao : EquipamentoOPI, ITubulacao
    {
        #region Inicialização das variaveis e do Constructor
        private double comprimento;
        private double comprimentoEquivalente;
        private double diametro;
        private string material;
        private double rugosidade;
        private double rugosidadeRelativa;
        private double fatorAtrito;
        private double elevacao;
        private List<Singularidade> listaSingulariedades;
        private double perdaCarga;

        /// <summary>
        /// Comprimento da tubulação [m]
        /// </summary>
        public double Comprimento { get => comprimento; set => comprimento = value; }

        /// <summary>
        /// Comprimento equivalente das Singularidades da tubulação [m]
        /// </summary>
        public double ComprimentoEquivalente { get => comprimentoEquivalente; }

        /// <summary>
        /// Diametro da tubulação [m]
        /// </summary>
        public double Diametro { get => diametro; set => diametro = value; }

        /// <summary>
        /// Material que a tubulação é feita
        /// </summary>
        public string Material { get => material; set => material = value; }

        /// <summary>
        /// Rugosidade da tubulação [m]
        /// </summary>
        public double Rugosidade { get => rugosidade; set => rugosidade = value; }
        
        /// <summary>
        /// Rugosidade relativa da tubulação
        /// </summary>
        public double RugosidadeRelativa { get => rugosidadeRelativa; set => rugosidadeRelativa = value; }

        /// <summary>
        /// Fator de atrito da tubulação, depende das condições do escoamento, [m]
        /// </summary>
        public double FatorAtrito { get => fatorAtrito; set => fatorAtrito = value; }

        /// <summary>
        /// Diferença de altura entre o começo e o fim da tubulação [m]
        /// </summary>
        public double Elevacao { get => elevacao; set => elevacao = value; }

        /// <summary>
        /// Lista de singularidades que estão na tubulação
        /// </summary>
        internal List<Singularidade> ListaSingulariedades
        {
            get => listaSingulariedades;
            set
            {
                listaSingulariedades = value;
                this.CalculaComprimentoEquiSing();
            }
        }

        /// <summary>
        /// Perda de carga da tubulação, depende das condições do escoamento, [m]
        /// </summary>
        public double PerdaCarga { get => perdaCarga; set => perdaCarga = value; }

        /// <summary>
        /// Constructor para o objeto Tubulação. Checar se é só isso que realmente é necessário/faz sentido inicializar
        /// </summary>
        /// <param name="diametro">Diametro da tubulação [m]</param>
        /// <param name="comprimento">Comprimento da tubulação [m]</param>
        /// <param name="rugosidade">Rugosidade da tubulação [m]</param>
        /// <param name="elevacao">Diferença de altura entre o começo e o fim da tubulação [m]</param>
        public Tubulacao(double diametro, double comprimento, double rugosidade, double elevacao)
        {
            this.diametro = diametro;
            this.comprimento = comprimento;
            this.rugosidade = rugosidade;
            this.elevacao = elevacao;
            this.rugosidadeRelativa = rugosidade / diametro;
        }
        #endregion

        /// <summary>
        /// Calcula o número de Reyolds
        /// </summary>
        /// <param name="fluido">O Fluido que está na tubulação. </param>
        /// <param name="vazao">A vazão do fluido [m^3/s]. </param>
        /// <returns> O número de Rynolds [adm]. </returns>
        public double CalculaReynolds(Fluido fluido, double vazao)
        {
            double re;

            re = (4 * fluido.Densidade * vazao) / (Math.PI * fluido.Viscosidade * this.Diametro);

            return re;
        }
        /// <summary>
        /// Calcula o fator de atrito de acordo com a correlação de Fanning.
        /// </summary>
        /// <param name="fluido">O Fluido que está na tubulação. </param>
        /// <param name="vazao">A vazão do fluido [m^3/s]. </param>
        /// <returns> O fator de atrito [adm]. </returns>
        public double CalculaFAtrito(Fluido fluido, double vazao)
        {
            double Re = CalculaReynolds(fluido, vazao);
            double A1 = Math.Pow(7 / Re, 0.9);
            double A2 = 0.27 * this.RugosidadeRelativa;
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
            double fAtrito = CalculaFAtrito(fluido, vazao);
            double comprimetoTotal = this.Comprimento + this.ComprimentoEquivalente;
            double hf1 = (32 / Math.Pow(Math.PI, 2));
            double hf2 = fAtrito * comprimetoTotal * Math.Pow(vazao, 2) / (Math.Pow(this.Diametro, 5.0) * g);

            this.PerdaCarga = hf1 * hf2;

            //Console.WriteLine("===>Preda carga: {0}",this.perdaCarga);

            return this.PerdaCarga;
        }

        /// <summary>
        /// Cálcula o comprimento equivalente das singularidades
        /// </summary>
        /// <returns> O comprimento equivalente das singularidades [m]. </returns>
        public void CalculaComprimentoEquiSing()
        {
            double comprEq = 0;

            foreach(Singularidade sin in this.ListaSingulariedades)
            {
                comprEq = comprEq + sin.ComprimentoEqv;
            }

            this.comprimentoEquivalente = comprEq;

        }
        
        public double CalculaVazao()
        {
            throw new NotImplementedException();
        }
    }
}