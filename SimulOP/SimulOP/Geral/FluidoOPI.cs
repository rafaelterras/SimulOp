namespace SimulOP
{
    /// <summary>
    /// Classe para representar fluidos em operações unitárias I.
    /// </summary>
    public class FluidoOPI
    {
        #region Inicialização das variaveis e do Constructor
        private MaterialFluidoOPI material;

        /// <summary>
        /// Material que guarda as propriedades físicas do fluido.
        /// </summary>
        public MaterialFluidoOPI Material { get => material; }

        /// <summary>
        /// Constructor do FluidoOPI
        /// </summary>
        /// <param name="material">Material com as propriedades físicas.</param>
        public FluidoOPI(MaterialFluidoOPI material)
        {
            this.material = material;
        }

        /// <summary>
        /// Constructor do fluidoOPI quando não se deseja especificar o material.
        /// </summary>
        /// <param name="densidade">Densidade do fluido [Kg/m^3].</param>
        /// <param name="viscosidade">Viscosidade do fluido [Pa*s].</param>
        public FluidoOPI(double densidade, double viscosidade)
        {
            material = new MaterialFluidoOPI("[Não especificado]", densidade, viscosidade);
        }
        #endregion

        /// <summary>
        /// Converte uma determinada pressão em metros de coluna do fluido.
        /// </summary>
        /// <param name="pressao">Pressão que se deseja converter.</param>
        /// <returns>A pressão em metros de coluna de fluido.</returns>
        public double ConvertePressaoEmM(double pressao)
        {
            double pressaoM;

            pressaoM = pressao / (this.material.Densidade * Equipamentos.g);
            return pressaoM;
        }

    }
}