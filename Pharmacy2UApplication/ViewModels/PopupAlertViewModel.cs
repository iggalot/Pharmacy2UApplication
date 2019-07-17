
using System;
using System.Windows.Input;

namespace Pharmacy2UApplication
{
    public class PopupAlertViewModel : BaseViewModel
    {
        #region Public Commands

        /// <summary>
        /// The command for when the popup window is activated
        /// </summary>
        public ICommand PopupWindowCommand { get; set; }

        /// <summary>
        /// True to show the popup window
        /// </summary>
        public bool PopupWindowVisible { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public PopupAlertViewModel()
        {
            // Create commands
            PopupWindowCommand = new RelayCommand(TogglePopupWindow);

            // Set the starting visibility of the PopupWindow as Visible
            PopupWindowVisible = false;
        }

        /// <summary>
        /// A function that sets the visibility of the popup window and notifies
        /// the UI when it has changed.
        /// </summary>
        /// <param name="v">The boolean setting for the visibility</param>
        internal void SetPopupWindowVisible(bool v)
        {
            PopupWindowVisible = v;
            OnPropertyChanged("PopupWindowVisible");
        }
        #endregion

        #region Command Methods

        /// <summary>
        /// When the popup window is activated show/hide (toggle) the popup
        /// </summary>
        public void TogglePopupWindow()
        {
            // Toggle the popup window visbility
            PopupWindowVisible ^= true;
            OnPropertyChanged("PopupWindowVisible");
        }

        #endregion
    }
}
