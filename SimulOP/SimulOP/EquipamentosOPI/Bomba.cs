﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimulOP
{
    class Bomba : EquipamentoOPI, IBomba
    {
        #region Inicialização das variaveis e do Constructor
        private double vazao;
        private double potencia;
        private double[] equacaoCurva;
        private double alturaManometrica;
        private FluidoOPI fluido;
        private Tubulacao tubulacao;
        private double rendimento;

        /// <summary>
        /// Vazão de fluido (m^3/s)
        /// </summary>
        public double Vazao { get => vazao; }

        /// <summary>
        /// Potencia da bomba [W]
        /// </summary>
        public double Potencia { get => potencia; }

        /// <summary>
        /// Coeficientes do polinomio de 3º grau que aproxima a bomba
        /// a3*Q^3 + a2*Q^2 + a1*Q^1 + a0
        /// </summary>
        public double[] EquacaoCurva { get => equacaoCurva; set => equacaoCurva = value; }

        /// <summary>
        /// Altura monometrica da bomba [m]
        /// </summary>
        public double AlturaManometrica { get => alturaManometrica; }

        /// <summary>
        /// O fluido que está sendo escoado pela bomba
        /// </summary>
        public FluidoOPI Fluido { get => fluido; set => fluido = value; }

        /// <summary>
        /// A tubulação em que a bomba está instalada
        /// </summary>
        public Tubulacao TubulacaoDescarga { get => tubulacao; set => tubulacao = value; }

        /// <summary>
        /// Rendimento elétrico da bomba
        /// </summary>
        public double Rendimento { get => rendimento; set => rendimento = value; }

        /// <summary>
        /// Constructor do objeto Bomba
        /// </summary>
        /// <param name="equacaoCurva">Coeficientes do polinomio de 3º grau que aproxima a bomba</param>
        /// <param name="fluido">O fluido que está sendo escoado pela bomba</param>
        /// <param name="tubulacao">A tubulação que a bomba está acloplada</param>
        public Bomba(double[] equacaoCurva, FluidoOPI fluido, Tubulacao tubulacao)
        {
            this.equacaoCurva = equacaoCurva;
            this.fluido = fluido;
            this.tubulacao = tubulacao;
        }

        /// <summary>
        /// Constructor para bombas em assiciação
        /// </summary>
        /// <param name="bomba1">Uma das Bombas</param>
        /// <param name="bomba2">Uma das Bombas</param>
        /// <param name="tipo">O Tipo de associação ("série" ou "paralelo")</param>
        public Bomba(Bomba bomba1, Bomba bomba2, string tipo)
        {
            if (bomba1.fluido.Equals(bomba2.fluido) && bomba1.tubulacao.Equals(bomba2.tubulacao))
            {
                this.fluido = bomba1.fluido;
                this.tubulacao = bomba1.tubulacao;
                this.BombaEquivalente(new Bomba[] { bomba1, bomba2 }, tipo);
            }
            else
            {
                throw new Exception("As bombas precisam ter o mesmo objeto Fluido e Tubulacao para serem usadas em associacao");
            }
        }

        #endregion

        /// <summary>
        /// Atualiza bomba pra uma bomba equivalente.
        /// </summary>
        /// <param name="arrayBomba">Um array com as bombas que se deseja ver a equivalente. </param>
        /// <param name="tipo">O Tipo de associação ("série" ou "paralelo"). </param>
        public void BombaEquivalente(Bomba[] arrayBomba, string tipo)
        {
            double[] novaEquacaoBomba = new double[4];
            int i = 0;

            if (tipo.ToLower() == "série")
            {
                foreach (Bomba bomba in arrayBomba)
                {
                    i = 0;
                    foreach (double Q in bomba.EquacaoCurva)
                    {
                        novaEquacaoBomba[i] = novaEquacaoBomba[i] + Q;
                        i++;
                    }
                }
            }
            else if (tipo.ToLower() == "paralelo")
            {
                throw new System.NotImplementedException("Bombas em paralelo ainda não implementadas");
            }

            this.equacaoCurva = novaEquacaoBomba;
        }

        /// <summary>
        /// Calcula a altura da bomba apartir da vazão.
        /// </summary>
        /// <param name="vazao">A vazão do fluido [m^3/s]. </param>
        /// <returns> A altura da bomba [m]. </returns>
        public double CalcAlturaBomba(double vazao)
        {
            double h = 0;

            for (int i = 3; i >= 0; i--)
            {
                h = h + this.equacaoCurva[3 - i] * Math.Pow(vazao, i);
            }

            return h;
        }

        /// <summary>
        /// Equação de Bernoulli, da forma Delta(H)_{bomba} - H_{f} - Delta(Z) = 0
        /// </summary>
        /// <returns> O valor da Equação de bernoulli [m]. </returns>
        public double Bernoulli(double vazao)
        {
            return this.CalcAlturaBomba(vazao) - TubulacaoDescarga.CalculaPerdaCarga(Fluido, vazao) - TubulacaoDescarga.Elevacao;
        }

        /// <summary>
        /// Atualiza o valor da vazão [m^3/s] e da altura [m] da bomba utilizando a equação de Bernoulli.
        /// </summary>
        public void CalculaVazao()
        {
            double vazao;

            vazao = AchaRaizBrenet(Bernoulli, 0.001, 10);

            this.vazao = vazao;
            this.alturaManometrica = CalcAlturaBomba(vazao);
            this.TubulacaoDescarga.CalculaPerdaCarga(Fluido, this.Vazao);
        }

        public (double[] plotX, double[] plotYBomba, double[] plotYTubo) PreparaPlot (int nMax = 40)
        {
            List<double> listX = new List<double>();
            List<double> listYBomba = new List<double>();
            List<double> listYtubo = new List<double>();

            double h; // Altura da bomba [m]
            double hf; // Equacao da tubulacao [m]
            double vazao;

            for (int i = 0; i < nMax; i++)
            {
                vazao = (i + 1) * (this.vazao / (nMax / 2));

                h = this.CalcAlturaBomba(vazao);
                hf = this.tubulacao.CalculaPerdaCarga(this.fluido, vazao) + this.tubulacao.Elevacao;
                if (h > 0)
                {
                    listX.Add(vazao);
                    listYBomba.Add(h);
                    listYtubo.Add(hf);
                }
                else
                {
                    break;
                }
            }

            double[] plotX = new double[listX.Count];
            double[] plotYBomba = new double[listX.Count];
            double[] plotYTubo = new double[listX.Count];

            for (int i = 0; i < listX.Count; i++)
            {
                plotX[i] = Math.Round(listX[i] * 3600, 2); // m^3/h
                plotYBomba[i] = listYBomba[i];
                plotYTubo[i] = listYtubo[i];
            }

            return (plotX, plotYBomba, plotYTubo);
        }

        /// <summary>
        /// Calcula a potência elátrica da bomba
        /// </summary>
        /// <param name="vazao">Vazão de liquido que passa na bomba [m^3/s]</param>
        /// <returns></returns>
        public double CalculaPotencia(double vazao)
        {
            this.potencia = fluido.Material.Densidade * g * vazao * alturaManometrica / rendimento;
            return this.Potencia;
        }
    }
}