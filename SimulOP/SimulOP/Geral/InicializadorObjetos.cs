namespace SimulOP
{
    /// <summary>
    /// Classe estática para auxiliar a inicialazação de objetos comuns, tendo como parametro apenas o nome do objeto
    /// </summary>
    public static class InicializadorObjetos
    {
        #region Definições dos Materiais
        /// <summary>
        /// Retorna um objeto Material para ser usado junto com os fluidos de OPI.
        /// </summary>
        /// <param name="material">O nome do moterial (Ex. "água", "benzeno", "tolueno"...).</param>
        /// <returns>MaterialFluidoOPI correspondente ao material, com densidade e viscosidade.</returns>
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
        /// <param name="material">O nome do moterial (Ex. "água", "benzeno", "tolueno"...).</param>
        /// <returns>MaterialFluidoOPIII correspondente ao material, com o coeficiente de Antoine.</returns>
        public static MaterialFluidoOPIII MaterialFluidoOPIII(string material)
        {
            double[] coefAntoine;
            double densidade;
            double viscosidade;

            switch (material.ToLower())
            {
                case "água":
                    coefAntoine = new double[3] { 4.6543, 1435.264, -64.848 };
                    densidade = 1000.0;
                    viscosidade = 8.90E-4;
                    break;
                case "benzeno":
                    coefAntoine = new double[3] { 4.01814, 1203.835, -53.226 };
                    densidade = 868.0;
                    viscosidade = 5.62E-4;
                    break;
                case "tolueno":
                    coefAntoine = new double[3] { 4.14157, 1377.578, -50.507 };
                    densidade = 862.1;
                    viscosidade = 5.60E-4;
                    break;
                case "hexano":
                    coefAntoine = new double[3] { 4.00266, 1171.53, -48.784 };
                    densidade = 655;
                    viscosidade = 3.0E-4;
                    break;
                case "p-xileno":
                    coefAntoine = new double[3] { 4.14553, 1474.403, -55.377 };
                    densidade = 870;
                    viscosidade = 8.12E-4;
                    break;
                default:
                    return null;
            }
            return new MaterialFluidoOPIII(material, densidade, viscosidade, coefAntoine);
        }

        /// <summary>
        /// Retorna um objeto Material para ser usado junto com os fluidos de OPII.
        /// </summary>
        /// <param name="material">O nome do moterial (Ex. "água", "benzeno", "tolueno"...).</param>
        /// <param name="temperatura">A temperatura do material.</param>
        /// <returns>MaterialFluidoOPII correspondente ao material.</returns>
        public static MaterialFluidoOPII MaterialFluidoOPII(string material, double temperatura)
        {
            double MM;
            double[] coefCorrelDensidade;
            double[] coefCorrelViscosidade;
            double[] coefCorrelCalorEspecifico;
            double[] coefCorrelCondutividadeTermica;

            switch (material.ToLower())
            {
                case "água":
                    MM = 18.01;
                    coefCorrelDensidade = new double[4] { 0.3471, 0.274, 647.13, 0.28571 };
                    coefCorrelViscosidade = new double[4] { -10.2158, 1792.5, 0.01773, -0.000012631 };
                    coefCorrelCalorEspecifico = new double[4] { 92.053, -0.039953, -0.00021103, 0.00000053469 };
                    coefCorrelCondutividadeTermica = new double[3] { -0.2758, 0.004612, -0.0000055391 };
                    break;
                case "benzeno":
                    MM = 78.11;
                    coefCorrelDensidade = new double[4] { 0.3009, 0.2677, 562.16, 0.2818 };
                    coefCorrelViscosidade = new double[4] { -7.4005, 1181.5, 0.014888, -1.3713e-5 };
                    coefCorrelCalorEspecifico = new double[4] { -31.662, 1.3043, -0.0036078, 0.0000038243 };
                    coefCorrelCondutividadeTermica = new double[3] { -1.6846, 1.052, 562.16 };
                    break;
                case "tolueno":
                    MM = 92.14;
                    coefCorrelDensidade = new double[4] { 0.29999, 0.27108, 591.79, 0.29889 };
                    coefCorrelViscosidade = new double[4] { -5.1649, 810.68, 0.010454, -0.000010488 };
                    coefCorrelCalorEspecifico = new double[4] { 83.703, 0.51666, -0.001491, 0.0000019725 };
                    coefCorrelCondutividadeTermica = new double[3] { -1.6735, 0.9773, 591.79 };
                    break;
                default:
                    return null;
            }

            return new MaterialFluidoOPII(material, MM, temperatura, coefCorrelDensidade, coefCorrelViscosidade, 
                coefCorrelCalorEspecifico, coefCorrelCondutividadeTermica);
        }
        #endregion

        #region Definição da Tubulação

        public static MaterialTubulacao MaterialTubulacao(string material)
        {
            double rugosidade; // em cm

            switch (material.ToLower())
            {
                case "aço carbono":
                    rugosidade = 0.00547;
                    break;
                case "pvc":
                    rugosidade = 0.006;
                    break;
                case "cobre":
                    rugosidade = 0.0002;
                    break;
                case "aço inoxidável":
                    rugosidade = 0.0002;
                    break;
                case "concreto":
                    rugosidade = 0.2;
                    break;
                default:
                    rugosidade = 0.00547;
                    break;
            }

            return new MaterialTubulacao(rugosidade / 100.0, material);
        }
        
        public static Tubulacao Tubulacao(string material, EquipamentoOPI.DiamPol diamPol, EquipamentoOPI.SchNum schNum, double comprimento, double elevacao, string metodoFAtrito = "fanning")
        {
            double diametroInt;
            MaterialTubulacao materialTubulacao = MaterialTubulacao(material);

            diametroInt = SchParaDiametro(diamPol, schNum);

            return new Tubulacao(diametroInt, comprimento, materialTubulacao, elevacao, metodoFAtrito);
        }

        public static double SchParaDiametro(EquipamentoOPI.DiamPol diamPol, EquipamentoOPI.SchNum schNum)
        {
            double diametroInt = 0;

            switch (diamPol)
            {
                case EquipamentoOPI.DiamPol.pol1:
                    switch (schNum)
                    {
                        case EquipamentoOPI.SchNum.Sch20:
                            diametroInt = 1.097;
                            break;
                        case EquipamentoOPI.SchNum.Sch40:
                            diametroInt = 1.049;
                            break;
                        case EquipamentoOPI.SchNum.Sch80:
                            diametroInt = 0.957;
                            break;
                        case EquipamentoOPI.SchNum.Sch100:
                            diametroInt = 0.815;
                            break;
                    }
                    break;
                case EquipamentoOPI.DiamPol.pol1_5:
                    switch (schNum)
                    {
                        case EquipamentoOPI.SchNum.Sch20:
                            diametroInt = 1.682;
                            break;
                        case EquipamentoOPI.SchNum.Sch40:
                            diametroInt = 1.610;
                            break;
                        case EquipamentoOPI.SchNum.Sch80:
                            diametroInt = 1.500;
                            break;
                        case EquipamentoOPI.SchNum.Sch100:
                            diametroInt = 1.338;
                            break;
                    }
                    break;
                case EquipamentoOPI.DiamPol.pol2:
                    switch (schNum)
                    {
                        case EquipamentoOPI.SchNum.Sch20:
                            diametroInt = 2.157;
                            break;
                        case EquipamentoOPI.SchNum.Sch40:
                            diametroInt = 2.067;
                            break;
                        case EquipamentoOPI.SchNum.Sch80:
                            diametroInt = 1.939;
                            break;
                        case EquipamentoOPI.SchNum.Sch100:
                            diametroInt = 1.687;
                            break;
                    }
                    break;
                case EquipamentoOPI.DiamPol.pol4:
                    switch (schNum)
                    {
                        case EquipamentoOPI.SchNum.Sch20:
                            diametroInt = 4.260;
                            break;
                        case EquipamentoOPI.SchNum.Sch40:
                            diametroInt = 4.062;
                            break;
                        case EquipamentoOPI.SchNum.Sch80:
                            diametroInt = 3.826;
                            break;
                        case EquipamentoOPI.SchNum.Sch100:
                            diametroInt = 3.624;
                            break;
                    }
                    break;
                case EquipamentoOPI.DiamPol.pol10:
                    switch (schNum)
                    {
                        case EquipamentoOPI.SchNum.Sch20:
                            diametroInt = 10.250;
                            break;
                        case EquipamentoOPI.SchNum.Sch40:
                            diametroInt = 10.020;
                            break;
                        case EquipamentoOPI.SchNum.Sch80:
                            diametroInt = 9.562;
                            break;
                        case EquipamentoOPI.SchNum.Sch100:
                            diametroInt = 9.312;
                            break;
                    }
                    break;
                case EquipamentoOPI.DiamPol.pol20:
                    switch (schNum)
                    {
                        case EquipamentoOPI.SchNum.Sch20:
                            diametroInt = 19.250;
                            break;
                        case EquipamentoOPI.SchNum.Sch40:
                            diametroInt = 18.812;
                            break;
                        case EquipamentoOPI.SchNum.Sch80:
                            diametroInt = 17.938;
                            break;
                        case EquipamentoOPI.SchNum.Sch100:
                            diametroInt = 17.438;
                            break;
                    }
                    break;
            }

            return diametroInt * 0.0254; // Converte de polegadas para metros
        }
        #endregion
    }
}
