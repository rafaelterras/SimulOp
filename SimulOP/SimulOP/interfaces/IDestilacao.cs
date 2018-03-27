using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimulOP
{
    public interface IDestilacao
    {
        /// <summary>
        /// Número de pratos teoricos
        /// </summary>
        double numeroPratosTeorico { get; set; }

        /// <summary>
        /// Número de pratos reais
        /// </summary>
        int numeroPretosPratica { get; set; }

        /// <summary>
        /// ???Refluxo???
        /// </summary>
        double refluxo { get; set; }

        /// <summary>
        /// Fluido no topo
        /// </summary>
        Fluido flidoDest { get; set; }

        /// <summary>
        /// Fluido no fundo
        /// </summary>
        Fluido fluidoBott { get; set; }

        /// <summary>
        /// Fluido de entrada
        /// </summary>
        Fluido fluidoFeed { get; set; }

        /// <summary>
        /// Esagio de alimentação
        /// </summary>
        int estagioFeed { get; set; }

        /// <summary>
        /// Calcula o número de pratos teoricos para a condição de refluxo máximo
        /// </summary>
        void CalculaPratosMin();
    }
}