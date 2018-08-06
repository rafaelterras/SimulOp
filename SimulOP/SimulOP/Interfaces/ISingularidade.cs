namespace SimulOP
{
    /// <summary>
    /// Interfaces para singularidades em operações unitárias I.
    /// </summary>
    public interface ISingularidade
    {
        /// <summary>
        /// Comprimento equivalente da singulariedade [m].
        /// </summary>
        double ComprimentoEqv { get; }
        /// <summary>
        /// Tipo da singulariedade.
        /// </summary>
        string Tipo { get; }
    }
}