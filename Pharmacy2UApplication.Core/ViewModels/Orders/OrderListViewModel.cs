using System;
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

        // Checkbox statuses
        protected static bool mOrderNewIsChecked;
        protected bool mOrderReadyForPaymentIsChecked;
        protected bool mOrderReadyForPackagingIsChecked;
        protected bool mOrderReadyForPickupIsChecked;
        protected bool mOrderOutForDeliveryIsChecked;
        protected bool mOrderCanceledIsChecked;
        protected bool mOrderReturnedIsChecked;
        protected bool mOrderCompletedIsChecked;


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
        /// A collection that contains all of the status filters for the collection
        /// </summary>
        protected ObservableCollection<OrderStatusTypes> mStatusFilterList;


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
        /// A collection that contains all of the currently active status filters
        /// </summary>
        public ObservableCollection<OrderStatusTypes> StatusFilterList
        {
            get => mStatusFilterList;
            set
            {
                // Make sure list has changed
                if (mStatusFilterList == value)
                    return;

                // Update value
                mStatusFilterList = value;
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

        /// <summary>
        /// Flag indicating if the new order filter is applied
        /// </summary>
        public bool OrderNewIsChecked
        {
            get => mOrderNewIsChecked;
            set
            {
                //Check value has changed
                if (mOrderNewIsChecked == value)
                    return;

                // Update value
                mOrderNewIsChecked = value;

                // Notify that the property has changed 
                OnPropertyChanged(nameof(OrderNewIsChecked));
            }
        }

        /// <summary>
        /// Flag indicating if the order ready for payment filter is applied
        /// </summary>
        public bool OrderReadyForPaymentIsChecked
        {
            get => mOrderReadyForPaymentIsChecked;
            set
            {
                //Check value has changed
                if (mOrderReadyForPaymentIsChecked == value)
                    return;

                // Update value
                mOrderReadyForPaymentIsChecked = value;

                // Notify that the property has changed 
                OnPropertyChanged(nameof(OrderReadyForPaymentIsChecked));
            }
        }

        /// <summary>
        /// Flag indicating if the order ready for packaging filter is applied
        /// </summary>
        public bool OrderReadyForPackagingIsChecked
        {
            get => mOrderReadyForPackagingIsChecked;
            set
            {
                //Check value has changed
                if (mOrderReadyForPackagingIsChecked == value)
                    return;

                // Update value
                mOrderReadyForPackagingIsChecked = value;

                // Notify that the property has changed 
                OnPropertyChanged(nameof(OrderReadyForPackagingIsChecked));
            }
        }

        /// <summary>
        /// Flag indicating if the order ready for delivery filter is applied
        /// </summary>
        public bool OrderReadyForPickupIsChecked
        {
            get => mOrderReadyForPickupIsChecked;
            set
            {
                //Check value has changed
                if (mOrderReadyForPickupIsChecked == value)
                    return;

                // Update value
                mOrderReadyForPickupIsChecked = value;

                // Notify that the property has changed 
                OnPropertyChanged(nameof(OrderReadyForPickupIsChecked));
            }
        }

        /// <summary>
        /// Flag indicating if the order out for delivery filter is applied
        /// </summary>
        public bool OrderOutForDeliveryIsChecked
        {
            get => mOrderOutForDeliveryIsChecked;
            set
            {
                //Check value has changed
                if (mOrderOutForDeliveryIsChecked == value)
                    return;

                // Update value
                mOrderOutForDeliveryIsChecked = value;

                // Notify that the property has changed 
                OnPropertyChanged(nameof(OrderOutForDeliveryIsChecked));
            }
        }

        /// <summary>
        /// Flag indicating if the order canceled filter is applied
        /// </summary>
        public bool OrderCanceledIsChecked
        {
            get => mOrderCanceledIsChecked;
            set
            {
                //Check value has changed
                if (mOrderCanceledIsChecked == value)
                    return;

                // Update value
                mOrderCanceledIsChecked = value;

                // Notify that the property has changed 
                OnPropertyChanged(nameof(OrderCanceledIsChecked));
            }
        }

        /// <summary>
        /// Flag indicating if the order returned filter is applied
        /// </summary>
        public bool OrderReturnedIsChecked
        {
            get => mOrderReturnedIsChecked;
            set
            {
                //Check value has changed
                if (mOrderReturnedIsChecked == value)
                    return;

                // Update value
                mOrderReturnedIsChecked = value;

                // Notify that the property has changed 
                OnPropertyChanged(nameof(OrderReturnedIsChecked));
            }
        }

        /// <summary>
        /// Flag indicating if the order completed filter is applied
        /// </summary>
        public bool OrderCompletedIsChecked
        {
            get => mOrderCompletedIsChecked;
            set
            {
                //Check value has changed
                if (mOrderCompletedIsChecked == value)
                    return;

                // Update value
                mOrderCompletedIsChecked = value;

                // Notify that the property has changed 
                OnPropertyChanged(nameof(OrderCompletedIsChecked));
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

        /// <summary>
        /// The command that is activated when the new order filter is applied
        /// </summary>
        public ICommand OrderNewFilterCommand { get; set; }

        /// <summary>
        /// The command that is activated when the ready for packing filter is applied
        /// </summary>
        public ICommand OrderReadyForPackagingFilterCommand { get; set; }

        /// <summary>
        /// The command that is activated when the ready for payment filter is applied
        /// </summary>
        public ICommand OrderReadyForPaymentFilterCommand { get; set; }

        /// <summary>
        /// The command that is activated when the ready for delivery filter is applied
        /// </summary>
        public ICommand OrderReadyForPickupFilterCommand { get; set; }

        /// <summary>
        /// The command that is activated when the out for delivery filter is applied
        /// </summary>
        public ICommand OrderOutForDeliveryFilterCommand { get; set; }

        /// <summary>
        /// The command that is activated when the out for delivery filter is applied
        /// </summary>
        public ICommand OrderCanceledFilterCommand { get; set; }

        /// <summary>
        /// The command that is activated when the out for delivery filter is applied
        /// </summary>
        public ICommand OrderReturnedFilterCommand { get; set; }

        /// <summary>
        /// The command that is activated when the out for delivery filter is applied
        /// </summary>
        public ICommand OrderCompletedFilterCommand { get; set; }



        #endregion

        #region Constructor

        /// <summary>
        /// OrderListViewModel constructor that creates itself based on any list
        /// of OrderListItemViewModel that is supplied to it
        /// </summary>
        /// <param name="myList">The list on which view model is based</param>
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

            OrderNewFilterCommand = new RelayCommand(NewOrderFilter);
            OrderReadyForPackagingFilterCommand = new RelayCommand(OrderReadyForPackagingFilter);
            OrderReadyForPaymentFilterCommand = new RelayCommand(OrderReadyForPaymentFilter);
            OrderReadyForPickupFilterCommand = new RelayCommand(OrderReadyForPickupFilter);
            OrderOutForDeliveryFilterCommand = new RelayCommand(OrderOutForDeliveryFilter);
            OrderCanceledFilterCommand = new RelayCommand(OrderCanceledFilter);
            OrderReturnedFilterCommand = new RelayCommand(OrderReturnedFilter);
            OrderCompletedFilterCommand = new RelayCommand(OrderCompletedFilter);

            // Create our base status list
            StatusFilterList = new ObservableCollection<OrderStatusTypes>();

            // Set All Delivery Status Filters to cleared (false)
            ClearAllDeliveryStatusFilters();

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

            // Update the status list
            UpdateStatusFilterList();

            // Apply the status filter list
            ApplyStatusFilters();

            OnPropertyChanged(nameof(FilteredItems));

            // Set last search criterion
            SaveSearchCriteria();           
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
        /// Clears all the date filters
        /// </summary>
        public void ClearAllDeliveryStatusFilters()
        {
            // Clear all order status checkboxes
            OrderNewIsChecked = false;
            OrderReadyForPaymentIsChecked = false;
            OrderReadyForPackagingIsChecked = false;
            OrderReadyForPickupIsChecked = false;
            OrderOutForDeliveryIsChecked = false;
            OrderCanceledIsChecked = false;
            OrderReturnedIsChecked = false;
            OrderCompletedIsChecked = false;

            // Clear the StatusFilter List
            UpdateStatusFilterList();
        }

        /// <summary>
        /// A function to clear all the search fields of our control.
        /// </summary>
        public void ClearAllSearch()
        {
            // Clear the status filters
            ClearAllDeliveryStatusFilters();

            // Now clear the search fields 
            // -- These must be last because changes to these fields trigger a new search
            ClearOrderIDSearch();
            ClearFirstNameSearch();
            ClearLastNameSearch();

            // Search again to reset the FilteredItems list
            Search();


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

        /// <summary>
        /// The command that executes when the order completed filter is checked
        /// </summary>
        private void OrderCompletedFilter()
        {
            // Apply the filter
            UpdateStatusFilterList();
        }

        /// <summary>
        /// The command that executes when the order returned filter is checked
        /// </summary>
        private void OrderReturnedFilter()
        {
            // Apply the filter
            UpdateStatusFilterList();
        }

        /// <summary>
        /// The command that executes when the order canceled filter is checked
        /// </summary>
        private void OrderCanceledFilter()
        {
            // Apply the filter
            UpdateStatusFilterList();
        }

        /// <summary>
        /// The command that executes when the out for delivery filter is checked
        /// </summary>
        private void OrderOutForDeliveryFilter()
        {
            // Apply the filter
            UpdateStatusFilterList();
        }

        /// <summary>
        /// The command that executes when the out for delivery filter is clicked
        /// </summary>
        private void OrderReadyForPickupFilter()
        {
            // Apply the filter
            UpdateStatusFilterList();
        }

        /// <summary>
        /// The command that executes when the ready for payment filter is clicked
        /// </summary>
        private void OrderReadyForPaymentFilter()
        {
            // Apply the filter
            UpdateStatusFilterList();
        }

        /// <summary>
        /// The command that executes when the ready for packging filter is clicked
        /// </summary>
        private void OrderReadyForPackagingFilter()
        {
            // Apply the filter
            UpdateStatusFilterList();
        }

        /// <summary>
        /// The command that executes when the new order check box is clicked
        /// </summary>
        private void NewOrderFilter()
        {
            // Apply the filter
            UpdateStatusFilterList();
        }

        #endregion




        #region Helper Functions
        private void UpdateStatusFilterList()
        {
            // Clear the status filter list
            StatusFilterList.Clear();

            if (OrderNewIsChecked)
                StatusFilterList.Add(OrderStatusTypes.STATUS_NEWORDER);
            if (OrderReadyForPackagingIsChecked)
                StatusFilterList.Add(OrderStatusTypes.STATUS_READY_FOR_PACKAGING);
            if (OrderReadyForPaymentIsChecked)
                StatusFilterList.Add(OrderStatusTypes.STATUS_READY_FOR_PAYMENT);
            if (OrderReadyForPickupIsChecked)
                StatusFilterList.Add(OrderStatusTypes.STATUS_READY_FOR_PICKUP);
            if (OrderOutForDeliveryIsChecked)
                StatusFilterList.Add(OrderStatusTypes.STATUS_OUT_FOR_DELIVERY);
            if (OrderCanceledIsChecked)
                StatusFilterList.Add(OrderStatusTypes.STATUS_CANCELED);
            if (OrderReturnedIsChecked)
                StatusFilterList.Add(OrderStatusTypes.STATUS_RETURN_NOT_DELIVERED);
            if (OrderCompletedIsChecked)
                StatusFilterList.Add(OrderStatusTypes.STATUS_COMPLETED);

            ApplyStatusFilters();
        }

        // Applies the date filters from the checkboxes to the FilteredItems list
        private void ApplyStatusFilters()
        {
            // If none of the filters are checked, make no changes...
            if (StatusFilterList.Count == 0)
                return;

            // Otherwise apply our filter
            ObservableCollection<OrderListItemViewModel> temp = new ObservableCollection<OrderListItemViewModel>();

            foreach(OrderStatusTypes type in StatusFilterList)
            {
                for (int i = 0; i < FilteredItems.Count; i++)
                {
                    if (FilteredItems[i].StatusType == type)
                    {
                        temp.Add(FilteredItems[i]);
                    }
                }
            }

            // Recreated the Filtered Items list. If there were any changes, 
            // signal that the collection was changed
            FilteredItems = new ObservableCollection<OrderListItemViewModel>(temp);
        }

        #endregion


    }
}
