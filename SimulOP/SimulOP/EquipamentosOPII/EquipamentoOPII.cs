namespace SimulOP
{
    /// <summary>
    /// Classe abstrata para representar todos os equipamentos de OPI.
    /// </summary>
    public abstract class EquipamentoOPII : Equipamentos
    {
        /// <summary>
        /// Densidade da água em lb/ft^3
        /// </summary>
        public const double densidadeAguaSImperial = 62.42796529; //[lb/ft^3]

        /// <summary>
        /// Enum para representar as configuração contra-corrente ou co-corrente.
        /// </summary>
        public enum ConfgCorrentes
        {
            coCorrente = 0,
            contraCorrente = 1,
        }
        
        /// <summary>
        /// Enum para representar se a tubulação é anular ou interna ao trucador de calor bi tubular.
        /// </summary>
        public enum TipoTubo
        {
            anular = 0,
            interno = 1,
        }

        /// <summary>
        /// Enum para representar se o fluido de troca é o quente ou o frio.
        /// </summary>
        public enum FluidoTroca
        {
            quente = 0,
            frio = 1,
        }
    }
}