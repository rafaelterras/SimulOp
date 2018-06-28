using System.Collections.Generic;

namespace SimulOP
{
    public interface ITubulacao
    {
        /// <summary>
        /// Comprimento da tubulação
        /// </summary>
        double Comprimento { get; set; }

        /// <summary>
        /// Comprimento equivalente das sigularidades
        /// </summary>
        double ComprimentoEquivalente { get; }

        /// <summary>
        /// Diametro da tubulação (m)
        /// </summary>
        double Diametro { get; set; }

        /// <summary>
        /// Tipo de material
        /// </summary>
        MaterialTubulacao Material { get; set; }

        /// <summary>
        /// Rugosidade relativa do mateira
        /// </summary>
        double RugosidadeRelativa { get; set; }

        /// <summary>
        /// Fator de atrido na condição de escoamento
        /// </summary>
        double FatorAtrito { get; }

        /// <summary>
        /// Lista de singulariedades na tubulação
        /// </summary>
        List<ISingularidade> ListaSingularidades { get; }
        
        /// <summary>
        /// Elevação da tubulação
        /// </summary>
        double Elevacao { get; set; }
    }
}
