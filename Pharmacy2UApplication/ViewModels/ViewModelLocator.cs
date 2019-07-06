
namespace Pharmacy2UApplication
{
    /// <summary>
    /// Locates viewmodels from the IoC for use in binding in the XAML files
    /// </summary>
    public class ViewModelLocator
    {
        #region Public Property

        // Singleton instance of the locator
        public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();


        /// <summary>
        /// The application view model
        /// </summary>
        public static ApplicationViewModel ApplicationViewModel => IoC.Get<ApplicationViewModel>();

        #endregion
    }
}
