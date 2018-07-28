using System.Collections.Generic;

namespace SimulOP
{
    /// <summary>
    /// INterface para tubulações.
    /// </summary>
    public interface ITubulacao
    {
        /// <summary>
        /// Comprimento da tubulação [m].
        /// </summary>
        double Comprimento { get; set; }

        /// <summary>
        /// Comprimento equivalente das sigularidades [m].
        /// </summary>
        double ComprimentoEquivalente { get; }

        /// <summary>
        /// Diametro da tubulação [m].
        /// </summary>
        double Diametro { get; set; }

        /// <summary>
        /// Tipo de material [MaterialTubulacao].
        /// </summary>
        MaterialTubulacao Material { get; set; }

        /// <summary>
        /// Rugosidade relativa do mateira [m^-1].
        /// </summary>
        double RugosidadeRelativa { get; set; }

        /// <summary>
        /// Fator de atrido na condição de escoamento [Fator de moody].
        /// </summary>
        double FatorAtrito { get; }

        /// <summary>
        /// Lista de singulariedades na tubulação [List<Isingularidade>].
        /// </summary>
        List<ISingularidade> ListaSingularidades { get; }
        
        /// <summary>
        /// Elevação da tubulação [m].
        /// </summary>
        double Elevacao { get; set; }
    }
}
