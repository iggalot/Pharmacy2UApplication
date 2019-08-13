using Pharmacy2UApplication.Core;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Pharmacy2UApplication
{
    /// <summary>
    /// Interaction logic for OrderItemControl.xaml
    /// </summary>
    public partial class FoodListItemControl : BaseControl
    {
        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public FoodListItemControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Methods

        private void SelectItem_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //// Cast sender to the control type -- in this case a button
            //Button mybutton = (Button)sender;

            //// Create the data object from the datacontext of the sender.
            //FoodListItemViewModel myObject = mybutton.DataContext as FoodListItemViewModel;

            //// If the item is already in edit mode, do nothing
            //if (myObject.IsEditEnabled)
            //    return;

            //// Toggle the expanded view mode
            //myObject.IsExpanded ^= true;
        }

        #endregion

        private void OpenEdit_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Cast sender to the control type -- in this case a button
            Button mybutton = (Button)sender;

            // Create the data object from the datacontext of the sender.
            FoodListItemViewModel myObject = mybutton.DataContext as FoodListItemViewModel;

            // enable the editor
            myObject.IsEditEnabled = true;

            // Stop the event from bubbling up to the user control
            e.Handled = true;

        }
    }
}
