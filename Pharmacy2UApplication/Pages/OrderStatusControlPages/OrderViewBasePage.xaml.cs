using Pharm2UAnimations;
using Pharmacy2UApplication.Core;
using System.Collections.ObjectModel;

namespace Pharmacy2UApplication
{
    /// <summary>
    /// Interaction logic for OrderViewBasePage.xaml
    /// </summary>
    public partial class OrderViewBasePage : BasePageAnimation
    {
        /// <summary>
        /// View model for this page
        /// </summary>
        public OrderListViewModel ViewModel { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public OrderViewBasePage()
        {
            InitializeComponent();

            // Retrieve database query from our collection in the IoC<OrderViewModel>
            ObservableCollection<OrderListItemViewModel> fullList = IoC.Get<OrderViewModel>().GetFullOrderList();

            ViewModel = new OrderListViewModel(fullList);

            DataContext = ViewModel;
        }
    }
}
