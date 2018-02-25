using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        double ComprimentoEquivalente { get; set; }

        /// <summary>
        /// Diametro da tubulação (m)
        /// </summary>
        double Diametro { get; set; }

        /// <summary>
        /// Tipo de material
        /// </summary>
        string Material { get; set; }

        /// <summary>
        /// Rugosidede do material
        /// </summary>
        double Rugosidade { get; set; }

        /// <summary>
        /// Rugosidade relativa do mateira
        /// </summary>
        double RugosidadeRelativa { get; set; }

        /// <summary>
        /// Fator de atrido na condição de escoamento
        /// </summary>
        double FatorAtrito { get; set; }

        /// <summary>
        /// Lista de singulariedades na tubulação
        /// </summary>
        /// 
        ///List<Singularidade> ListaSingulariedades { get; set; }
        
        /// <summary>
        /// Elevação da tubulação
        /// </summary>
        /// 
        double Elevacao { get; set; }
        
        /// <summary>
        /// Calcula a vazão com base na equação da bomba e da tubulação
        /// </summary>
        double CalculaVazao();
    }
}
