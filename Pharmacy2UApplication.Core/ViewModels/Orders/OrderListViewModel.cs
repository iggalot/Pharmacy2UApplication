using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Pharmacy2UApplication.Core
{
    public class OrderListViewModel : BaseViewModel
    {
        #region Protected Members

        /// <summary>
        /// The last searched text in this list
        /// </summary>
        protected string mLastSearchText;

        /// <summary>
        /// The last searched order id text in this list
        /// </summary>
        protected string mLastOrderIDSearchText;

        /// <summary>
        /// The last searched first name text in this list
        /// </summary>
        protected string mLastFirstNameSearchText;

        /// <summary>
        /// The last searched text in this list
        /// </summary>
        protected string mLastLastNameSearchText;





        /// <summary>
        /// The text to search for in the search command
        /// </summary>
        protected string mSearchText;

        /// <summary>
        /// The text to search for in the search command
        /// </summary>
        protected string mOrderIDSearchText;

        /// <summary>
        /// The text to search for in the search command
        /// </summary>
        protected string mFirstNameSearchText;

        /// <summary>
        /// The text to search for in the search command
        /// </summary>
        protected string mLastNameSearchText;


        /// <summary>
        /// The order items for the list
        /// </summary>
        protected ObservableCollection<OrderListItemViewModel> mItems;

        /// <summary>
        ///  The filtered items list
        /// </summary>
        protected ObservableCollection<OrderListItemViewModel> mFilteredItems;

        /// <summary>
        /// A flag indicating if the search dialog is open
        /// </summary>
        protected bool mSearchIsOpen;

        /// <summary>
        /// The display title to show the number of records being viewed currently
        /// </summary>
        protected string mDisplayTitle;

        #endregion

        #region Public Properties

        /// <summary>
        /// The order items for the list
        /// NOTE:  Do Not call Items.Add to add messages to this list
        ///        as it will make the FilteredItems out of sync
        /// </summary>
        public ObservableCollection<OrderListItemViewModel> Items
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
                FilteredItems = new ObservableCollection<OrderListItemViewModel>(mItems);
            }
        }

        /// <summary>
        /// The order items for the list that include any search filtering
        /// </summary>
        public ObservableCollection<OrderListItemViewModel> FilteredItems
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
                DisplayTitle = "Order Info -- (" + FilteredItems.Count.ToString() + ") items displayed";

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

        /// <summary>
        /// The text to search for when we do a search
        /// </summary>
        public string SearchText
        {
            get => mSearchText;
            set
            {
                // Check value is different
                if (mSearchText == value)
                    return;

                //Update value
                mSearchText = value;

                // If the search text is empty...
                if (string.IsNullOrEmpty(SearchText))
                    //Search to restore order list
                    Search();

                ////// Notify that the property has changed -- needed to fire the animation
                OnPropertyChanged(nameof(SearchText));
            }
        }

        /// <summary>
        /// The text to search for when we do a search
        /// </summary>
        public string OrderIDSearchText
        {
            get => mOrderIDSearchText;
            set
            {
                // Check value is different
                if (mOrderIDSearchText == value)
                    return;

                //Update value
                mOrderIDSearchText = value;

                // If the search text is empty...
                if (string.IsNullOrEmpty(mOrderIDSearchText))
                    //Search to restore order list
                    Search();

                ////// Notify that the property has changed -- needed to fire the animation
                OnPropertyChanged(nameof(OrderIDSearchText));
            }
        }

        /// <summary>
        /// The first name text to search for when we do a search
        /// </summary>
        public string FirstNameSearchText
        {
            get => mFirstNameSearchText;
            set
            {
                // Check value is different
                if (mFirstNameSearchText == value)
                    return;

                //Update value
                mFirstNameSearchText = value;

                // If the search text is empty...
                if (string.IsNullOrEmpty(mFirstNameSearchText))
                    //Search to restore order list
                    Search();

                ////// Notify that the property has changed -- needed to fire the animation
                OnPropertyChanged(nameof(FirstNameSearchText));
            }
        }

        /// <summary>
        /// The last name text to search for when we do a search
        /// </summary>
        public string LastNameSearchText
        {
            get => mSearchText;
            set
            {
                // Check value is different
                if (mLastNameSearchText == value)
                    return;

                //Update value
                mSearchText = value;

                // If the search text is empty...
                if (string.IsNullOrEmpty(mLastNameSearchText))
                    //Search to restore order list
                    Search();

                ////// Notify that the property has changed -- needed to fire the animation
                OnPropertyChanged(nameof(LastNameSearchText));
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

                // Update value
                mSearchIsOpen = value;

                // If dialog closes...
                if (!mSearchIsOpen)
                    // Clear search text
                    ClearAllSearch();

                ////// Notify that the property has changed -- needed to fire the animation
                OnPropertyChanged(nameof(SearchIsOpen));
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
        public ICommand ClearOrderIDSearchCommand { get; set; }


        /// <summary>
        /// The command for when the user wants to clear the search dialog
        /// </summary>
        public ICommand ClearFirstNameSearchCommand { get; set; }


        /// <summary>
        /// The command for when the user wants to clear the search dialog
        /// </summary>
        public ICommand ClearLastNameSearchCommand { get; set; }

        /// <summary>
        /// The command for when the user wants to clear the search dialog
        /// </summary>
        public ICommand ClearAllSearchCommand { get; set; }



        #endregion

        #region Constructor

        /// <summary>
        /// OrderListViewModel constructor that creates itself based on any list
        /// of OrderListItemViewModel that is supplied to it
        /// </summary>
        /// <param name="myList"></param>
        public OrderListViewModel(ObservableCollection<OrderListItemViewModel> myList)
        {
            // Create commands
            SearchCommand = new RelayCommand(Search);
            OpenSearchCommand = new RelayCommand(OpenSearch);
            CloseSearchCommand = new RelayCommand(CloseSearch);
            ClearSearchCommand = new RelayCommand(ClearSearch);
            ClearOrderIDSearchCommand = new RelayCommand(ClearOrderIDSearch);
            ClearFirstNameSearchCommand = new RelayCommand(ClearFirstNameSearch);
            ClearLastNameSearchCommand = new RelayCommand(ClearLastNameSearch);
            ClearAllSearchCommand = new RelayCommand(ClearAllSearch);

            // Assign our new list to Items
            Items = new ObservableCollection<OrderListItemViewModel>(myList);
            FilteredItems = new ObservableCollection<OrderListItemViewModel>(Items);

            //// Dummy data for our search test page
            //ObservableCollection<OrderListItemViewModel> temp = new ObservableCollection<OrderListItemViewModel>();
            //temp.Add(new OrderListItemViewModel("Jim", "Allen", 11111));
            //temp.Add(new OrderListItemViewModel("Miranda", "Allen", 22222));
            //temp.Add(new OrderListItemViewModel("LJ", "Allen", 33333));
            //temp.Add(new OrderListItemViewModel("Kira", "Dog", 1));
            //temp.Add(new OrderListItemViewModel("Olaf", "Dog", 2));
            //temp.Add(new OrderListItemViewModel("Leslie", "Dog", 3));

            //// Assign our new list to Items
            //Items = new ObservableCollection<OrderListItemViewModel>(temp);
            //FilteredItems = new ObservableCollection<OrderListItemViewModel>(Items);

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
                ValidateSearch(mLastOrderIDSearchText, OrderIDSearchText) ||
                // FirstName
                ValidateSearch(mLastFirstNameSearchText, FirstNameSearchText) ||
                // LastName
                ValidateSearch(mLastLastNameSearchText, LastNameSearchText)
                );            
        }

        // Saves the current search criteria into the last criteria for each search field
        private void SaveSearchCriteria()
        {
            // Must check for null conditions on search criteria
            mLastOrderIDSearchText = (string.IsNullOrEmpty(OrderIDSearchText) ? "" : OrderIDSearchText.ToLower());
            mLastFirstNameSearchText = (string.IsNullOrEmpty(FirstNameSearchText) ? "" : FirstNameSearchText.ToLower());
            mLastLastNameSearchText = (string.IsNullOrEmpty(LastNameSearchText) ? "" : LastNameSearchText.ToLower());
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
            if((string.IsNullOrEmpty(OrderIDSearchText) && string.IsNullOrEmpty(FirstNameSearchText) && string.IsNullOrEmpty(LastNameSearchText)) ||
                Items == null ||
                Items.Count <= 0)
            {
                // Make filtered list the same original list
                FilteredItems = new ObservableCollection<OrderListItemViewModel>(Items ?? Enumerable.Empty<OrderListItemViewModel>());

                // Set last searches
                SaveSearchCriteria();

                return;
            }

            // Find all items that contain the given texts
            // REFERENCE: See AngelSix WPF32 36:42

            // TODO: Make more efficient search
            ObservableCollection<OrderListItemViewModel> searchResults = new ObservableCollection<OrderListItemViewModel>(Items);

            // If the OrderID has a valid search field
            if (!string.IsNullOrEmpty(OrderIDSearchText))
            {
                searchResults = new ObservableCollection<OrderListItemViewModel>(
                    searchResults.Where(item => item.OrderId.ToString().ToLower().Contains(OrderIDSearchText.ToLower())));
            } 

            // If the FirstName has a valid search field
            if (!string.IsNullOrEmpty(FirstNameSearchText))
            {
                searchResults = new ObservableCollection<OrderListItemViewModel>(
                    searchResults.Where(item => item.FirstName.ToLower().Contains(FirstNameSearchText.ToLower())));
            }

            // If the LastName has a valid search field
            if (!string.IsNullOrEmpty(LastNameSearchText))
            {
                searchResults = new ObservableCollection<OrderListItemViewModel>(
                    searchResults.Where(item => item.LastName.ToLower().Contains(LastNameSearchText.ToLower())));
            }

            // Save the search results to the filtered list
            FilteredItems = new ObservableCollection<OrderListItemViewModel>(searchResults);

            // Set last search criterion
            SaveSearchCriteria();





            //// Make sure we don't re-search the same text
            //if ((string.IsNullOrEmpty(mLastSearchText) && string.IsNullOrEmpty(SearchText)) ||
            //    string.Equals(mLastSearchText, SearchText))
            //    return;

            //// If we have no search text, or no items
            //if (string.IsNullOrEmpty(SearchText) || Items == null || Items.Count <= 0)
            //{
            //    // Make filtered list the same
            //    FilteredItems = new ObservableCollection<OrderListItemViewModel>(Items ?? Enumerable.Empty<OrderListItemViewModel>());

            //    // Set last search
            //    mLastSearchText = SearchText.ToLower();

            //    return;
            //}

            //// Find all items that contain the given text
            //// TODO: Make more efficient search
            //FilteredItems = new ObservableCollection<OrderListItemViewModel>(
            //    Items.Where(item => item.LastName.ToLower().Contains(LastNameSearchText.ToLower())));
            //// REFERENCE: See AngelSix WPF32 36:42


            //// Set last search text
            //mLastSearchText = SearchText.ToLower();
        }

        /// <summary>
        /// Clears the search text
        /// </summary>
        public void ClearSearch()
        {
            // If there is some search text
            if (!string.IsNullOrEmpty(SearchText))
            {
                // Clear the text
                SearchText = string.Empty;
            }
            //Otherwise
            else
                // Close search dialog
                SearchIsOpen = false;
        }

        /// <summary>
        /// Clears the search text
        /// </summary>
        public void ClearOrderIDSearch()
        {

            // If there is some search text
            if (!string.IsNullOrEmpty(OrderIDSearchText))
            {
                // Clear the text
                OrderIDSearchText = string.Empty;
            }
        }

        /// <summary>
        /// Clears the search text
        /// </summary>
        public void ClearFirstNameSearch()
        {

            // If there is some search text
            if (!string.IsNullOrEmpty(FirstNameSearchText))
            {
                // Clear the text
                FirstNameSearchText = string.Empty;
            }
        }

        /// <summary>
        /// Clears the search text
        /// </summary>
        public void ClearLastNameSearch()
        {
            // If there is some search text
            if (!string.IsNullOrEmpty(LastNameSearchText))
            {
                // Clear the text
                LastNameSearchText = string.Empty;
            }
        }

        /// <summary>
        /// A function to clear all the search fields of our control.
        /// </summary>
        public void ClearAllSearch()
        {
            ClearOrderIDSearch();
            ClearFirstNameSearch();
            ClearLastNameSearch();
        }


        /// <summary>
        /// Opens the search dialog
        /// </summary>
        public void OpenSearch()
        {
            SearchIsOpen = true;
        }

        /// <summary>
        /// Closes the search dialog
        /// </summary>
        public void CloseSearch()
        {
            SearchIsOpen = false;
        }

        #endregion


    }
}
