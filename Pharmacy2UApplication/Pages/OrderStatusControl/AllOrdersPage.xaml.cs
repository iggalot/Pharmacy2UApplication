
using EntityFrameworkDatabase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;


namespace Pharmacy2UApplication
{



    /// <summary>
    /// Interaction logic for <see cref="AllOrdersPage"/>.xaml
    /// </summary>
    public partial class AllOrdersPage : BasePage
    {
        #region Private Members

        private ObservableCollection<string> mZiplist;

        #endregion

        #region

        /// <summary>
        /// The list entity to store our zip query results
        /// </summary>
        public ObservableCollection<string> Ziplist
        {
            get => mZiplist;
            set
            {
                int count = 0;
                if (value != null)
                {
                    Ziplist.Add("NewItem");
                    // OnPropertyChanged(nameof(Ziplist));
                    count++;
                }
                Console.WriteLine($"{count} items added\n");

            }
        }

        #endregion

        #region Test Methods

        public void DisplayAllZips()
        {
            // Initialize our database context
            using (var context = new Pharm2UEntities())
            {
                // clear the previous results
                Ziplist.Clear();

                // Add the zip for each record found
                foreach (var record in context.P2U_ZipCodes)
                {
                    Console.WriteLine(record.Zip);
                    Ziplist.Add(record.Zip);
                }

            }

        }
        #endregion


        #region Default Constructor

        public AllOrdersPage()
        {

            // Initialize our collection
            mZiplist = new ObservableCollection<string>();

            InitializeComponent();

            DisplayAllOrders();

            DataContext = this;
        }

        /// <summary>
        /// Displays all the order records in the data base
        /// </summary>
        private void DisplayAllOrders()
        {
            DisplayAllZips();
        }
        #endregion
    }
}
