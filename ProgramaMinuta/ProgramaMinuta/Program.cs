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

            Console.WriteLine(tubo1.CalcReynolds(agua, 50));
            Console.WriteLine(tubo1.CalcReynolds(agua, 2));

            Filtro filtro = new Filtro();

            Console.WriteLine(filtro.CalcReynolds(1000,8.9E-4,1,0.1));

            Console.ReadKey();
        }
     }
}
