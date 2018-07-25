using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulOP
{
    public class TubulacaoDuploTubo : Tubulacao
    {
        protected double especura;
        protected double diametroExterno;
        protected double resistenciaTermica;
        protected EquipamentoOPII.TipoTubo tipoTubo;
        
        public EquipamentoOPII.TipoTubo TipoTubo { get => tipoTubo; set => tipoTubo = value; }
        public double DiametroExterno { get => diametroExterno; set => diametroExterno = value; }
        public double Especura { get => especura; set => especura = value; }
        public double ResistenciaTermica
        {
            get
            {
                CalculaResistencia();
                return resistenciaTermica;
            }
        }

        /// <summary>
        /// Constructor da tubulação do trocador duplo tubo
        /// </summary>
        /// <param name="diametroExterno">Diametro equivalente da tubulação.</param>
        /// <param name="comprimento">Comprimento do tubo.</param>
        /// <param name="material">Material do tubo.</param>
        /// <param name="tipoTubo">Tipo do tubo, se é anular ou interno.</param>
        public TubulacaoDuploTubo(double diametroExterno, double especura, double comprimento, MaterialTubulacao material, EquipamentoOPII.TipoTubo tipoTubo) 
            : base(diametroExterno - especura, comprimento, material, 0, "")
        {
            this.especura = (especura >= 0) ? especura : throw new ArgumentException(nameof(especura));
            this.diametroExterno = (diametroExterno > 0) ? diametroExterno : throw new ArgumentException(nameof(diametroExterno));
            this.tipoTubo = tipoTubo;
        }
        
        private void CalculaResistencia()
        {
            double R = (this.diametroExterno * Math.PI * this.comprimento) / (material.Condutividade * this.especura);

            this.resistenciaTermica = R;
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
            throw new NotImplementedException(); // TODO: Implementar as funções de perda de carga
        }           
    }
}
