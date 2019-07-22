
using Pharmacy2UApplication.Core;
using System.Windows;
using System.Windows.Input;

namespace Pharmacy2UApplication
{
    /// <summary>
    /// Viewmodel for the custom flat window
    /// </summary>
    public class WindowViewModel :BaseViewModel
    {
        #region Private Members

        /// <summary>
        /// The window this view model controls
        /// </summary>
        private Window mWindow;

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        private int mOuterMarginSize = 10;

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        private int mWindowRadius = 10;

        #endregion

        //#region Public Accessors
        //// Our sql connection view model
        //public static SQLServerConnect SQLServerConnection { get; set; }

        //// Our database monitor apparatus
        //public static DBMonitor DatabaseMonitor { get; set; }

        //#endregion

        #region Public Properties

        // The smallest width the window can assume
        public double WindowMinimumWidth { get; set; } = 400;

        // The smallest height the window can assume
        public double WindowMinimumHeight { get; set; } = 400;


        /// <summary>
        /// The size of the resize border around the window
        /// </summary>
        public int ResizeBorder { get; set; } = 6;

        /// <summary>
        /// The size of resize border around the window, taking into account the outer margin
        /// </summary>
        public Thickness ResizeBorderThickness { get => new Thickness(ResizeBorder + OuterMarginSize); }

        /// <summary>
        /// The padding for the inner content of the main window
        /// </summary>
        public Thickness InnerContentPadding { get => new Thickness(ResizeBorder); }


        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        public int OuterMarginSize
        {
            get => mWindow.WindowState == WindowState.Maximized ? 0 : mOuterMarginSize;
            set { mOuterMarginSize = value; }
        }

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        public Thickness OuterMarginSizeThickness
        {
            get => new Thickness(OuterMarginSize);
        }

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        public int WindowRadius
        {
            get => mWindow.WindowState == WindowState.Maximized ? 0 : mWindowRadius;
            set { mWindowRadius = value; }
        }

        /// <summary>
        /// The corner radius of the edges of the window
        /// </summary>
        public CornerRadius WindowCornerRadius { get => new CornerRadius(WindowRadius); }

        /// <summary>
        /// The height of the title bar / caption of the window
        /// </summary>
        public int TitleHeight { get; set; } = 42;

        /// <summary>
        /// The height of the title bar / caption of the window
        /// </summary>
        public GridLength TitleHeightGridLength { get => new GridLength(TitleHeight + ResizeBorder); }



        #endregion

        #region Commands

        /// <summary>
        /// The command to minimize the window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// The command to maximize the window
        /// </summary>
        public ICommand MaximizeCommand { get; set; }

        /// <summary>
        /// The command to close the window
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// The command to show the system menu
        /// </summary>
        public ICommand MenuCommand { get; set; }



        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="window"></param>
        public WindowViewModel(Window window)
        {
            //// Testing of our C# to SQL connectivity
            //SQLServerConnection = new SQLServerConnect("test");

            //// Our DatabaseMonitor System for tracking when a database has changed
            //DatabaseMonitor = new DBMonitor(SQLServerConnection);

            mWindow = window;

            // Listen out for the window resizing
            mWindow.StateChanged += (sender, e) =>
            {
                // Fire off event for all properties that are affected by a resize
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };

            // Create commands for the application window
            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => mWindow.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(mWindow, GetMousePosition()));

            // Fix window resize issue
            var resizer = new WindowResizer(mWindow);
        }


        #endregion

        #region Private Helpers

        /// <summary>
        /// Gets the current mouse position on the screen
        /// </summary>
        /// <returns></returns>
        private Point GetMousePosition()
        {
            // Position of the mouse relative to the window
            var position = Mouse.GetPosition(mWindow);

            // Add the window position so it's a "ToScreen"
            return new Point(position.X + mWindow.Left, position.Y + mWindow.Top);
        }

        #endregion
    }
}
