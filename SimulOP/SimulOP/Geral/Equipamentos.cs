﻿using System;
using MathNet.Numerics;

namespace SimulOP
{
    public abstract class Equipamentos
    {
        /// <summary>
        /// Constante: Aceleração da gravidade [m/s^2]
        /// </summary>
        public const double g = 9.80665;

        /// <summary>
        /// Calcula a primeira derivada da função func no ponto x
        /// <param name="func">A função que vai ser derivada. </param>
        /// <param name="x">O ponto em que se deseja calcular a derivada. </param>
        /// <returns> dfunc(t)/dt c/ t = x</returns>
        /// </summary>
        public double PrimeiraDerivada(Func<double, double> func, double x)
        {
            return Differentiate.FirstDerivative(func, x);
        }

        /// <summary>
        /// Acha o zero da função f(x) usando o metodo de Brent
        /// <param name="func">A função que vai ser zerada. </param>
        /// <param name="limiteInf">O limite inferior de onde o zero está. </param>
        /// <param name="limitSup">O limite superior de onde o zero está. </param>
        /// <param name="precisao">A precissão desejada. </param>
        /// <param name="nInte">O número máximo de iterações. </param>
        /// <returns> Retorna x tal que f(x) = 0. </returns>
        /// </summary>
        public static double AchaRaizBrenet(Func<double, double> fx, double limiteInf, double limitSup, double precisao = 1e-08, int nInte = 100)
        {
            try
            {
                return FindRoots.OfFunction(fx, limiteInf, limitSup, precisao, nInte);
            }
            catch (Exception)
            {
                throw new Exception("Erro ao convergir");
            }
        }
    }
}