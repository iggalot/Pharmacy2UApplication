
using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
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

            // Set the data context for the XAML Bindings in the GUI
            DataContext = new WindowViewModel(this);
        }

        #region Menu Events

        /// <summary>
        /// Menu command to show the database logging window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DatabaseLogging_Click(object sender, RoutedEventArgs e)
        {
            // Toggle the display setting
            IoC.Get<ApplicationViewModel>().ShouldHideDatabaseLogging = !IoC.Get<ApplicationViewModel>().ShouldHideDatabaseLogging;

        }

        /// <summary>
        /// Menu command to show the database logging window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DebugTools_Click(object sender, RoutedEventArgs e)
        {
            // Toggle the display setting
            IoC.Get<ApplicationViewModel>().ShouldHideDebugTools = !IoC.Get<ApplicationViewModel>().ShouldHideDebugTools;

        }

        #endregion

    }
}
