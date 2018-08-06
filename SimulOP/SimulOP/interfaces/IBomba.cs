﻿namespace SimulOP
{
    /// <summary>
    /// Interface para bombas.
    /// </summary>
    interface IBomba
    {
        /// <summary>
        /// Vazão de fluido [m^3/s]
        /// </summary>
        double Vazao { get; }

        /// <summary>
        /// Potencia da bomba [W]
        /// </summary>
        double Potencia { get; }

        /// <summary>
        /// Coeficientes do polinomio de 3º grau que aproxima a bomba
        /// </summary>
        double[] EquacaoCurva { get; set; }

        /// <summary>
        /// O fluido que está sendo escoado pela bomba
        /// </summary>
        FluidoOPI Fluido { get; set; }

        /// <summary>
        /// A tubulação de descarga em que a bomba está instalada
        /// </summary>
        Tubulacao TubulacaoDescarga { get; set; }

        /// <summary>
        /// Altura monometrica da bomba [m]
        /// </summary>
        double AlturaManometrica { get; }

        /// <summary>
        /// Rendimento elétrico da bomba
        /// </summary>
        double Rendimento { get; set; }

        /// <summary>
        /// Atualiza bomba pra uma bomba equivalente.
        /// </summary>
        /// <param name="arrayBomba">Um array com as bombas que se deseja ver a equivalente. </param>
        /// <param name="tipo">O Tipo de associação ("série" ou "paralelo"). </param>
        void BombaEquivalente(Bomba[] arrayBomba, string tipo);

        /// <summary>
        /// Calcula a altura da bomba apartir da vazão.
        /// </summary>
        /// <param name="vazao">A vazão do fluido [m^3/s]. </param>
        /// <returns> A altura da bomba [m]. </returns>
        double CalcAlturaBomba(double vazao);

        /// <summary>
        /// Equação de Bernoulli, da forma Delta(H) - Hf + Delta(Z)
        /// </summary>
        /// <returns> O valor da Equação de bernoulli [m]. </returns>
        double Bernoulli(double vazao);

        /// <summary>
        /// Calcula a potência elátrica da bomba
        /// </summary>
        /// <param name="vazao">Vazão de liquido que passa na bomba [m^3/s]</param>
        /// <returns></returns>
        double CalculaPotencia(double vazao);
    }
}