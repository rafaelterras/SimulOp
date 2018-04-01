namespace SimulOP
{
    /// <summary>
    /// Classe para guardar as informações de componentes materiais
    /// </summary>
    public class Material
    {
        private string componente;

        /// <summary>
        /// Nome do componente da material (Ex. água, benzeno, ect...)
        /// </summary>
        public string Componente { get => componente; }

        /// <summary>
        /// Constructor do objeto Material
        /// </summary>
        /// <param name="componente">Nome do componente da material (Ex. água, benzeno, ect...)</param>
        public Material(string componente)
        {
            this.componente = componente.ToLower();
        }
    }
}
