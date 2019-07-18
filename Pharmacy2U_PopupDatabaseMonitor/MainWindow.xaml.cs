using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pharmacy2U_PopupDatabaseMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Methods

        #endregion

        // TODO: Bind window startup locations in XAML to screen size
        public MainWindow()
        {
            InitializeComponent();


        }

        // After loading, send out message to the pipe
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


            // Send a message to our pipe
            NamedPipe.SendByteAndReceiveResponse();

            // And await the response
            Response.Text = NamedPipe.ReceivedFromClient;
        }
    }
}
