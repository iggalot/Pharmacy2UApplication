

namespace Pharmacy2UApplication
{
    /// <summary>
    /// The application state as a view model
    /// </summary>
    public class ApplicationViewModel : BaseViewModel
    {
        #region Private members

        /// <summary>
        /// Should the database logging control be visibile?
        /// </summary>
        private bool shouldHideDatabaseLogging;

        /// <summary>
        /// Should the debug tools control be visibile?
        /// </summary>
        private bool shouldHideDebugTools;

        #endregion

        #region Public Properties
        /// <summary>
        /// The current page of the application
        /// </summary>
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Login;

        /// <summary>
        /// A bool variable to indicate whether database logging should be visibile in the main window
        /// </summary>
        public bool ShouldHideDatabaseLogging
        {
            get => shouldHideDatabaseLogging;
            set
            {
                if (shouldHideDatabaseLogging != value)
                {
                    // set the value and notify that the property has changed
                    shouldHideDatabaseLogging = value;

                    // notify that our property has changed
                    OnPropertyChanged(nameof(ShouldHideDatabaseLogging));
                }
            }
        }

        /// <summary>
        /// A bool variable to indicate whether debug tools should be visibile in the main window.
        /// Used for debugging and development purposes
        /// </summary>
        public bool ShouldHideDebugTools
        {
            get => shouldHideDebugTools;
            set
            {
                if (shouldHideDebugTools != value)
                {
                    // set the value and notify that the property has changed
                    shouldHideDebugTools = value;

                    // notify that our property has changed
                    OnPropertyChanged(nameof(ShouldHideDebugTools));
                }
            }
        }

        /// <summary>
        /// The view model to use for the current page when the CurrentPage changes
        /// NOTE: This is not a live up-to-date view model of the current page
        ///       it is simply used to set the view model of the current page 
        ///       at the time it changes
        /// </summary>
        public BaseViewModel CurrentPageViewModel { get; set; }

        public string TestString { get; set; } = "ApplicationVieWModel Test string";

        /// <summary>
        /// Our sql connection view model
        /// </summary>
        public SQLServerConnect SQLServerConnection { get; set; }

        /// <summary>
        /// Our database monitor apparatus
        /// </summary>
        public DBMonitor DatabaseMonitor { get; set; }

        /// <summary>
        /// Our popup alert window
        /// </summary>
        public PopupAlertViewModel PopupAlertWindow { get; set; }
    

        #endregion

        #region Constructor

        public ApplicationViewModel()
        {
            // Testing of our C# to SQL connectivity
            SQLServerConnection = new SQLServerConnect("test");

            // Our DatabaseMonitor System for tracking when a database has changed
            DatabaseMonitor = new DBMonitor(SQLServerConnection);

            // The view model that controls our popup window
            PopupAlertWindow = new PopupAlertViewModel();

            // Should the database logging window be hidden?
            ShouldHideDatabaseLogging = false;

            // Should the debugging tools window and buttons be hidden?
            ShouldHideDebugTools = false;
        }

        #endregion

        #region Public Helper Methods

        /// <summary>
        /// Navigates to the specified page
        /// </summary>
        /// <param name="page">The page to go to</param>
        /// <param name="viewModel">The view model, if any, to set explicitly to the new page</param>
        public void GoToPage(ApplicationPage page, BaseViewModel viewModel = null)
        {

            // Set the view model
            CurrentPageViewModel = viewModel;

            // See if page has changed
            var different = CurrentPage != page;

            // Set the current page
            CurrentPage = page;

            //// If the page hasn't changed, fire off notification
            //// So pages still update if just the view model has changed
            //if (!different)
            //    OnPropertyChanged(nameof(CurrentPage));

            // Notify the UI that a change has been made to the current page.
            OnPropertyChanged(nameof(CurrentPage));
        }

        #endregion
        
    }
}
