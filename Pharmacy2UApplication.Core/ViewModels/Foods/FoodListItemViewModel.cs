﻿using System.Windows;
using System.Windows.Input;

namespace Pharmacy2UApplication.Core
{
     public class FoodListItemViewModel : BaseViewModel
    {

        #region Protected Members

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
        public string FoodName { get; set; }

        /// <summary>
        /// The type of the food
        /// </summary>
        public string FoodType { get; set; }

        /// <summary>
        /// The description of the food item
        /// </summary>
        public string FoodDescription { get; set; }

        /// <summary>
        /// A flag to indicate if the food item is taxable
        /// </summary>
        public bool FoodIsTaxable { get; set; }

        /// <summary>
        /// The price of hte food item
        /// </summary>
        public decimal FoodPrice { get; set; }

        /// <summary>
        /// The id number of the food item in the database
        /// </summary>
        public int FoodIDNumber { get; set; }

        #endregion

        #region Commands

        public ICommand OpenEditCommand { get; set; }
        public ICommand CloseEditCommand { get; set; }
        public ICommand SaveEditChangesCommand { get; set; }
        public ICommand CancelEditChangesCommand { get; set; }


        #endregion


        #region Constructor 
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