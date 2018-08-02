using System;

namespace SimulOP
{
    /// <summary>
    /// Classe para representar a tubulação que é usada em trocadores de calor bi tubular.
    /// </summary>
    public class TubulacaoDuploTubo : Tubulacao
    {
        protected double especura;
        protected double diametroExterno;
        protected EquipamentoOPII.TipoTubo tipoTubo;
        
        /// <summary>
        /// Enoum TipoTubo, se a tubulação é a anular ou a interna.
        /// </summary>
        public EquipamentoOPII.TipoTubo TipoTubo { get => tipoTubo; set => tipoTubo = value; }
        /// <summary>
        /// Diametro externo do tubo [m].
        /// </summary>
        public double DiametroExterno { get => diametroExterno; set => diametroExterno = value; }
        /// <summary>
        /// Especura da parede [m].
        /// </summary>
        public double Especura { get => especura; set => especura = value; }

        /// <summary>
        /// Constructor da tubulação do trocador duplo tubo
        /// </summary>
        /// <param name="diametroExterno">Diametro equivalente da tubulação.</param>
        /// <param name="comprimento">Comprimento do tubo.</param>
        /// <param name="material">Material do tubo.</param>
        /// <param name="tipoTubo">Tipo do tubo, se é anular ou interno.</param>
        public TubulacaoDuploTubo(double diametroExterno, double especura, double comprimento, MaterialTubulacao material, EquipamentoOPII.TipoTubo tipoTubo) 
            : base(diametroExterno - especura, comprimento, material, 0, "")
        {
            this.especura = (especura >= 0) ? especura : throw new ArgumentException(nameof(especura));
            this.diametroExterno = (diametroExterno > 0) ? diametroExterno : throw new ArgumentException(nameof(diametroExterno));
            this.tipoTubo = tipoTubo;
        }
        
        /// <summary>
        /// Número de Reynolds associado ao escoamento.
        /// </summary>
        /// <param name="densidade"></param>
        /// <param name="viscosidade"></param>
        /// <param name="vazao"></param>
        /// <param name="diametro"></param>
        /// <returns>O número de Reynolds.</returns>
        public double CalcReynolds(IMaterialFluidoOPII material , double vazao)
        {
            double re;

            re = 4 * material.Densidade * vazao / (Math.PI * this.diametro * material.Viscosidade);

            return re;
        }

        /// <summary>
        /// Cálculo do fator de atrito para um determinado fluido em uma vazão.
        /// </summary>
        /// <param name="material">Material do fluido que está escoando na tubulação.</param>
        /// <param name="vazao">A vazão de fluido [m^3/s].</param>
        /// <returns>O fator de atrito.</returns>
        public double CalculaFAtrito(IMaterialFluidoOPII material, double vazao)
        {
            double Re = CalcReynolds(material, vazao);
            double A1 = Math.Pow(7 / Re, 0.9);
            double A2 = 0.27 * this.RugosidadeRelativa;
            double A = Math.Pow(-2.475 * Math.Log(A1 + A2), 16);
            double B = Math.Pow((37530 / Re), 16.0);

            double fA1 = Math.Pow(8 / Re, 12);
            double fA2 = 1 / Math.Pow(A + B, 3.0 / 2.0);

            double fA = 2 * Math.Pow(fA1 + fA2, 1.0 / 12.0); // fator de fanning

            this.fatorAtrito = fA;

            return fA;
        }

        /// <summary>
        /// Cálculo do fator de atrito para um determinado fluido em uma vazão.
        /// </summary>
        /// <param name="material">Material do fluido que está escoando na tubulação.</param>
        /// <param name="vazao">A vazão de fluido [m^3/s].</param>
        /// <returns>A perda de carga.</returns>
        public double CalculaPerdaCarga(IMaterialFluidoOPII material, double vazao)
        {
            double fAtrito = CalculaFAtrito(material, vazao);
            double vMedia = vazao / (Math.PI * Math.Pow(diametro / 2, 2));

            perdaCarga = 4 * fAtrito * material.Densidade * (this.comprimento / diametro) * Math.Pow(vMedia, 2); // em Pa.

            return perdaCarga;
        }           
    }
}
