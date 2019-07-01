
using System.Windows;

namespace Pharmacy2UApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Our sql connection
        public SQLServerConnect SQLServerConnection {get; set;}

        public MainWindow()
        {
            InitializeComponent();

            // Testing of our C# to SQL connectivity
            SQLServerConnection = new SQLServerConnect();

            // Set the data context for the XAML Bindings in the GUI
            DataContext = this;
        }
    }
}
