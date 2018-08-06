namespace SimulOP
{
    /// <summary>
    /// Classe para representar as peopriedades de um componente para utilizar em operações unitárias I.
    /// </summary>
    public class MaterialFluidoOPI : Material ,  IMaterialFluidoOPI
    {
        protected double densidade; // [Kg/m^3].
        protected double viscosidade; // [Pa*s].

        /// <summary>
        /// Densidade do material [Kg/m^3].
        /// </summary>
        public virtual double Densidade { get => densidade; }
        /// <summary>
        /// Viscosidade do material [Pa*s].
        /// </summary>
        public virtual double Viscosidade { get => viscosidade; }

        /// <summary>
        /// Constructor do MaterialFluidoOPI
        /// </summary>
        /// <param name="componente">Nome do componente.</param>
        /// <param name="densidade">Densidade do material [Kg/m^3].</param>
        /// <param name="viscosidade">Viscosidade do material [Pa*s].</param>
        public MaterialFluidoOPI(string componente, double densidade, double viscosidade) : base(componente)
        {
            this.densidade = densidade;
            this.viscosidade = viscosidade;
        }
        
    }
}
