namespace SimulOP
{
    /// <summary>
    /// Interface para o material para operações unitárias II.
    /// </summary>
    public interface IMaterialFluidoOPII
    {
        /// <summary>
        /// Nome do componente.
        /// </summary>
        string Componente { get; }
        /// <summary>
        /// Temperatura do material [K].
        /// </summary>
        double Temperatura { get; set; }
        /// <summary>
        /// Viscosidade do material [Pa*s].
        /// </summary>
        double Viscosidade { get; }
        /// <summary>
        /// Densidade do material [Kg/m^3].
        /// </summary>
        double Densidade { get; }
        /// <summary>
        /// Calor específico do materia [] // TODO: Verificar as unidades.
        /// </summary>
        double CalorEspecifico { get; }
        /// <summary>
        /// Condutividade térmica do material []
        /// </summary>
        double CondutividadeTermica { get; }

        IMaterialFluidoOPII Clone();
    }
}
