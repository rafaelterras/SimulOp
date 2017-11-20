using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaMinuta
{
    class Program
    {
        static void Main(string[] args)
        {
            // This is a hello world commentary.  
            Console.WriteLine("Hellow World!!");

            Fluido agua = new Fluido
            {
                densidade = 1000,
                viscosidade = 8.90E-4
            };

            Tubulacao tubo1 = new Tubulacao
            {
                diametro = 0.05,
                rugosidadeRelativa = 1E-4,
                comprimento = 2
            };

            Singularidade s1 = new Singularidade
            {
                comprimentoEqv = 2
            };

            Singularidade s2 = new Singularidade
            {
                comprimentoEqv = 5
            };

            List<Singularidade> lista = new List<Singularidade>
            {
                s1,
                s2
            };

            tubo1.comprimentoEquivalente = tubo1.ComprEqSing(lista);

       
            Console.WriteLine("Reynolds: {0}",tubo1.CalcReynolds(agua, 0.001));

            Console.WriteLine("Fator de atrito: {0}",tubo1.CalcFAtrito(agua, 0.001));

            Console.WriteLine("Comprimento equivalente: {0}", tubo1.comprimentoEquivalente);
            Console.WriteLine("Comprimento Total: {0}", tubo1.comprimentoEquivalente + tubo1.comprimento);

            Console.WriteLine("Perda de carga: {0}",tubo1.CalculaPerdaCarga(agua, 0.01));
                     
            Console.ReadLine();
        }
     }
}
