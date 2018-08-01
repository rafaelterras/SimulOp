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
        public override double CalcReynolds(double densidade, double viscosidade, double vazao, double diametro)
        {
            double re;

            re = 4 * densidade * vazao / (Math.PI * diametro * viscosidade);

            return re;
        }

        /// <summary>
        /// Cálculo do fator de atrito para um determinado fluido em uma vazão.
        /// </summary>
        /// <param name="material">Material do fluido que está escoando na tubulação.</param>
        /// <param name="vazao">A vazão de fluido.</param>
        /// <returns>O fator de atrito.</returns>
        public double CalculaFAtrito(IMaterialFluidoOPII material, double vazao)
        {
            double f;

            f = 0.0035 + 0.264 / Math.Pow(CalcReynolds(material.Densidade, material.Viscosidade, vazao, this.diametro), 0.42);

            return f;
        }

        /// <summary>
        /// Cálculo do fator de atrito para um determinado fluido em uma vazão.
        /// </summary>
        /// <param name="material">Material do fluido que está escoando na tubulação.</param>
        /// <param name="vazao">A vazão de fluido.</param>
        /// <returns>A perda de carga.</returns>
        public double CalculaPerdaCarga(IMaterialFluidoOPII material, double vazao)
        {
            double dp;

            dp = 2 * CalculaFAtrito(material, vazao) * Math.Pow(vazao, 2) * this.comprimento / this.diametro;

            return dp;
        }           
    }
}
