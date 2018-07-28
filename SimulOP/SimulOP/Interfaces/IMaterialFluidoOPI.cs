namespace SimulOP
{
    /// <summary>
    /// Interface para materiais para operações unitárias I.
    /// </summary>
    public interface IMaterialFluidoOPI
    {
        /// <summary>
        /// Densidade do material [Kg/m^3].
        /// </summary>
        double Densidade { get; }
        /// <summary>
        /// Viscosidade do material [Pa*s].
        /// </summary>
        double Viscosidade { get; }
    }
}
