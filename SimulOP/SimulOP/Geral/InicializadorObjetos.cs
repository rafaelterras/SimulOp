namespace SimulOP
{
    /// <summary>
    /// Classe estática para auxiliar a inicialazação de objetos comuns, tendo como parametro apenas o nome do objeto
    /// </summary>
    public static class InicializadorObjetos
    {
        #region Definições dos Materiais
        /// <summary>
        /// Retorna um objeto Material para ser usado junto com os fluidos de OPI
        /// </summary>
        /// <param name="material">O nome do moterial (Ex. "água", "benzeno", "tolueno"...)</param>
        /// <returns>MaterialFluidoOPI correspondente ao material, com densidade e viscosidade</returns>
        public static MaterialFluidoOPI MaterialFluidoOPI(string material)
        {
            double densidade;
            double viscosidade;

            switch (material.ToLower())
            {
                case "água":
                    densidade = 1000.0;
                    viscosidade = 8.90E-4;
                    break;
                case "benzeno":
                    densidade = 868.0;
                    viscosidade = 5.62E-4;
                    break;
                case "tolueno":
                    densidade = 862.1;
                    viscosidade = 5.60E-4;
                    break;
                default:
                    return null;
            }            
            return new MaterialFluidoOPI(material, densidade, viscosidade);
        }

        /// <summary>
        /// Retorna um objeto Material para ser usado junto com os fluidos de OPIII
        /// </summary>
        /// <param name="material">O nome do moterial (Ex. "água", "benzeno", "tolueno"...)</param>
        /// <returns>MaterialFluidoOPIII correspondente ao material, com o coeficiente de Antoine</returns>
        public static MaterialFluidoOPIII MaterialFluidoOPIII(string material)
        {
            double[] coefAntoine;

            switch (material.ToLower())
            {
                case "água":
                    coefAntoine = new double[3] { 4.6543, 1435.264, -64.848 };
                    break;
                case "benzeno":
                    coefAntoine = new double[3] { 4.01814, 1203.835, -53.226 };
                    break;
                case "tolueno":
                    coefAntoine = new double[3] { 4.14157, 1377.578, -50.507 };
                    break;
                case "naftaleno":
                    coefAntoine = new double[3] { 4.27117, 1831.571 , -61.329 };
                    break;
                default:
                    return null;
            }
            return new MaterialFluidoOPIII(material, coefAntoine);            
        }
        #endregion


    }
}
