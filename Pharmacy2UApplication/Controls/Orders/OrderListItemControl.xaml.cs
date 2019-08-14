
using System.Windows;
using System.Windows.Controls;


namespace Pharmacy2UApplication
{
    /// <summary>
    /// Interaction logic for OrderItemControl.xaml
    /// </summary>
    public partial class OrderListItemControl : BaseControl
    {
       // public string ContactMethod { get; set; } = "Order Item Control Page";

        public OrderListItemControl()
        {
            InitializeComponent();
        }

        private void MyGrid_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBox.Show("I was clicked");
        }
    }
}
