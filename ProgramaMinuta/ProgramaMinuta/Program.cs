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

            Console.WriteLine(tubo1.CalcReynolds(agua, 0.001));

            Console.WriteLine(tubo1.CalcFAtrito(agua, 0.001));
        
            Filtro filtro = new Filtro();

            Console.WriteLine(filtro.CalcReynolds(1000,8.9E-4,1,0.05));

         
            Console.ReadKey();
        }
     }
}
