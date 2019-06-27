
using System.Windows;

namespace Pharmacy2UApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SQLServerConnect sql = new SQLServerConnect();
            sql.SQLTestConn();
        }
    }
}
