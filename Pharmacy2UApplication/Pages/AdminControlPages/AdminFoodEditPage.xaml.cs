using Pharm2UAnimations;
using Pharmacy2UApplication.Core;
using System.Collections.ObjectModel;

namespace Pharmacy2UApplication
{
    /// <summary>
    /// Interaction logic for <see cref="AdminFoodEditPage"/>.xaml
    /// </summary>
    public partial class AdminFoodEditPage : BasePageAnimation
    {
        /// <summary>
        /// View model for this page
        /// </summary>
        public FoodListViewModel ViewModel { get; set; }

        public AdminFoodEditPage()
        {
            InitializeComponent();

            // Retrieve food list database query from our collection in the IoC<OrderViewModel>
            ObservableCollection<FoodListItemViewModel> fullList = IoC.Get<DatabaseQueryViewModel>().GetFullFoodList();

            // Create a view model for the full order list
            ViewModel = new FoodListViewModel(fullList);

            // And set that as the data context
            DataContext = ViewModel;
        }
    }
}
