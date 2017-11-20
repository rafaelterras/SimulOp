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

            Fluido agua = new Fluido();
            agua.densidade = 1000;
            agua.viscosidade = 8.90E-4;

            Tubulacao tubo1 = new Tubulacao();
            tubo1.Diametro = 0.05;
            tubo1.RugosidadeRelativa = 1E-4;
            tubo1.Comprimento = 2;

            Singularidade s1 = new Singularidade();
            Singularidade s2 = new Singularidade();

            s1.comprimentoEqv = 2;
            s2.comprimentoEqv = 5;

            List<Singularidade> lista = new List<Singularidade>();

            lista.Add(s1);
            lista.Add(s2);

            tubo1.ComprimentoEquivalente = tubo1.ComprEqSing(lista);

       
            Console.WriteLine("Reynolds: {0}",tubo1.CalcReynolds(agua, 0.001));

            Console.WriteLine("Fator de atrito: {0}",tubo1.CalcFAtrito(agua, 0.001));

            Console.WriteLine("Comprimento equivalente: {0}", tubo1.ComprimentoEquivalente);
            Console.WriteLine("Comprimento Total: {0}", tubo1.ComprimentoEquivalente + tubo1.Comprimento);

            Console.WriteLine("Perda de carga: {0}",tubo1.calculaPerdaCarga(agua, 0.01));
                     
            Console.ReadLine();
        }
     }
}
