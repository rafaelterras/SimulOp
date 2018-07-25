using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimulOP
{
    public class Tubulacao : EquipamentoOPI, ITubulacao
    {
        #region Inicialização das variaveis e do Constructor
        protected double comprimento;
        protected double comprimentoEquivalente;
        protected double diametro;
        protected MaterialTubulacao material;
        protected double rugosidadeRelativa;
        protected double fatorAtrito;
        protected double elevacao;
        protected List<ISingularidade> listaSingularidades = new List<ISingularidade>();
        protected double perdaCarga;
        protected string metodoFatrito;

        /// <summary>
        /// Comprimento da tubulação [m]
        /// </summary>
        public double Comprimento { get => comprimento; set => comprimento = value; }

        /// <summary>
        /// Comprimento equivalente das Singularidades da tubulação [m]
        /// </summary>
        public double ComprimentoEquivalente
        {
            get
            {
                CalculaComprimentoEquiSing();
                return comprimentoEquivalente;
            }
        }

        /// <summary>
        /// Diametro da tubulação [m]
        /// </summary>
        public double Diametro
        {
            get { return diametro; }
            set
            {
                if (value > 0)
                {
                    diametro = value;
                    this.rugosidadeRelativa = material.Rugosidade / diametro;
                }
                else
                {
                    throw new Exception($"Diametro do {this.ToString()} < 0!!");
                }
            }
        }


        /// <summary>
        /// Material que a tubulação é feita
        /// </summary>
        public MaterialTubulacao Material { get => material; set => material = value; }
       
        /// <summary>
        /// Rugosidade relativa da tubulação
        /// </summary>
        public double RugosidadeRelativa { get => rugosidadeRelativa; set => rugosidadeRelativa = value; }

        /// <summary>
        /// Fator de atrito (Fanning) da tubulação, depende das condições do escoamento, [m]
        /// </summary>
        public double FatorAtrito { get => fatorAtrito; set => fatorAtrito = value; }

        /// <summary>
        /// Diferença de altura entre o começo e o fim da tubulação [m]
        /// </summary>
        public double Elevacao { get => elevacao; set => elevacao = value; }

        /// <summary>
        /// Lista de singularidades que estão na tubulação
        /// </summary>
        public List<ISingularidade> ListaSingularidades { get => listaSingularidades; }

        /// <summary>
        /// Perda de carga da tubulação, depende das condições do escoamento, [m]
        /// </summary>
        public double PerdaCarga { get => perdaCarga; }

        ///<summary>
        /// Especifica o método utilizado para calcular o fator de atrito.
        /// </summary>
        public string MetodoFatrito { get => metodoFatrito; set => metodoFatrito = value; }

        /// <summary>
        /// Constructor para o objeto Tubulação. Checar se é só isso que realmente é necessário/faz sentido inicializar
        /// </summary>
        /// <param name="diametro">Diametro da tubulação [m]</param>
        /// <param name="comprimento">Comprimento da tubulação [m]</param>
        /// <param name="rugosidade">Rugosidade da tubulação [m]</param>
        /// <param name="elevacao">Diferença de altura entre o começo e o fim da tubulação [m]</param>
        public Tubulacao(double diametro, double comprimento, MaterialTubulacao material, double elevacao, string metodoFatrito = "fanning")
        {
            this.material = material;
            this.Diametro = diametro;
            this.comprimento = comprimento;
            this.elevacao = elevacao;
            this.rugosidadeRelativa = material.Rugosidade / diametro;
            this.metodoFatrito = metodoFatrito;
        }
        #endregion

        /// <summary>
        /// Adiciona a singularidade na lista de lingularidades da tubulação
        /// </summary>
        /// <param name="sin">Singularidade a ser adicionada</param>
        public void AdicionaSingularidade(ISingularidade sin)
        {
            this.listaSingularidades.Add(sin);
            CalculaComprimentoEquiSing();
        }

        /// <summary>
        /// Adiciona uma lista de singularidade na lista de lingularidades da tubulação
        /// </summary>
        /// <param name="singularidades">Lista de singularidade a ser adicionada</param>
        public void AdicionaSingularidade(List<ISingularidade> singularidades)
        {
            foreach (ISingularidade sin in singularidades)
            {
                listaSingularidades.Add(sin);
            }
            CalculaComprimentoEquiSing();
        }

        /// <summary>
        /// Calcula o número de Reyolds
        /// </summary>
        /// <param name="fluido">O Fluido que está na tubulação. </param>
        /// <param name="vazao">A vazão do fluido [m^3/s]. </param>
        /// <returns> O número de Rynolds [adm]. </returns>
        public double CalculaReynolds(IMaterialFluidoOPI material, double vazao)
        {
            double re;

            re = (4 * material.Densidade * vazao) / (Math.PI * material.Viscosidade * this.Diametro);

            return re;
        }

        /// <summary>
        /// Calcula o fator de atrito de acordo com a correlação de Fanning.
        /// </summary>
        /// <param name="material">O Fluido que está na tubulação. </param>
        /// <param name="vazao">A vazão do fluido [m^3/s]. </param>
        /// <returns> O fator de atrito [adm]. </returns>
        public virtual double CalculaFAtrito(IMaterialFluidoOPI material, double vazao)
        {
            double Re;
            double A1;
            double A2;
            double A;
            double B;
            double fA1;
            double fA2;
            double fA;
            double invRaizFA;

            switch (metodoFatrito)
            {
                case "fanning":
                    Re = CalculaReynolds(material, vazao);
                    A1 = Math.Pow(7 / Re, 0.9);
                    A2 = 0.27 * this.RugosidadeRelativa;
                    A = Math.Pow(-2.475 * Math.Log(A1 + A2), 16);
                    B = Math.Pow((37530 / Re), 16.0);

                    fA1 = Math.Pow(8 / Re, 12);
                    fA2 = 1 / Math.Pow(A + B, 3.0 / 2.0);

                    fA = 2 * Math.Pow(fA1 + fA2, 1.0 / 12.0); // fator de fanning
                    break;
                case "haaland":
                    Re = CalculaReynolds(material, vazao);
                    A = Math.Pow(this.RugosidadeRelativa / (3.7*diametro), 1.11);
                    B = 6.9 / Re;

                    invRaizFA = -3.6 * Math.Log10(A + B);
                    fA = 1 / Math.Pow(invRaizFA, 2); // fator de fanning
                    break;
                default:
                    throw new Exception("Especifique o método.");
            }
            return fA;
        }

        /// <summary>
        /// Cálcula a perda de carga da tubulação
        /// </summary>
        /// <param name="material">O Fluido que está na tubulação. </param>
        /// <param name="vazao">A vazão do fluido [m^3/s]. </param>
        /// <returns> A perda de carga [m]. </returns>
        public virtual double CalculaPerdaCarga(IMaterialFluidoOPI material, double vazao)
        {
            double fAtrito = CalculaFAtrito(material, vazao);
            double comprimetoTotal = this.Comprimento + this.ComprimentoEquivalente;

            double vMedia = vazao / (Math.PI * Math.Pow(diametro / 2, 2));

            perdaCarga = 4 * fAtrito * (comprimetoTotal / diametro) * (Math.Pow(vMedia, 2) / (2 * g));
         
            return perdaCarga;
        }

        /// <summary>
        /// Cálcula o comprimento equivalente das singularidades
        /// </summary>
        /// <returns> O comprimento equivalente das singularidades [m]. </returns>
        private void CalculaComprimentoEquiSing()
        {
            double comprEq = 0;

            foreach(ISingularidade sin in this.listaSingularidades)
            {
                comprEq = comprEq + sin.ComprimentoEqv;
            }

            this.comprimentoEquivalente = comprEq;
        }
    }
}