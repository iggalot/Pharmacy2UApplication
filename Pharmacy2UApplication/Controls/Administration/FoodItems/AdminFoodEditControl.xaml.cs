using Pharmacy2UApplication.Core;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Pharmacy2UApplication
{
    /// <summary>
    /// Interaction logic for AdminFoodEditControl.xaml
    /// </summary>
    public partial class AdminFoodEditControl : BaseControl
    {
        #region Public Members

        ///// <summary>
        ///// The view model for this control
        ///// </summary>
        //public FoodListViewModel ViewModel { get; set; }

        #endregion

        #region Default Constructor

        public AdminFoodEditControl()
        {
            InitializeComponent();

            //// Create our viewmodel for this control
            //ViewModel = new FoodListViewModel();

            //// Set our datacontext for this control
            //DataContext = this;
        }

        #endregion

        #region Click Methods

        /// <summary>
        /// The click command that saves the data from our food editing controls back to the 
        /// appropriate viewmodel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveEditControl_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Test our string data if it is null or empty or whitespace
            if (string.IsNullOrEmpty(FoodItemName.Text) || string.IsNullOrWhiteSpace(FoodItemName.Text) ||
                string.IsNullOrEmpty(FoodItemDescription.Text) || string.IsNullOrWhiteSpace(FoodItemDescription.Text) ||
                string.IsNullOrEmpty(FoodItemPrice.Text) || string.IsNullOrWhiteSpace(FoodItemPrice.Text) ||
                string.IsNullOrEmpty(FoodItemType.Text) || string.IsNullOrWhiteSpace(FoodItemType.Text))
            {
                MessageBox.Show("All fields must non-null and non-whitespace");
                return;
            }

            ////TODO make some sort of graphical indicator in the viewmodel that there is a problem with a particular view

            // Otherwise, continue testing the data
            decimal testDecimal;
            bool isNumeric = Decimal.TryParse(FoodItemPrice.Text, out testDecimal);

            // If the price string is not a numeric decimal value, abort the save
            if (!isNumeric)
            {
                MessageBox.Show("The price must be a numeric value");
                return;
            }

            // parse the price
            //TODO:  Check if there are more than two decimal places in the price value...

            decimal priceParse = Decimal.Parse(FoodItemPrice.Text);

            // Can't have a negative price
            if (priceParse < 0)
            {
                MessageBox.Show("The price must be a non-negative value");
                return;
            }

            // Now retrieve the viewmodel for this item -- which should be the FoodListItemViewModel
            // in the DataContext of the ancestor control.
            var flic = VisualTreeHelperExtensions.FindAncestor<FoodListItemControl>(this);
            FoodListItemViewModel flivm = (FoodListItemViewModel) flic.DataContext;

            // Otherwise we have valid data presumably, so save it back to the view model
            // First find the food list item view control that contains our current food list item view model
            flivm.FoodName = FoodItemName.Text;
            flivm.FoodDescription = FoodItemName.Text;
            flivm.FoodIsTaxable = (bool)FoodItemTaxable.IsChecked;
            flivm.FoodPrice = Decimal.Parse(FoodItemPrice.Text);
            flivm.FoodType = FoodItemType.Text;

            // Copy the data model from the data context to a temporary item for
            // passing to the food list view model.
            FoodListItemViewModel newItem = new FoodListItemViewModel(
                flivm.FoodIDNumber,
                flivm.FoodName,
                flivm.FoodDescription,
                flivm.FoodType,
                flivm.FoodPrice,
                flivm.FoodIsTaxable
                );

            // Find the food list view model from the food list control ancestor
            var flc = VisualTreeHelperExtensions.FindAncestor<FoodListControl>(this);
            FoodListViewModel flvc = (FoodListViewModel)flc.DataContext;

            // Apply the update to the view model
            flvc.UpdateFLIVM(flvc.findFLIVM(flivm.FoodIDNumber), newItem);

            //// TODO:  Have the ViewModel save the data back to the database....

            //// Finally, reset the the control to nonedit mode
            flivm.IsEditEnabled = false;

            //// disable the expanded view
            flivm.IsExpanded = false;
        }

        /// <summary>
        /// The click command that cancels edits to the edit form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelEditControl_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Cast sender to the control type -- in this case a button
            Button mybutton = (Button)sender;

            // Create the data object from the datacontext of the sender.
            FoodListItemViewModel myObject = mybutton.DataContext as FoodListItemViewModel;

            // disable the editor
            myObject.IsEditEnabled = false;

            // disable the expanded view
            myObject.IsExpanded = false;
        }
        #endregion
    }
}
