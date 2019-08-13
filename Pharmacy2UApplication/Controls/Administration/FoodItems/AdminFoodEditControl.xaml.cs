using Pharmacy2UApplication.Core;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Pharmacy2UApplication
{
    /// <summary>
    /// Interaction logic for AdminFoodEditControl.xaml
    /// </summary>
    public partial class AdminFoodEditControl : BaseControl
    {
        #region Public Members

        /// <summary>
        /// The view model for this control
        /// </summary>
        public FoodListViewModel ViewModel { get; set; }

        #endregion

        #region Default Constructor

        public AdminFoodEditControl()
        {
            InitializeComponent();

            // Create our viewmodel for this control
            ViewModel = new FoodListViewModel();

            // Set our datacontext for this control
            DataContext = this;
        }

        #endregion








        private void SaveEditControl_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            //// Test our string date if it is null or empty or whitespace
            //if (string.IsNullOrEmpty(EditFoodName.Text) || string.IsNullOrWhiteSpace(EditFoodName.Text) ||
            //    string.IsNullOrEmpty(EditFoodDescription.Text) || string.IsNullOrWhiteSpace(EditFoodDescription.Text) ||
            //    string.IsNullOrEmpty(EditFoodPrice.Text) || string.IsNullOrWhiteSpace(EditFoodPrice.Text) ||
            //    string.IsNullOrEmpty(EditFoodType.Text) || string.IsNullOrWhiteSpace(EditFoodType.Text))
            //{
            //    MessageBox.Show("All fields must non-null and non-whitespace");
            //    return;
            //}

            ////TODO make some sort of graphical indicator in the viewmodel that there is a problem with a particular view

            //// Otherwise, continue testing the data
            //decimal testDecimal;
            //bool isNumeric = Decimal.TryParse(EditFoodPrice.Text, out testDecimal);
            
            //// If the price string is a numeric decimal value, abort the save
            //if (!isNumeric)
            //{
            //    MessageBox.Show("The price must be a numeric value");
            //    return;
            //}

            //// parse the price
            //decimal priceParse = Decimal.Parse(EditFoodPrice.Text);

            //// Can't have a negative price
            //if (priceParse < 0)
            //{
            //    MessageBox.Show("The price must be a non-negative value");
            //    return;
            //}

            ////TODO:  Check if there are more than two decimal places in the price value...

            //// Otherwise we have valid data presumably, so save it to the view model
            //ViewModel.FoodName = EditFoodName.Text;
            //ViewModel.FoodDescription = EditFoodName.Text;
            //ViewModel.FoodTaxable = (bool)EditFoodTaxable.IsChecked;
            //ViewModel.FoodPrice = Decimal.Parse(EditFoodPrice.Text);
            //ViewModel.FoodType = EditFoodType.Text;

            //// TODO:  Have the ViewModel save the data back to the database....


            //// Finally, reset the the control to nonedit mode
            //ViewModel.IsEditEnabled = false;
        }


        private void CancelEdit_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Cast sender to the control type -- in this case a button
            Button mybutton = (Button)sender;

            // Create the data object from the datacontext of the sender.
            FoodListItemViewModel myObject = mybutton.DataContext as FoodListItemViewModel;

            // disable the editor
            myObject.IsEditEnabled = false;

            // disable the expanded view
            myObject.IsExpanded = false;

            // Stop the event from bubbling up to the user control
            e.Handled = true;

        }

        /// <summary>
        /// The click command that saes changes from the edit form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveEditControl_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            e.Handled = true;
            return;


            // Cast sender to the control type -- in this case a button
            Button mybutton = (Button)sender;

            // Create the data object from the datacontext of the sender.
            AdminFoodEditControl myControl = mybutton.DataContext as AdminFoodEditControl;
            AdminFoodEditControl myParentControl = myControl.DataContext as AdminFoodEditControl;
            AdminFoodEditControl myItemControl = myParentControl.DataContext as AdminFoodEditControl;
            FoodListItemControl myFoodListItemControl = myItemControl.DataContext as FoodListItemControl;
            FoodListItemViewModel myObject = myFoodListItemControl.DataContext as FoodListItemViewModel;

            //FoodListItemViewModel myObject = (mybutton.DataContext as AdminFoodEditControl).DataContext as FoodListItemViewModel;

            //// disable the editor
            //myObject.IsEditEnabled = false;

            //// disable the expanded view
            //myObject.IsExpanded = false;

            //// save the changes that have been made
            //myObject.SaveEditChanges();
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
    }
}
