using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulOP
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (true)
            {
                Console.WriteLine("======== Teste com Math.net ==========");
                Console.WriteLine("");

                Fluido agua = new Fluido
                {
                    densidade = 1000, 
                    viscosidade = 8.90E-4
                };

                Tubulacao tubo1 = new Tubulacao
                {
                    diametro = 0.05,
                    rugosidade = 4.572E-5,
                    comprimento = 10,
                };

                Singularidade s1 = new Singularidade
                {
                    comprimentoEqv = 1
                };

                Singularidade s2 = new Singularidade
                {
                    comprimentoEqv = 1
                };

                tubo1.listaSingulariedades = new List<Singularidade> { s1, s2 };

                tubo1.ComprEqSing();

                Bomba bomba1 = new Bomba(new double[] { 0, -2096928, 2649.96, 26 }, agua, tubo1);


                Console.WriteLine("==========Dados da Simulação========");
                Console.WriteLine("===>Fluido");
                Console.WriteLine("Densidade : {0} Kg/m^3", agua.densidade);
                Console.WriteLine("Viscosidade : {0} Pa*s", agua.viscosidade);
                Console.WriteLine("===>Tubulação");
                Console.WriteLine("Diametro : {0} m", tubo1.diametro);
                Console.WriteLine("Comprimento : {0} m", tubo1.comprimento);
                Console.WriteLine("Comprimento Eq das singularidades: {0} m", tubo1.comprimentoEquivalente);
                Console.WriteLine("Comprimento total: {0} m", tubo1.comprimentoEquivalente + tubo1.comprimento);
                Console.WriteLine("===>Bomba");
                Console.WriteLine("Eq. da bomba: {0}*Q^3 + {1}*Q^2 + {2}*Q^1 + {3}", bomba1.EquacaoCurva[0], bomba1.EquacaoCurva[1], bomba1.EquacaoCurva[2], bomba1.EquacaoCurva[3]);


                bomba1.CalculaVazao();

                Console.WriteLine("==========Resultados da Simulação========");
                Console.WriteLine("Vazão : {0} m^3/h", bomba1.Vazao * 3600);
                Console.WriteLine("Perda de carga  : {0} m", bomba1.Tubulacao.perdaCarga);
                Console.WriteLine("Altura da bomba : {0} m", bomba1.AlturaManometrica);

                Console.ReadLine();
                
            }
            else
            { 
                // This is a hello world commentary.  
                // Console.WriteLine("Hellow World!!");

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormsMaster());
             }            
        }
     }
}