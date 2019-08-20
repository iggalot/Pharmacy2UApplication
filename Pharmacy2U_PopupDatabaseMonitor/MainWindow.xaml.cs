using Pharmacy2UApplication.Core;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Pharmacy2U_PopupDatabaseMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Public Properties

        public WindowViewModel ViewModel { get; set; }


        /// <summary>
        /// A collection of NamedPipeData objects.  Used for storing the OrderID and Order Guid of a new record
        /// within the monitor prior to sending to the application via the acknowledge click.
        /// </summary>
                /// <summary>
        /// The original data of our pipe process within the database monitor
        /// </summary>
        public static ObservableCollection<NamedPipeData> NewOrderData { get; set; }

        //// Our DatabaseMonitor System for tracking when a database has changed
        //DBMonitor DatabaseMonitor = new DBMonitor(SQLServerConnection);


        #endregion

        //#region Named Pipe Serialization test methods


        ///// <summary>
        ///// Creates some basic data for our collection (TESTING PURPOSES ONLY)
        ///// </summary>
        //private static ObservableCollection<NamedPipeData> GenerateDefaultData()
        //{
        //    ObservableCollection<NamedPipeData> temp = new ObservableCollection<NamedPipeData>();
        //    for (int i = 0; i<3; i++)
        //    {
        //        NamedPipeData client = new NamedPipeData();
        //        client.OrderID = i;
        //        client.OrderGuid = new Guid();
        //        temp.Add(client);
        //    }

        //    return temp;
        //}


        //#endregion

        // TODO: Bind window startup locations in XAML to screen size
        public MainWindow()
        {
            // Create our ViewModel
            ViewModel = new WindowViewModel(this);

            // Set our data context
            DataContext = ViewModel;


            InitializeComponent();



            #region Named pipe serialization test

            //// Create our server stream named pipe
            //NamedPipe.ServerStream = new NamedPipeServerStream(NamedPipe.PipeNameFromMonitorToApplication, PipeDirection.InOut, 1);


            //// Generate default data
            //NewOrderData = GenerateDefaultData();

            //Thread FromMonitorPipeThread = new Thread(SendData);
            //FromMonitorPipeThread.IsBackground = true;
            //FromMonitorPipeThread.Start();

            //Console.WriteLine("DB monitor pipe thread started...");

            //FromMonitorPipeThread.Join();

            ////if (NamedPipe._fromMonitorToApplicationPipeStream != null)
            ////    NamedPipe._fromMonitorToApplicationPipeStream.Close();

            //Console.WriteLine("OrderID\tOrderGuid");
            //for (int i = 0; i < NewOrderData.Count; i++)
            //{
            //    Console.WriteLine("DB Monitor: " + NewOrderData[i].OrderID + "\t" + NewOrderData[i].OrderGuid);
            //}
            #endregion

        }

        //private void SendData()
        //{
        //    Console.WriteLine("Receiving data from monitor...");
        //    // Receives the new order data from the monitor
        //    NamedPipe.SendToApplication(NewOrderData);
        //    Console.WriteLine("Data received....returning to main application...");
        //}

        // After loading, send our message to the pipe
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            double screenHt = SystemParameters.PrimaryScreenHeight;
            double screenWidth = SystemParameters.PrimaryScreenWidth;

            double fullscreenHt = SystemParameters.FullPrimaryScreenHeight;
            double fullscreenWidth = SystemParameters.FullPrimaryScreenWidth;

            double maximizedscreenHt = SystemParameters.MaximizedPrimaryScreenHeight;
            double maximizedscreenWidth = SystemParameters.MaximizedPrimaryScreenWidth;

            MessageBox.Show("Primary: " + screenHt + " x " + screenWidth + "\n" +
                "Full: " + fullscreenHt + " x " + fullscreenWidth + "\n" +
                "Maximized: " + maximizedscreenHt + " x " + maximizedscreenWidth + "\n"
                );
        }

        /// <summary>
        /// The function to signal that the popup is now open and show animate in.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Show_Click(object sender, RoutedEventArgs e)
        {
            // Show the popup
            MyPopup.IsOpen = true;
        }

        /// <summary>
        /// The function for when the acknowledge button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hide_Click(object sender, RoutedEventArgs e)
        {
            // Show the popup
            MyPopup.IsOpen = true;
        }

        /// <summary>
        /// The task to run when the popup is done animating in.
        /// Makes the thread sleep for the duration of the animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowPopupStoryboard_Completed(object sender, System.EventArgs e)
        {
            // Sleep once the animation is complete
            Thread.Sleep(WindowViewModel.AnimationSpeed);
        }

        /// <summary>
        /// The task to run when the popup is done animating out.
        /// Otherwise, by setting IsOpen=false, will close the popup instantly.  This allows a
        /// smooth animation out.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HidePopupStoryboard_Completed(object sender, System.EventArgs e)
        {
            // Then close the popup
            MyPopup.IsOpen = false;
        }
    }
}
