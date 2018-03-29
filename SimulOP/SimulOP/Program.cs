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
            if (false)
            {
                Console.WriteLine("======== Teste com Math.net ==========");
                Console.WriteLine("");

                // Cria o fluido agua usando o constructor
                Fluido agua = new Fluido(1000, 8.90E-4);

                // Cria a tubulação tubo1 usando o constructor
                Tubulacao tubo1 = new Tubulacao(0.05, 10, 4.572E-5, 0);

                // Cira as singularidades usando o constructor
                Singularidade s1 = new Singularidade(1, "Cotovelo");
                Singularidade s2 = new Singularidade(2, "Cotovelo");

                // Cria um tipo especifico de singularidade
                Valvula valvula = new Valvula(20);

                tubo1.ListaSingulariedades = new List<Singularidade> { s1, s2, valvula};

                Bomba bomba1 = new Bomba(new double[] { 0, -2096928, 2649.96, 26 }, agua, tubo1);
                
                Console.WriteLine("==========Dados da Simulação========");
                Console.WriteLine("===>Fluido");
                Console.WriteLine("Densidade : {0} Kg/m^3", agua.Densidade);
                Console.WriteLine("Viscosidade : {0} Pa*s", agua.Viscosidade);
                Console.WriteLine("===>Tubulação");
                Console.WriteLine("Diametro : {0} m", tubo1.Diametro);
                Console.WriteLine("Comprimento : {0} m", tubo1.Comprimento);
                Console.WriteLine("Comprimento Eq das singularidades: {0} m", tubo1.ComprimentoEquivalente);
                Console.WriteLine("Comprimento total: {0} m", tubo1.ComprimentoEquivalente + tubo1.Comprimento);
                Console.WriteLine("===>Bomba");
                Console.WriteLine("Eq. da bomba: {0}*Q^3 + {1}*Q^2 + {2}*Q^1 + {3}", bomba1.EquacaoCurva[0], bomba1.EquacaoCurva[1], bomba1.EquacaoCurva[2], bomba1.EquacaoCurva[3]);


                bomba1.CalculaVazao();

                Console.WriteLine("==========Resultados da Simulação========");
                Console.WriteLine("Vazão : {0} m^3/h", bomba1.Vazao * 1);
                Console.WriteLine("Perda de carga  : {0} m", bomba1.Tubulacao.PerdaCarga);
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