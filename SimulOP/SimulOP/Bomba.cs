using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimulOP
{
    class Bomba : EquipamentoOPI, IBomba
    {
        public double vazao { get; set; }

        public double potencia { get; set; }

        /// <summary>
        /// Coeficientes do polinomio de 3º grau que aproxima a bomba
        /// a3*Q^3 + a2*Q^2 + a1*Q^1 + a0
        /// </summary>
        public double[] equacaoCurva { get; set; }

        public double alturaManometrica { get; set; }

        /// <summary>
        /// Calcula a altura da bomba apartir da vazão.
        /// </summary>
        /// <param name="vazao">A vazão do fluido [m^3/s]. </param>
        /// <returns> A altura da bomba [m]. </returns>
        public double CalcAlturaBomba(double vazao)
        {
            double h = 0;

            for(int i = 3; i >= 0; i--)
            {
                h = h + this.equacaoCurva[3-i] * Math.Pow(vazao, i);
            }
            
            return h;
        }

        /// <summary>
        /// Atualiza bomba pra uma bomba equivalente.
        /// </summary>
        /// <param name="arrayBomba">Um array com as bombas que se deseja ver a equivalente. </param>
        /// <param name="tipo">O tipo de associação ("série" ou "paralelo"). </param>
        public void BombaEquivalente(Array arrayBomba, string tipo)
        {
            double[] alturaBomba = new double[4];
            int i = 0;

            if (tipo.ToLower() == "série")
            {
                foreach (Bomba bomba in arrayBomba)
                {
                    i = 0;
                    foreach (double Q in bomba.equacaoCurva)
                    {
                        alturaBomba[i] = alturaBomba[i] + Q;
                        Console.WriteLine("i: {0}", i);
                        i++;
                    }
                }
                this.equacaoCurva = alturaBomba;
            }
            if (tipo == "paralelo")
            {
                throw new System.NotImplementedException();
            }

        }

        /// <summary>
        /// Atualiza o valor da vazão [m^3/s] da bomba utilizando a equação de Bernoulli.
        /// </summary>
        /// <param name="fluido">O fluido que está passando na bomba. </param>
        /// <param name="tubulacao">A tubulação que está sendo analisada. </param>
        /// <returns> A altura da bomba [m]. </returns>
        public void CalculaVazao(Fluido fluido, Tubulacao tubulacao)
        {
            double vazao = 0.001;
            double eps = 10E-6;
            double err;
            double deri;
            double fX;
            double nIte = 1;

            fX = this.CalcAlturaBomba(vazao) - tubulacao.CalculaPerdaCarga(fluido, vazao);
            err = Math.Abs(fX);
            deri = ((this.CalcAlturaBomba(vazao + eps) - tubulacao.CalculaPerdaCarga(fluido, vazao + eps))
                - (this.CalcAlturaBomba(vazao - eps) - tubulacao.CalculaPerdaCarga(fluido, vazao - eps))) / (2 * eps);
            Console.WriteLine("deri = {0}", deri);

            while (err > 10E-6)
            {
                vazao = vazao - (fX / deri);
                Console.WriteLine("vazão Iter = {0}", vazao);
                fX = this.CalcAlturaBomba(vazao) - tubulacao.CalculaPerdaCarga(fluido, vazao);
                deri = ((this.CalcAlturaBomba(vazao + eps) - tubulacao.CalculaPerdaCarga(fluido, vazao + eps))
                - (this.CalcAlturaBomba(vazao - eps) - tubulacao.CalculaPerdaCarga(fluido, vazao - eps))) / (2 * eps);
                Console.WriteLine("fX Iter = {0}", fX);

                err = Math.Abs(fX);
                nIte = nIte + 1;
            }
            
            this.vazao = vazao;
            this.alturaManometrica = CalcAlturaBomba(vazao);

            Console.WriteLine("====Altura Final: {0}", this.alturaManometrica);
            Console.WriteLine("====Perda de carga Final: {0}", tubulacao.CalculaPerdaCarga(fluido, vazao));

        }


    }
}