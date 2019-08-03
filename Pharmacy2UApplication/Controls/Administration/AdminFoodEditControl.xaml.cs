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
        public AdminFoodControlViewModel ViewModel { get; set; }

        #endregion

        #region Default Constructor

        public AdminFoodEditControl()
        {
            InitializeComponent();

            // Create our viewmodel for this control
            ViewModel = new AdminFoodControlViewModel();

            // Set our datacontext for this control
            DataContext = this;
        }

        #endregion

        private void EditControl_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Set the the control to edit mode
            ViewModel.IsEditEnabled = true;

        }

        private void SaveControl_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            // Test our string date if it is null or empty or whitespace
            if (string.IsNullOrEmpty(EditFoodName.Text) || string.IsNullOrWhiteSpace(EditFoodName.Text) ||
                string.IsNullOrEmpty(EditFoodDescription.Text) || string.IsNullOrWhiteSpace(EditFoodDescription.Text) ||
                string.IsNullOrEmpty(EditFoodPrice.Text) || string.IsNullOrWhiteSpace(EditFoodPrice.Text) ||
                string.IsNullOrEmpty(EditFoodType.Text) || string.IsNullOrWhiteSpace(EditFoodType.Text))
            {
                MessageBox.Show("All fields must non-null and non-whitespace");
                return;
            }

            //TODO make some sort of graphical indicator in the viewmodel that there is a problem with a particular view

            // Otherwise, continue testing the data
            decimal testDecimal;
            bool isNumeric = Decimal.TryParse(EditFoodPrice.Text, out testDecimal);
            
            // If the price string is a numeric decimal value, abort the save
            if (!isNumeric)
            {
                MessageBox.Show("The price must be a numeric value");
                return;
            }

            // parse the price
            decimal priceParse = Decimal.Parse(EditFoodPrice.Text);

            // Can't have a negative price
            if (priceParse < 0)
            {
                MessageBox.Show("The price must be a non-negative value");
                return;
            }

            //TODO:  Check if there are more than two decimal places in the price value...

            // Otherwise we have valid data presumably, so save it to the view model
            ViewModel.FoodName = EditFoodName.Text;
            ViewModel.FoodDescription = EditFoodName.Text;
            ViewModel.FoodTaxable = (bool)EditFoodTaxable.IsChecked;
            ViewModel.FoodPrice = Decimal.Parse(EditFoodPrice.Text);
            ViewModel.FoodType = EditFoodType.Text;

            // TODO:  Have the ViewModel save the data back to the database....


            // Finally, reset the the control to nonedit mode
            ViewModel.IsEditEnabled = false;
        }

        private void CancelControl_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Set the the control to nonedit mode
            ViewModel.IsEditEnabled = false;

        }
    }
}
