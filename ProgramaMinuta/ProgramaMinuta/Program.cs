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
                viscosidade = 8.90E-4,                
            };

            Tubulacao tubo1 = new Tubulacao
            {
                diametro = 0.05,
                rugosidadeRelativa = 1E-4,
                comprimento = 100
            };

            Singularidade s1 = new Singularidade
            {
                comprimentoEqv = 1
            };

            Singularidade s2 = new Singularidade
            {
                comprimentoEqv = 1
            };

            List<Singularidade> lista = new List<Singularidade>
            {
                s1,
                s2
            };

            tubo1.ComprEqSing(lista);

            Bomba bomba1 = new Bomba
            {
                equacaoCurva = new double[] { 0, 0, -54216, 39.43 }
            };

            Console.WriteLine("==========Dados da Simulação========");
            Console.WriteLine("===>Fluido");
            Console.WriteLine("Densidade : {0} Kg/m^3", agua.densidade);
            Console.WriteLine("Viscosidade : {0} Pa*s", agua.viscosidade);
            Console.WriteLine("===>Tubulação");
            Console.WriteLine("Diametro : {0} m", tubo1.diametro);
            Console.WriteLine("Comprimento : {0} m",tubo1.comprimento);
            Console.WriteLine("Comprimento Eq das singularidades: {0} m", tubo1.comprimentoEquivalente);
            Console.WriteLine("Comprimento total: {0} m", tubo1.comprimentoEquivalente + tubo1.comprimento);
            Console.WriteLine("===>Bomba");
            Console.WriteLine("Eq. da bomba: {0}*Q^3 + {1}*Q^2 + {2}*Q^1 + {3}",bomba1.equacaoCurva[0], bomba1.equacaoCurva[1], bomba1.equacaoCurva[2], bomba1.equacaoCurva[3]);

            bomba1.CalculaVazao(agua, tubo1);

            Console.WriteLine("==========Resultados da Simulação========");
            Console.WriteLine("Vazão : {0} m^3/h", bomba1.vazao * 3600);


            Console.ReadLine();
        }
     }
}
