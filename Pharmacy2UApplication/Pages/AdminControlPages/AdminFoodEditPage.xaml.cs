using Pharm2UAnimations;
using Pharmacy2UApplication.Core;

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

            // Create the viewmodel for this page
            ViewModel = new FoodListViewModel();

            // Set the data context
            DataContext = ViewModel;
        }
    }
}
