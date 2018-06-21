﻿namespace SimulOP
{
    public interface ITrocadorDeCalor
    {
        /// <summary>
        /// Fluido frio na entrada
        /// </summary>
        FluidoOPI fluidoQuenteEntrada { get; set; }

        /// <summary>
        /// Fluido quente na entrada
        /// </summary>
        FluidoOPI fluidoFrioEntrada { get; set; }

        /// <summary>
        /// Coeficiente global de troca térmica (U) (J/m^1 k)
        /// </summary>
        double coefGlobalTerm { get; set; }

        /// <summary>
        /// Área de troca térmica (A) (m^2)
        /// </summary>
        double area { get; set; } 

        /// <summary>
        /// Tipo de configuração ("contracorrente" ou "co-corrente")
        /// </summary>
        string tipoEscoamento { get; set; }

        /// <summary>
        /// Fluido frio na saida
        /// </summary>
        FluidoOPI fluidoFrioSaida { get; set; }

        /// <summary>
        /// Fluido quente na saida
        /// </summary>
        FluidoOPI fluidoQuenteSaida { get; set; }

        /// <summary>
        /// Calor transferido do fluido quente para o frio (W)
        /// </summary>
        double calorTransferido { get; set; }

        /// <summary>
        /// Calcula o processo de troca térmica no trocador e atualiza suas propriedades
        /// </summary>
        void CalculaSaidas();
    }
}