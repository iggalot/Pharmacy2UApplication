
using Pharmacy2UApplication.Core;
using System;
using System.Windows;

namespace Pharmacy2U_PopupDatabaseMonitor
{
    /// <summary>
    /// Viewmodel for the custom flat window
    /// </summary>
    public class WindowViewModel : BaseViewModel
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

        /// <summary>
        /// The upper left corner's left position of our popup window location
        /// </summary>
        private double mUpperCornerLeftPosition;

        /// <summary>
        /// The upper left corner's top position of our popup window location
        /// </summary>
        private double mUpperCornerTopPosition;

        #endregion

        #region Public Properties

        /// <summary>
        /// The animation speed in milliseconds for use in awaiting the animation in the codebehind
        /// </summary>
        public static int AnimationSpeed { get; set; } = 500;

        /// <summary>
        /// The duration the popup animation should take for binding to Duration in the XAML code
        /// </summary>
        public Duration AnimationDuration { get; set; } = new Duration(new TimeSpan(0, 0, 0, AnimationSpeed));

        /// <summary>
        /// The upper left corner position of the window
        /// </summary>
        public double UpperCornerLeftPosition
        {
            get => mUpperCornerLeftPosition;
            set
            {
                // If no change, do nothing...
                if (mUpperCornerLeftPosition == value)
                    return;

                // Obtain the left position of the window
                // If the specified window width is bigger than the primary screen width, set the position to 0 and change the 
                // WidowMinimumWidth to the actual window width
                if (mUpperCornerLeftPosition < 0)
                {
                    mUpperCornerLeftPosition = 0;
                    WindowMinimumWidth = SystemParameters.FullPrimaryScreenWidth;
                }

                // Signal that the position has changed...
                OnPropertyChanged(nameof(UpperCornerLeftPosition));
            }
        }

        /// <summary>
        /// The upper top corner position of the window
        /// </summary>
        public double UpperCornerTopPosition
        {
            get => mUpperCornerTopPosition;
            set
            {
                // If no change, do nothing...
                if (mUpperCornerTopPosition == value)
                    return;

                // Obtain the top position of the window
                // If the specified window height is bigger than the primary screen height, set the position to 0 and change the 
                // WidowMinimumHeight to the actual window height
                if (mUpperCornerTopPosition < 0)
                {
                    mUpperCornerTopPosition = 0;
                    WindowMinimumHeight = SystemParameters.FullPrimaryScreenHeight;
                }

                // Signal that the position has changed...
                OnPropertyChanged(nameof(UpperCornerTopPosition));
            }
        }

        // The smallest width the window can assume
        public double WindowMinimumWidth { get; set; } = 300;

        // The smallest height the window can assume
        public double WindowMinimumHeight { get; set; } = 300;

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


        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="window"></param>
        public WindowViewModel(Window window)
        {
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

            // Set our startup window position
            mUpperCornerLeftPosition = SystemParameters.PrimaryScreenWidth - WindowMinimumWidth - OuterMarginSize*5;
            UpperCornerLeftPosition = mUpperCornerLeftPosition;

            // Obtain the top position of the window
            // If the specified window height is bigger than the primary screen height, set the position to 0 and change the 
            // WidowMinimumHeight to the actual window height
            mUpperCornerTopPosition = SystemParameters.PrimaryScreenHeight - WindowMinimumHeight - OuterMarginSize*5;
            UpperCornerTopPosition = mUpperCornerTopPosition;
        }

        #endregion

        //#region Private Helpers

        ///// <summary>
        ///// Gets the current mouse position on the screen
        ///// </summary>
        ///// <returns></returns>
        //private Point GetMousePosition()
        //{
        //    // Position of the mouse relative to the window
        //    var position = Mouse.GetPosition(mWindow);

        //    // Add the window position so it's a "ToScreen"
        //    return new Point(position.X + mWindow.Left, position.Y + mWindow.Top);
        //}

        //#endregion
    }
}
