using System;

namespace SimulOP
{
    /// <summary>
    /// 
    /// </summary>
    class Valvula : ISingularidade
    {
        private double comprimentoEqv;
        private double comprimentoEqvAberta;
        private string tipo;
        private double abertura;

        /// <summary>
        /// Comprimento equivalente da singulariedade [m]
        /// </summary>
        public double ComprimentoEqv { get => comprimentoEqv; }
        /// <summary>
        /// Tipo da singulariedade
        /// </summary>
        public string Tipo { get => tipo; }
        /// <summary>
        /// Abertura da valvula entre 0 (totalmente fechada) e  1 (totalmente aberta)
        /// </summary>
        public double Abertura
        {
            get => abertura;
            set
            {
                if (value >= 0.0 && value <= 1.0)
                {
                    this.abertura = value;
                    AtualizaComprimento();
                }
                else
                {
                    throw new Exception("Valor da abertura tem que estar entre 0 e 1");
                }
            }

        }
        
        /// <summary>
        /// Constructor para o objeto Valvula
        /// </summary>
        /// <param name="comprimentoEqv">Comprimento equivalente da valvula totalmente aberta [m]</param>
        /// <param name="abertura">Abertura da valvula (entre 0, totalmente fechada e 1, totalmente aberta)</param>
        public Valvula(double comprimentoEqv, double abertura = 1.0)
        {
            this.comprimentoEqvAberta = comprimentoEqv;
            this.tipo = "Valvula";
            this.Abertura = abertura;
        }

        /// <summary>
        /// Atualiza o comprimento equivalenta com base em uma escala linear arbritária
        /// </summary>
        private void AtualizaComprimento()
        {
            this.comprimentoEqv = comprimentoEqvAberta + 100 * (1 - this.abertura);
        }        
    }
}