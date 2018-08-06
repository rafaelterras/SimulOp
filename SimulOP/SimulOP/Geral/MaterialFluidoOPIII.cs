namespace SimulOP
{
    /// <summary>
    /// Classe para representar as peopriedades de um componente para utilizar em operações unitárias III.
    /// </summary>
    public class MaterialFluidoOPIII : MaterialFluidoOPI
    {
        private double[] coefAntoine; // Coeficientes [A,B,C...] da equação de Antoine.

        /// <summary>
        /// Coeficientes [A,B,C...] da equação de Antoine.
        /// </summary>
        public double[] CoefAntoine { get => coefAntoine; }

        /// <summary>
        /// Constructor do MaterialFluidoOPIII.
        /// </summary>
        /// <param name="componente">Nome do componente.</param>
        /// <param name="densidade">Densidade do material [Kg/m^3].</param>
        /// <param name="viscosidade">Viscosidade do material [Pa*s].</param>
        /// <param name="coefAntoine">Arry com os coeficientes [A,B,C..] da equação de Antoine.</param>
        public MaterialFluidoOPIII(string componente, double densidade, double viscosidade, double[] coefAntoine) : base(componente, densidade, viscosidade)
        {
            this.coefAntoine = coefAntoine;
        }

    }
}
