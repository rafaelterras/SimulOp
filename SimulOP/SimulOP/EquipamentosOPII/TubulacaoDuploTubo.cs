using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulOP
{
    public class TubulacaoDuploTubo : Tubulacao
    {
        private EquipamentoOPII.TipoTubo tipoTubo;

        public EquipamentoOPII.TipoTubo TipoTubo { get => tipoTubo; set => tipoTubo = value; }

        /// <summary>
        /// Constructor da tubulação do trocador duplo tubo
        /// </summary>
        /// <param name="diametro">Diametro equivalente da tubulação.</param>
        /// <param name="comprimento">Comprimento do tubo.</param>
        /// <param name="material">Material do tubo.</param>
        /// <param name="tipoTubo">Tipo do tubo, se é anular ou interno.</param>
        public TubulacaoDuploTubo(double diametro, double comprimento, MaterialTubulacao material, EquipamentoOPII.TipoTubo tipoTubo) 
            : base(diametro, comprimento, material, 0, "")
        {
            this.tipoTubo = tipoTubo;
        }
        
        public override double CalcReynolds(double densidade, double viscosidade, double vazao, double diametro)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Cálculo do fator de atrito para um determinado fluido em uma vazão.
        /// </summary>
        /// <param name="material">Material do fluido que está escoando na tubulação.</param>
        /// <param name="vazao">A vazão de fluido.</param>
        /// <returns>O fator de atrito.</returns>
        public double CalculaFAtrito(IMaterialFluidoOPII material, double vazao)
        {
           throw new NotImplementedException();
        }

        /// <summary>
        /// Cálculo do fator de atrito para um determinado fluido em uma vazão.
        /// </summary>
        /// <param name="material">Material do fluido que está escoando na tubulação.</param>
        /// <param name="vazao">A vazão de fluido.</param>
        /// <returns>A perda de carga.</returns>
        public double CalculaPerdaCarga(IMaterialFluidoOPII material, double vazao)
        {
            throw new NotImplementedException();
        }
    }
}
