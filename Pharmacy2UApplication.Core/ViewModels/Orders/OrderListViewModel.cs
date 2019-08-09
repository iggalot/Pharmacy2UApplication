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
                    SearchText = string.Empty;

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

        #endregion

        #region Constructor

        public OrderListViewModel()
        {
            // Create commands
            SearchCommand = new RelayCommand(Search);
            OpenSearchCommand = new RelayCommand(OpenSearch);
            CloseSearchCommand = new RelayCommand(CloseSearch);
            ClearSearchCommand = new RelayCommand(ClearSearch);

            // Dummy data for our search test page
            ObservableCollection<OrderListItemViewModel> temp = new ObservableCollection<OrderListItemViewModel>();
            temp.Add(new OrderListItemViewModel("Jim", "Allen", 11111));
            temp.Add(new OrderListItemViewModel("Miranda", "Allen", 22222));
            temp.Add(new OrderListItemViewModel("LJ", "Allen", 33333));
            temp.Add(new OrderListItemViewModel("Kira", "Dog", 1));
            temp.Add(new OrderListItemViewModel("Olaf", "Dog", 2));
            temp.Add(new OrderListItemViewModel("Leslie", "Dog", 3));

            // Assign our new list to Items
            Items = new ObservableCollection<OrderListItemViewModel>(temp);
            FilteredItems = new ObservableCollection<OrderListItemViewModel>(Items);

        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Searches the current message list and filters the view
        /// </summary>
        public void Search()
        {
            // Make sure we don't re-search the same text
           if ((string.IsNullOrEmpty(mLastSearchText) && string.IsNullOrEmpty(SearchText)) ||
                string.Equals(mLastSearchText, SearchText))
                return;

            // If we have no search text, or no items
            if (string.IsNullOrEmpty(SearchText) || Items == null || Items.Count <= 0)
            {
                // Make filtered list the same
                FilteredItems = new ObservableCollection<OrderListItemViewModel>(Items ?? Enumerable.Empty<OrderListItemViewModel>());

                // Set last search
                mLastSearchText = SearchText.ToLower();

                return;
            }

            // Find all items that contain the given text
            // TODO: Make more efficient search
            FilteredItems = new ObservableCollection<OrderListItemViewModel>(
                Items.Where(item => item.LastName.ToLower().Contains(SearchText.ToLower())));
            // REFERENCE: See AngelSix WPF32 36:42


            // Set last search text
            mLastSearchText = SearchText.ToLower();
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
