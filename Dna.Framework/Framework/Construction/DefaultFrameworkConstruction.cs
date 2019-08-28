namespace Dna
{
    /// <summary>
    ///  Creates a defaut framework construction containing our
    ///  default services and configuration
    /// </summary>
    public class DefaultFrameworkConstruction : FrameworkConstruction
    {
        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public DefaultFrameworkConstruction()
        {
            // Configure...
            this.Configure()
                // And add default services
                .UseDefaultServices();
        }

        #endregion
    }
}
