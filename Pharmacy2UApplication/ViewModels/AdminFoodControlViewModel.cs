using Pharmacy2UApplication.Core;

namespace Pharmacy2UApplication
{
    public class AdminFoodControlViewModel : BaseViewModel
    {
        #region Private Members

        // Is the control in edit mode?
        private bool mIsEditEnabled;

        // The price of the food item
        private decimal mPrice;

        // The name of the food item
        private string mName;

        // The description of the food item
        private string mDescription;

        // Is the item taxable?
        private bool mTaxable;

        // The type of food item
        private string mType;

        #endregion

        #region Public Methods

        // A string to display the mode (whether its view mode or editing mode for the control
        public string ModeText
        {
            get => IsEditEnabled ? "Edit Mode" : "";
        }

        /// <summary>
        /// Is the control in edit mode?
        /// </summary>
        public bool IsEditEnabled {
            get => mIsEditEnabled;
            set
            {
                // if the value doesnt change, exit
                if (value != mIsEditEnabled)
                {
                    // Set the value and notify that the property has changed
                    mIsEditEnabled = value;

                    // Notify that the property has changed
                    OnPropertyChanged(nameof(IsEditEnabled));
                }
            }
        }

        /// <summary>
        /// The name of the food item
        /// </summary>
        public string FoodName
        {
            get => mName;
            set
            {
                // if the value doesnt change, exit
                if (value != mName)
                {
                    // Set the value and notify that the property has changed
                    mName = value;

                    // Notify that the property has changed
                    OnPropertyChanged(nameof(FoodName));
                }
            }
        }

        /// <summary>
        /// The description of the food item
        /// </summary>
        public string FoodDescription
        {
            get => mDescription;
            set
            {
                // if the value doesnt change, exit
                if (value != mDescription)
                {
                    // Set the value and notify that the property has changed
                    mDescription = value;

                    // Notify that the property has changed
                    OnPropertyChanged(nameof(FoodDescription));
                }
            }
        }

        /// <summary>
        /// The price of the food item
        /// </summary>
        public decimal FoodPrice
        {
            get => mPrice;
            set
            {
                // if the value doesnt change, exit
                if (value != mPrice)
                {
                    // Set the value and notify that the property has changed
                    mPrice = value;

                    // Notify that the property has changed
                    OnPropertyChanged(nameof(FoodPrice));
                }
            }
        }

        /// <summary>
        /// Is the food item taxable?
        /// </summary>
        public bool FoodTaxable
        {
            get => mTaxable;
            set
            {
                // if the value doesnt change, exit
                if (value != mTaxable)
                {
                    // Set the value and notify that the property has changed
                    mTaxable = value;

                    // Notify that the property has changed
                    OnPropertyChanged(nameof(FoodTaxable));
                }
            }
        }

        /// <summary>
        /// The type of food
        /// </summary>
        public string FoodType
        {
            get => mType;
            set
            {
                // if the value doesnt change, exit
                if (value != mType)
                {
                    // Set the value and notify that the property has changed
                    mType = value;

                    // Notify that the property has changed
                    OnPropertyChanged(nameof(FoodType));
                }
            }
        }

        #endregion

        // Default constructor
        public AdminFoodControlViewModel()
        {
            // Set editing mode to false by default
            mIsEditEnabled = false;

            // TODO:  Link this constructor to the datacontext for actual data
            // Initial values for this view model
            FoodName = "testItem1";
            FoodDescription = "testdescription1";
            FoodPrice = (decimal)2.34;
            FoodTaxable = true;
            FoodType = "liquid";

            // TODO:  Have the ViewModel save the data back to the database....

        }

        public void UpdateDatabase()
        {
            // TODO:  Save the data to the database...
            // If its a new item...

            // If its a modified item...

        }
    }
}
