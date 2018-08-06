using System;
using System.Windows.Forms;

/// <summary>
/// Programa para auxilo do ensino de opreções unitárias.
/// </summary>
namespace SimulOP
{
    /// <summary>
    /// Main classe do programa.
    /// </summary>
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Forms.FormsMaster()); // Inicia o programa no FormsMaster.
        }
     }
}