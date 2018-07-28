namespace SimulOP
{
    /// <summary>
    /// Classse para representar contovelos em tubulações.
    /// </summary>
    class Cotovelo : Singularidade 
    {
        /// <summary>
        /// Constructor para o objeto Cotovelo.
        /// </summary>
        /// <param name="comprimentoEqv">Comprimento equivalente da singulariedade [m].</param>
        public Cotovelo(double comprimentoEqv) : base (comprimentoEqv,"Cotovelo")
        {
        }
    }
}