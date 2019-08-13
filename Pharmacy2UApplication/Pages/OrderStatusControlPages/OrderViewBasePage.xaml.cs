using Pharm2UAnimations;
using Pharmacy2UApplication.Core;

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

            ViewModel = new OrderListViewModel();

            DataContext = ViewModel;
        }
    }
}
