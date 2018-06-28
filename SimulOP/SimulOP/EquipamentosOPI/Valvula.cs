using System;

namespace SimulOP
{
    /// <summary>
    /// 
    /// </summary>
    class Valvula : Singularidade
    {
        private double comprimentoEqvAberta;
        private double abertura;
        private double fatorAbertura;

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
        /// Representa um fator para multiplicar a abertura da valvúla
        /// </summary>
        public double FatorAbertura { get => fatorAbertura; }

        /// <summary>
        /// Constructor para o objeto Valvula
        /// </summary>
        /// <param name="comprimentoEqv">Comprimento equivalente da valvula totalmente aberta [m]</param>
        /// <param name="abertura">Abertura da valvula (entre 0, totalmente fechada e 1, totalmente aberta)</param>
        public Valvula(double comprimentoEqv, double fatorAbertura , double abertura = 1.0) : base(comprimentoEqv, "Valvula")
        {
            this.Abertura = abertura;
            this.fatorAbertura = fatorAbertura;
        }

        /// <summary>
        /// Atualiza o comprimento equivalenta com base em uma escala linear arbritária
        /// </summary>
        private void AtualizaComprimento()
        {
            this.comprimentoEqv = comprimentoEqvAberta + fatorAbertura * (1 - this.abertura);
        }        
    }
}