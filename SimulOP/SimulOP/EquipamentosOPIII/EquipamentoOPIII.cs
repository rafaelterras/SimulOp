using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimulOP
{
    public abstract class EquipamentoOPIII : Equipamentos
    {
        public enum CondicaoMistura
        {
            Líquido_sub_resfriado = 0,
            Líquido_saturado = 1,
            Parcialmente_vaporizado = 2,
            Vapor_saturado = 3,
            Vapor_super_aquecido = 4,
        }

        public CondicaoMistura CondicaoMisturaParaEnum(string condicao)
        {
            switch (condicao.ToLower())
            {
                case "líquido sub-resfriado":
                    return CondicaoMistura.Líquido_sub_resfriado;
                case "líquido saturado":
                    return CondicaoMistura.Líquido_saturado;
                case "parcialmente vaporizado":
                    return CondicaoMistura.Parcialmente_vaporizado;
                case "vapor saturado":
                    return CondicaoMistura.Vapor_saturado;
                case "vapor super aquecido":
                    return CondicaoMistura.Vapor_super_aquecido;
                default:
                    throw new Exception($"Condição do líquido de entrada não estabelecida, o valor [{condicao}] não era esperado!");
            }
        }
    }
}