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
                rugosidade = 4.572E-5,
                comprimento = 10
            };

            tubo1.rugosidadeRelativa = tubo1.rugosidade / tubo1.diametro;

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
                equacaoCurva = new double[] { 0, -2096928, 2649.96, 26 }
            };

            Bomba bomba2 = new Bomba
            {
                equacaoCurva = new double[] { 1, 2096928, -2650.96, 4 }
            };

            Bomba bombaEq = new Bomba
            {

            };

            //Bomba[] arrayBombas = new Bomba[] { bomba1, bomba2 };

            bombaEq.BombaEquivalente(new Bomba[] { bomba1, bomba2 },"Série");


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
            Console.WriteLine("Eq. da bombaEQ: {0}*Q^3 + {1}*Q^2 + {2}*Q^1 + {3}", bombaEq.equacaoCurva[0], bombaEq.equacaoCurva[1], bombaEq.equacaoCurva[2], bombaEq.equacaoCurva[3]);

            bomba1.CalculaVazao(agua, tubo1);
            
            Console.WriteLine("==========Resultados da Simulação========");
            Console.WriteLine("Vazão : {0} m^3/h", bomba1.vazao * 3600);
            Console.WriteLine("Perda de carga  : {0} m", tubo1.perdaCarga);
            Console.WriteLine("Altura da bomba : {0} m", bomba1.alturaManometrica);

            Console.ReadLine();
        }
     }
}

//Hellow World!!
//==========Dados da Simulaçao========
//===>Fluido
//Densidade : 1000 Kg/m^3
//Viscosidade : 0,00089 Pa*s
//===>Tubulaçao
//Diametro : 0,5 m
//Comprimento : 1000 m
//Comprimento Eq das singularidades: 2 m
//Comprimento total: 1002 m
//===>Bomba
//Eq. da bomba: 0*Q^3 + -2096928*Q^2 + 2649,96*Q^1 + 26
//vazao Iter = 0,0181953762292938
//fX Iter = -620,034661985214
//vazao Iter = 0,00977792413833284
//fX Iter = -148,577573646659
//vazao Iter = 0,00590451341515314
//fX Iter = -31,461535514665
//vazao Iter = 0,00448178052856238
//fX Iter = -4,24463476470678
//vazao Iter = 0,00421889910764198
//fX Iter = -0,144915147419651
//vazao Iter = 0,00420926639373939
//fX Iter = -0,000194576954735472
//vazao Iter = 0,00420925342510938
//fX Iter = -3,52681692877832E-10
//====Altura Final: 0,00137209896022839
//====Perda de carga Final: 0,00137209931291008
//==========Resultados da Simulaçao========
//Vazao : 15,1533123303938 m^3/h
//Perda de carga  : 0,00137209931291008 m
//Altura da bomba : 0,00137209896022839 m