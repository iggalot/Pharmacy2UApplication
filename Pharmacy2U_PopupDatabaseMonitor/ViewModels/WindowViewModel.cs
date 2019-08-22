
using Pharmacy2UApplication.Core;
using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

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

        /// <summary>
        /// The current count
        /// </summary>
        private int mCurrentRecordCount;

        /// <summary>
        /// The previous count
        /// </summary>
        private int mPreviousRecordCount;

        /// <summary>
        /// The number of new records
        /// </summary>
        private int mNewRecordCount;

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

        /// <summary>
        /// The current count of records in the database
        /// </summary>
        public int CurrentRecordCount
        {
            get => mCurrentRecordCount;
            set
            {
                // If the value didn't change
                if (mCurrentRecordCount == value)
                    return;

                // Otherwise set the value
                mCurrentRecordCount = value;

                // Notify that the value has changed
                OnPropertyChanged(nameof(CurrentRecordCount));
            }
        }

        /// <summary>
        /// The count of records from the last time the popup was acknowledged
        /// </summary>
        public int PreviousRecordCount
        {
            get => mPreviousRecordCount;
            set
            {
                // If the value didn't change
                if (mPreviousRecordCount == value)
                    return;

                // Otherwise set the value
                mPreviousRecordCount = value;

                // Notify that the value has changed
                OnPropertyChanged(nameof(PreviousRecordCount));
            }
        }

        /// <summary>
        /// The number of non-acknowledge (or new) records
        /// </summary>
        public int NewRecordCount
        {
            get => mNewRecordCount;
            set
            {
                // If the value didn't change
                if (mNewRecordCount == value)
                    return;

                // Otherwise set the value
                mNewRecordCount = value;

                // Notify that the value has changed
                OnPropertyChanged(nameof(NewRecordCount));

                // Notify that the related text string should also be changed
                OnPropertyChanged(nameof(NewRecordCountString));
            }
        }

        /// <summary>
        /// The display string for the number of new records currently available for viewing
        /// </summary>
        public string NewRecordCountString { get => NewRecordCount.ToString() + " new records available."; }

        /// <summary>
        /// The command that is fired when the Acknowledge Button is clicked
        /// </summary>
        public ICommand AcknowledgeCommand { get; set; }

        /// <summary>
        /// The command that is fired when a change alert has been signaled
        /// </summary>
        public ICommand AlertChangeCommand { get; set; }


        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="window"></param>
        public WindowViewModel(Window window)
        {
            mWindow = window;

            // Create commands for our controls
            AcknowledgeCommand = new RelayCommand(Acknowledge);
            AlertChangeCommand = new RelayCommand(AlertChange);

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

            // Artificially set our previous records count
            // TODO:  Only do this on the initial firing.  Maybe make the popup fire immediately upon load?
            //IoC.Get<DatabaseQueryViewModel>().SetPreviousRecordCount(0);
            //PreviousRecordCount = 0;
        }

        #endregion

        #region Commands
        /// <summary>
        /// Signal that the alert has been detected
        /// </summary>
        private void AlertChange()
        {
            // Find the popup control on the window by name
            Popup mypop = (Popup)mWindow.FindName("MyPopup");

            // And signal that it should open
            mypop.IsOpen = true;

            // Retrieve the records coints from the database query view model
            CurrentRecordCount = IoC.Get<DatabaseQueryViewModel>().GetCurrentRecordCount();
            PreviousRecordCount = IoC.Get<DatabaseQueryViewModel>().GetPreviousRecordCount();
            NewRecordCount = CurrentRecordCount - PreviousRecordCount;
        }

        /// <summary>
        /// Acknowledge that the popup has been activated and noticed by the user
        /// </summary>
        private void Acknowledge()
        {
            // TODO: Implement Acknowledgement actions

            // 1. Open other main application if necessary
            // 2. Verify communication with the other application

            // 3. Signal main application that it should show new records if its not already busy (Editing or creating)

            // 4. Play the storyboard for closing the popup

            // 5. Signal the popup is closed

            // 6. Update the counts
            
            IoC.Get<DatabaseQueryViewModel>().SetPreviousRecordCount(CurrentRecordCount);
        }

        #endregion

    }
}
