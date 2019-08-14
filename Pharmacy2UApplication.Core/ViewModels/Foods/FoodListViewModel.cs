using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Pharmacy2UApplication.Core
{
    public class FoodListViewModel : BaseViewModel
    {
        #region Protected Members

        /// <summary>
        /// The last searched food id text in this list
        /// </summary>
        protected string mLastFoodIDSearchText;

        /// <summary>
        /// The last searched food name text in this list
        /// </summary>
        protected string mLastFoodNameSearchText;

        /// <summary>
        /// The last searched food type text in this list
        /// </summary>
        protected string mLastFoodTypeSearchText;

        /// <summary>
        /// The food id text to search for in the search command
        /// </summary>
        protected string mFoodIDSearchText;

        /// <summary>
        /// The text to search for in the search command
        /// </summary>
        protected string mFoodNameSearchText;

        /// <summary>
        /// The text to search for in the search command
        /// </summary>
        protected string mFoodTypeSearchText;


        /// <summary>
        /// The food items for the list
        /// </summary>
        protected ObservableCollection<FoodListItemViewModel> mItems;

        /// <summary>
        ///  The filtered items list
        /// </summary>
        protected ObservableCollection<FoodListItemViewModel> mFilteredItems;

        /// <summary>
        /// A flag indicating if the search dialog is open
        /// </summary>
        protected bool mSearchIsOpen;

        /// <summary>
        /// A flag indicating if the add food item dialog is open
        /// </summary>
        protected bool mAddFoodItemIsOpen;

        /// <summary>
        /// A flag indicating that either the search window or the add food window is currently active
        /// </summary>
        protected bool mAddFoodOrSearchIsOpen;


        /// <summary>
        /// The display title to show the number of records being viewed currently
        /// </summary>
        protected string mDisplayTitle;

        #endregion

        #region Public Properties

        /// <summary>
        /// The items for the list
        /// NOTE:  Do Not call Items.Add to add messages to this list
        ///        as it will make the FilteredItems out of sync
        /// </summary>
        public ObservableCollection<FoodListItemViewModel> Items
        {
            get => mItems;
            set
            {
                // Make sure list has changed
                if (mItems == value)
                    return;

                // Update value
                mItems = value;

                // Update filtered list to match -- make a copy of the items list
                FilteredItems = new ObservableCollection<FoodListItemViewModel>(mItems);
            }
        }

        /// <summary>
        /// The items for the list that include any search filtering
        /// </summary>
        public ObservableCollection<FoodListItemViewModel> FilteredItems
        {
            get => mFilteredItems;
            set
            {
                // Make sure list has changed
                if (mFilteredItems == value)
                    return;

                // Update value
                mFilteredItems = value;

                // Update the title of the page to reflect the number of records shown
                DisplayTitle = "Admin Food Info -- (" + FilteredItems.Count.ToString() + ") items displayed";

                // Signal that the Filtered items list has changed.
                OnPropertyChanged(nameof(FilteredItems));
            }
        }

        /// <summary>
        /// The title of this order list
        /// </summary>
        public string DisplayTitle
        {
            get => mDisplayTitle;
            set
            {
                // Check value is different
                if (mDisplayTitle == value)
                    return;

                //Update value
                mDisplayTitle = value;

                // Notify that the property has changed
                OnPropertyChanged(nameof(DisplayTitle));
            }
        }

        public string AddFoodOrSearchStatusString
        {
            get
            {

                string str = string.Empty;

                // If we aren't editint or searching, suppress the title
                if (!mAddFoodOrSearchIsOpen)
                    return "";

                // If somehow both are open (this should never be true)
                if (mAddFoodItemIsOpen && mSearchIsOpen)
                    return "Adding Food and Searching...";

                // If the add food item is open
                if (mAddFoodItemIsOpen)
                    str += "Adding Food...";

                // If the searching window is open
                if (mSearchIsOpen)
                    str += "Searching...";

                return str;
            }
        }

        /// <summary>
        /// The food id text to search for when we do a search
        /// </summary>
        public string FoodIDSearchText
        {
            get => mFoodIDSearchText;
            set
            {
                // Check value is different
                if (mFoodIDSearchText == value)
                    return;

                //Update value
                mFoodIDSearchText = value;

                // If the search text is empty...
                if (string.IsNullOrEmpty(mFoodIDSearchText))
                    //Search to restore order list
                    Search();

                ////// Notify that the property has changed -- needed to fire the animation
                OnPropertyChanged(nameof(FoodIDSearchText));
            }
        }

        /// <summary>
        /// The food name text to search for when we do a search
        /// </summary>
        public string FoodNameSearchText
        {
            get => mFoodNameSearchText;
            set
            {
                // Check value is different
                if (mFoodNameSearchText == value)
                    return;

                //Update value
                mFoodNameSearchText = value;

                // If the search text is empty...
                if (string.IsNullOrEmpty(mFoodNameSearchText))
                    //Search to restore order list
                    Search();

                ////// Notify that the property has changed -- needed to fire the animation
                OnPropertyChanged(nameof(FoodNameSearchText));
            }
        }

        /// <summary>
        /// The food type text to search for when we do a search
        /// </summary>
        public string FoodTypeSearchText
        {
            get => mFoodTypeSearchText;
            set
            {
                // Check value is different
                if (mFoodTypeSearchText == value)
                    return;

                //Update value
                mFoodTypeSearchText = value;

                // If the search text is empty...
                if (string.IsNullOrEmpty(mFoodTypeSearchText))
                    //Search to restore order list
                    Search();

                ////// Notify that the property has changed -- needed to fire the animation
                OnPropertyChanged(nameof(FoodTypeSearchText));
            }
        }

        /// <summary>
        /// Flag indicating if the search dialog is open
        /// </summary>
        public bool SearchIsOpen
        {
            get => mSearchIsOpen;
            set
            {
                //Check value has changed
                if (mSearchIsOpen == value)
                    return;

                // Update values
                mSearchIsOpen = value;

                // If dialog closes...
                if (!mSearchIsOpen)
                    // Clear search text
                    ClearAllSearch();

                // Update the fnlag idicating that search or add food is currently active
                AddFoodOrSearchIsOpen = UpdateAddFoodOrSearchIsOpen();


                ////// Notify that the property has changed -- needed to fire the animation
                OnPropertyChanged(nameof(SearchIsOpen));
            }
        }

        /// <summary>
        /// Flag indicating if the add food item dialog is open
        /// </summary>
        public bool AddFoodItemIsOpen
        {
            get => mAddFoodItemIsOpen;
            set
            {
                //Check value has changed
                if (mAddFoodItemIsOpen == value)
                    return;

                // Update value
                mAddFoodItemIsOpen = value;

                // Update the fnlag idicating that search or add food is currently active
                AddFoodOrSearchIsOpen = UpdateAddFoodOrSearchIsOpen();

                ////// Notify that the property has changed -- needed to fire the animation
                OnPropertyChanged(nameof(AddFoodItemIsOpen));
            }
        }

        public bool UpdateAddFoodOrSearchIsOpen()
        {
            return (mAddFoodItemIsOpen || mSearchIsOpen) ? true : false;
        }

        /// <summary>
        /// Flag indicating that the add food or the search dialogs are open
        /// </summary>
        public bool AddFoodOrSearchIsOpen
        {
            get => mAddFoodOrSearchIsOpen;
            set
            {
                mAddFoodOrSearchIsOpen = UpdateAddFoodOrSearchIsOpen();

                ////// Notify that the property has changed and update the status
                OnPropertyChanged(nameof(AddFoodOrSearchIsOpen));
                OnPropertyChanged(nameof(AddFoodOrSearchStatusString));
            }
        }

        #endregion

        #region Public Commands

        /// <summary>
        /// The command for when the user wants to search
        /// </summary>
        public ICommand SearchCommand { get; set; }

        /// <summary>
        /// The command for when the user wants to open the search dialog
        /// </summary>
        public ICommand OpenSearchCommand { get; set; }

        /// <summary>
        /// The command for when the user wants to close the search dialog
        /// </summary>
        public ICommand CloseSearchCommand { get; set; }

        /// <summary>
        /// The command for when the user wants to clear the search dialog
        /// </summary>
        public ICommand ClearSearchCommand { get; set; }

        /// <summary>
        /// The command for when the user wants to clear the search dialog
        /// </summary>
        public ICommand ClearFoodIDSearchCommand { get; set; }


        /// <summary>
        /// The command for when the user wants to clear the search dialog
        /// </summary>
        public ICommand ClearFoodNameSearchCommand { get; set; }


        /// <summary>
        /// The command for when the user wants to clear the search dialog
        /// </summary>
        public ICommand ClearFoodTypeSearchCommand { get; set; }

        /// <summary>
        /// The command for when the user wants to clear the search dialog
        /// </summary>
        public ICommand ClearAllSearchCommand { get; set; }

        /// <summary>
        /// The command for when the user wants to add a new food item
        /// </summary>
        public ICommand AddFoodItemCommand { get; set; }

        /// <summary>
        /// The command for when the user wants to close the food item dialog
        /// </summary>
        public ICommand CloseAddFoodItemCommand { get; set; }

        /// <summary>
        /// The command for when the user wants to adding a food item without saving the information
        /// </summary>
        public ICommand CancelAddFoodItemCommand { get; set; }


        /// <summary>
        /// The command for when the user wants actually create the food item
        /// </summary>
        public ICommand CreateFoodItemCommand { get; set; }




        #endregion

        #region Constructor

        /// <summary>
        /// FoodListViewModel constructor that creates itself based on any list
        /// of FoodListItemViewModel that is supplied to it
        /// </summary>
        /// <param name="myList">The list on which view model is based</param>
        public FoodListViewModel(ObservableCollection<FoodListItemViewModel> myList)
        {
            // Create commands
            SearchCommand = new RelayCommand(Search);
            OpenSearchCommand = new RelayCommand(OpenSearch);
            CloseSearchCommand = new RelayCommand(CloseSearch);
            ClearFoodIDSearchCommand = new RelayCommand(ClearFoodIDSearch);
            ClearFoodNameSearchCommand = new RelayCommand(ClearFoodNameSearch);
            ClearFoodTypeSearchCommand = new RelayCommand(ClearFoodTypeSearch);
            ClearAllSearchCommand = new RelayCommand(ClearAllSearch);

            AddFoodItemCommand = new RelayCommand(OpenAddFoodItem);
            CloseAddFoodItemCommand = new RelayCommand(CloseAddFoodItem);
            CancelAddFoodItemCommand = new RelayCommand(CancelAddFoodItem);
            CreateFoodItemCommand = new RelayCommand(CreateFoodItem);

            // Assign our new list to Items
            Items = new ObservableCollection<FoodListItemViewModel>(myList);
            FilteredItems = new ObservableCollection<FoodListItemViewModel>(Items);


            //// Dummy data for our search test page
            //ObservableCollection<FoodListItemViewModel> temp = new ObservableCollection<FoodListItemViewModel>();
            //temp.Add(new FoodListItemViewModel(11111, "Soup", "A hearty meal", "liquid", (decimal)1.11, false));
            //temp.Add(new FoodListItemViewModel(22222, "Pad Thai", "An international sensation", "awesome", (decimal)2.22, true));
            //temp.Add(new FoodListItemViewModel(33333, "Saltine Crackers", "A simple basic", "solid", (decimal)3.33, false));
            //temp.Add(new FoodListItemViewModel(44444, "Herbal Tea", "A simple beverage", "liquid", (decimal)4.44, false));
            //temp.Add(new FoodListItemViewModel(55555, "Red Jello", "There's always room", "unknown", (decimal)5.55, false));
            //temp.Add(new FoodListItemViewModel(66666, "Spicy Chicken Burritos", "Yum!  Tasty!", "solid", (decimal)6.66, false));

            //// Assign our new list to Items
            //Items = new ObservableCollection<FoodListItemViewModel>(temp);
            //FilteredItems = new ObservableCollection<FoodListItemViewModel>(Items);

        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Checks if the current search criteria are different from the
        /// last seach, or if the last and current searches are not null or empty
        /// </summary>
        /// <param name="last">The previous search criteria</param>
        /// <param name="current">The current search criteria</param>
        /// <returns></returns>
        private bool ValidateSearch(string last, string current)
        {
            return ((string.IsNullOrEmpty(last) && string.IsNullOrEmpty(current)) ||
                            string.Equals(last, current));
        }

        /// <summary>
        /// The searches to include in our validation check
        /// </summary>
        /// <returns></returns>
        private bool ValidateAllSearch()
        {
            return (
                // OrderID
                ValidateSearch(mLastFoodIDSearchText, FoodIDSearchText) ||
                // FirstName
                ValidateSearch(mLastFoodNameSearchText, FoodNameSearchText) ||
                // LastName
                ValidateSearch(mLastFoodTypeSearchText, FoodTypeSearchText)
                );            
        }

        // Saves the current search criteria into the last criteria for each search field
        private void SaveSearchCriteria()
        {
            // Must check for null conditions on search criteria
            mLastFoodIDSearchText = (string.IsNullOrEmpty(FoodIDSearchText) ? "" : FoodIDSearchText.ToLower());
            mLastFoodNameSearchText = (string.IsNullOrEmpty(FoodNameSearchText) ? "" : FoodNameSearchText.ToLower());
            mLastFoodTypeSearchText = (string.IsNullOrEmpty(FoodTypeSearchText) ? "" : FoodTypeSearchText.ToLower());
        }

        /// <summary>
        /// Searches the current message list and filters the view
        /// </summary>
        public void Search()
        {
            bool shouldSearch = ValidateAllSearch();

            // Make sure we don't perform the search on the same criteria as the last time
            if (!shouldSearch)
                return;

            // If we have no search texts, or no items, then clear the FilteredItems.
            if((string.IsNullOrEmpty(FoodIDSearchText) && string.IsNullOrEmpty(FoodNameSearchText) && string.IsNullOrEmpty(FoodTypeSearchText)) ||
                Items == null ||
                Items.Count <= 0)
            {
                // Make filtered list the same original list
                FilteredItems = new ObservableCollection<FoodListItemViewModel>(Items ?? Enumerable.Empty<FoodListItemViewModel>());

                // Set last searches
                SaveSearchCriteria();

                return;
            }

            // Find all items that contain the given texts
            // REFERENCE: See AngelSix WPF32 36:42

            // TODO: Make more efficient search
            ObservableCollection<FoodListItemViewModel> searchResults = new ObservableCollection<FoodListItemViewModel>(Items);

            // If the OrderID has a valid search field
            if (!string.IsNullOrEmpty(FoodIDSearchText))
            {
                searchResults = new ObservableCollection<FoodListItemViewModel>(
                    searchResults.Where(item => item.FoodIDNumber.ToString().ToLower().Contains(FoodIDSearchText.ToLower())));
            } 

            // If the FirstName has a valid search field
            if (!string.IsNullOrEmpty(FoodNameSearchText))
            {
                searchResults = new ObservableCollection<FoodListItemViewModel>(
                    searchResults.Where(item => item.FoodName.ToLower().Contains(FoodNameSearchText.ToLower())));
            }

            // If the LastName has a valid search field
            if (!string.IsNullOrEmpty(FoodTypeSearchText))
            {
                searchResults = new ObservableCollection<FoodListItemViewModel>(
                    searchResults.Where(item => item.FoodType.ToLower().Contains(FoodTypeSearchText.ToLower())));
            }

            // Save the search results to the filtered list
            FilteredItems = new ObservableCollection<FoodListItemViewModel>(searchResults);

            // Set last search criterion
            SaveSearchCriteria();
        }

        /// <summary>
        /// Clears the search text
        /// </summary>
        public void ClearFoodIDSearch()
        {
            // If there is some search text
            if (!string.IsNullOrEmpty(FoodIDSearchText))
            {
                // Clear the text
                FoodIDSearchText = string.Empty;
            }
        }

        /// <summary>
        /// Clears the search text
        /// </summary>
        public void ClearFoodNameSearch()
        {

            // If there is some search text
            if (!string.IsNullOrEmpty(FoodNameSearchText))
            {
                // Clear the text
                FoodNameSearchText = string.Empty;
            }
        }

        /// <summary>
        /// Clears the search text
        /// </summary>
        public void ClearFoodTypeSearch()
        {
            // If there is some search text
            if (!string.IsNullOrEmpty(FoodTypeSearchText))
            {
                // Clear the text
                FoodTypeSearchText = string.Empty;
            }
        }

        /// <summary>
        /// A function to clear all the search fields of our control.
        /// </summary>
        public void ClearAllSearch()
        {
            ClearFoodIDSearch();
            ClearFoodNameSearch();
            ClearFoodTypeSearch();
        }

        /// <summary>
        /// Opens the search dialog
        /// </summary>
        public void OpenSearch()
        {
            SearchIsOpen = true;

            // Update the flag idicating that search or add food is currently active
            AddFoodOrSearchIsOpen = UpdateAddFoodOrSearchIsOpen();
        }

        /// <summary>
        /// Closes the search dialog
        /// </summary>
        public void CloseSearch()
        {
            SearchIsOpen = false;
        }
        #endregion

        #region Food Related Commands

        /// <summary>
        /// Opens the add food item dialog
        /// </summary>
        public void OpenAddFoodItem()
        {
            AddFoodItemIsOpen = true;

        }

        /// <summary>
        /// Closes the add food item dialog
        /// </summary>
        public void CloseAddFoodItem()
        {
            AddFoodItemIsOpen = false;
        }

        /// <summary>
        /// Cancels the add food item dialog
        /// </summary>
        public void CancelAddFoodItem()
        {
            // Cancel the input and close the dialog
            AddFoodItemIsOpen = false;
        }

        /// <summary>
        /// A function to create the food item and add it to the Items list.
        /// </summary>
        public void CreateFoodItem()
        {
            // TODO: verify that input is valid for food items

            // Add the item to the master Items
            FoodListItemViewModel newItem = new FoodListItemViewModel(77777, "My New Item", "My new items description", "solid", (decimal)7.77, true);
            Items.Add(newItem);

            // Clear the filter and search again to set the filtered list
            ClearAllSearch();
            Search();

            // Close the add food item dialog
            AddFoodItemIsOpen = false;
        }

        #endregion

        #region Public Methods
        public void UpdateFLIVM(FoodListItemViewModel flivm, FoodListItemViewModel newItem)
        {
            // Update the existing record with the new data
            // ID Number is not affected.
            flivm.FoodName = newItem.FoodName;
            flivm.FoodDescription = newItem.FoodDescription;
            flivm.FoodType = newItem.FoodType;
            flivm.FoodIsTaxable = newItem.FoodIsTaxable;
            flivm.FoodPrice = newItem.FoodPrice;
        }

        public FoodListItemViewModel findFLIVM(int num)
        {
            bool matchFound = false;
            int index = -1;

            for (int i = 0; i < Items.Count; i++)
            {
                if (num == Items[i].FoodIDNumber)
                {
                    MessageBox.Show("Match Found");
                    matchFound = true;
                    index = i;
                    break;
                }
            }

            if (!matchFound)
                return null;
            else
                return Items[index];
        }

        #endregion


    }
}
