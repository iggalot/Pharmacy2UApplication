using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Pharmacy2UApplication.Core
{
     public class FoodListItemViewModel : BaseViewModel
    {
        #region Protected Members

        protected int mFoodIDNumber;
        protected string mFoodName;
        protected string mFoodDescription;
        protected string mFoodType;
        protected bool mFoodIsTaxable;
        protected decimal mFoodPrice;

        protected DateTime? mFoodCreatedWhen;
        protected int? mFoodCreatedBy;
        protected DateTime? mFoodModifiedWhen;
        protected int? mFoodModifiedBy;

        /// <summary>
        /// A flag for indicating if the control is enabled for editing
        /// </summary>
        protected bool mIsEditEnabled;

        /// <summary>
        /// A flag for indicating if the control has been expanded for editing
        /// </summary>
        protected bool mIsExpanded;

        #endregion

        #region Public Properties

        /// <summary>
        /// A flag for indicating if the control is enabled for editing
        /// </summary>
        public bool IsEditEnabled
        {
            get => mIsEditEnabled;
            set
            {
                // Check if we are changing the value
                if (mIsEditEnabled == value)
                    return;

                // Otherwise set the value
                mIsEditEnabled = value;

                // Notify the system that a property has been changed
                OnPropertyChanged(nameof(IsEditEnabled));
            }
        }

        /// <summary>
        /// A flag for indicating if the control is expanded for editing
        /// </summary>
        public bool IsExpanded
        {
            get => mIsExpanded;
            set
            {
                // Check if we are changing the value
                if (mIsExpanded == value)
                    return;

                // Otherwise set the value
                mIsExpanded = value;

                // Notify the system that a property has been changed
                OnPropertyChanged(nameof(IsExpanded));
            }
        }

        /// <summary>
        /// The name of the food
        /// </summary>
        public string FoodName
        {
            get => mFoodName;
            set
            {
                // Check if we are changing the value
                if (mFoodName == value)
                    return;

                // Otherwise set the value
                mFoodName = value;

                // Notify the system that a property has been changed
                OnPropertyChanged(nameof(FoodName));
            }
        }

        /// <summary>
        /// The type of the food
        /// </summary>
        public string FoodType
        {
            get => mFoodType;
            set
            {
                // Check if we are changing the value
                if (mFoodType == value)
                    return;

                // Otherwise set the value
                mFoodType = value;

                // Notify the system that a property has been changed
                OnPropertyChanged(nameof(FoodType));
            }
        }

        /// <summary>
        /// The description of the food item
        /// </summary>
        public string FoodDescription
        {
            get => mFoodDescription;
            set
            {
                // Check if we are changing the value
                if (mFoodDescription == value)
                    return;

                // Otherwise set the value
                mFoodDescription = value;

                // Notify the system that a property has been changed
                OnPropertyChanged(nameof(FoodDescription));
            }
        }

        /// <summary>
        /// A flag to indicate if the food item is taxable
        /// </summary>
        public bool FoodIsTaxable
        {
            get => mFoodIsTaxable;
            set
            {
                // Check if we are changing the value
                if (mFoodIsTaxable == value)
                    return;

                // Otherwise set the value
                mFoodIsTaxable = value;

                // Notify the system that a property has been changed
                OnPropertyChanged(nameof(FoodIsTaxable));
            }
        }

        /// <summary>
        /// The price of hte food item
        /// </summary>
        public decimal FoodPrice
        {
            get => mFoodPrice;
            set
            {
                // Check if we are changing the value
                if (mFoodPrice == value)
                    return;

                // Otherwise set the value
                mFoodPrice = value;

                // Notify the system that a property has been changed
                OnPropertyChanged(nameof(FoodPrice));
            }
        }

        /// <summary>
        /// The id number of the food item in the database
        /// </summary>
        public int FoodIDNumber
        {
            get => mFoodIDNumber;
            set
            {
                // Check if we are changing the value
                if (mFoodIDNumber == value)
                    return;

                // Otherwise set the value
                mFoodIDNumber = value;

                // Notify the system that a property has been changed
                OnPropertyChanged(nameof(FoodIDNumber));
            }
        }

        /// <summary>
        /// The datetime when the food item was created in the database
        /// </summary>
        public DateTime? FoodCreatedWhen
        {
            get => mFoodCreatedWhen;
            set
            {
                // Check if we are changing the value
                if (mFoodCreatedWhen == value)
                    return;

                // Otherwise set the value
                mFoodCreatedWhen = value;

                // Notify the system that a property has been changed
                OnPropertyChanged(nameof(FoodCreatedWhen));
            }
        }

        /// <summary>
        /// The datetime when the food item was last modified in the database
        /// </summary>
        public DateTime? FoodModifiedWhen
        {
            get => mFoodModifiedWhen;
            set
            {
                // Check if we are changing the value
                if (mFoodModifiedWhen == value)
                    return;

                // Otherwise set the value
                mFoodModifiedWhen = value;

                // Notify the system that a property has been changed
                OnPropertyChanged(nameof(FoodModifiedWhen));
            }
        }

        /// <summary>
        /// The name of who created the food item in the database
        /// </summary>
        public int? FoodCreatedBy
        {
            get => mFoodCreatedBy;
            set
            {
                // Check if we are changing the value
                if (mFoodCreatedBy == value)
                    return;

                // Otherwise set the value
                mFoodCreatedBy = value;

                // Notify the system that a property has been changed
                OnPropertyChanged(nameof(FoodCreatedBy));
            }
        }

        /// <summary>
        /// The name of who created the food item in the database
        /// </summary>
        public int? FoodModifiedBy
        {
            get => mFoodModifiedBy;
            set
            {
                // Check if we are changing the value
                if (mFoodModifiedBy == value)
                    return;

                // Otherwise set the value
                mFoodModifiedBy = value;

                // Notify the system that a property has been changed
                OnPropertyChanged(nameof(FoodModifiedBy));
            }
        }

        #endregion

        #region Commands

        public ICommand OpenEditCommand { get; set; }
        public ICommand CloseEditCommand { get; set; }
        public ICommand SaveEditChangesCommand { get; set; }
        public ICommand CancelEditChangesCommand { get; set; }


        #endregion


        #region Constructor 
        /// <summary>
        /// A private parameterless constructor -- used by the SQL database query functions
        /// </summary>
        public FoodListItemViewModel()
        {             
            // Setup the relay commands and basic status effects
            SetupInfo();
        }



        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="name">The food name</param>
        /// <param name="type">The food type</param>
        /// <param name="num">The id number of the food item in the database</param>
        /// <param name="descrip">The description of food item</param>
        /// <param name="price">The price of the item</param>
        /// <param name="taxable">Is the item taxable?</param>
        public FoodListItemViewModel(int num, string name, string descrip, string type, decimal price, bool taxable)
        {
            FoodName = name;
            FoodType = type;
            FoodIDNumber = num;
            FoodDescription = descrip;
            FoodPrice = price;
            FoodIsTaxable = taxable;

            // Setup the relay commands and basic status effects
            SetupInfo();

        }

        /// <summary>
        /// Helper function to setup basic information for the viewmodel
        /// </summary>
        private void SetupInfo()
        {
            // Setup commands for this viewmodel
            OpenEditCommand = new RelayCommand(OpenEditDialog);
            CloseEditCommand = new RelayCommand(CloseEditDialog);
            SaveEditChangesCommand = new RelayCommand(SaveEditChanges);
            CancelEditChangesCommand = new RelayCommand(CancelEditChanges);

            // Default view settings
            IsEditEnabled = false;
            IsExpanded = false;
        }

        /// <summary>
        /// Opens the edit dialog
        /// </summary>
        public void OpenEditDialog()
        {
            IsEditEnabled = true;

        }

        /// <summary>
        /// Saves the changes from the edit dialog
        /// </summary>
        public void SaveEditChanges()
        {
            IsEditEnabled = false;

            MessageBox.Show("Save Changes triggered");

            // TODO:  Save changes to the item...
        }

        /// <summary>
        /// Cancels the changes of the edit dialog
        /// </summary>
        public void CancelEditChanges()
        {
            MessageBox.Show("Cancel in FLIVM clicked");
            IsEditEnabled = false;
        }

        /// <summary>
        /// Close the edit dialog
        /// </summary>
        public void CloseEditDialog()
        {
            IsEditEnabled = false;
        }

        #endregion
    }
}
