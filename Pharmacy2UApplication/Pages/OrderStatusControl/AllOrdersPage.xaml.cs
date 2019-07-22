
using EntityFrameworkDatabase;
using System;
using System.Collections.ObjectModel;
using System.Linq;


namespace Pharmacy2UApplication
{
    /// <summary>
    /// A class to containe the join query for all records
    /// </summary>
    public class JoinedOrderInfo
    {
        public int OrderId { get; set; }
        public DateTime NewOrderCreatedWhen { get; set; }
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string Status { get; set; }
    }

    /// <summary>
    /// Interaction logic for <see cref="AllOrdersPage"/>.xaml
    /// </summary>
    public partial class AllOrdersPage : BasePage
    {
        #region Private Members

        /// <summary>
        /// The list of zipcodes from the query
        /// </summary>
        private ObservableCollection<string> mZiplist;

        /// <summary>
        /// The list of orders from the query
        /// </summary>
        private ObservableCollection<P2U_Order> mOrderlist;

        /// <summary>
        /// The list of all the joined information from our join query
        /// </summary>
        private ObservableCollection<JoinedOrderInfo> mJoinedOrderList;

        #endregion

        #region Public Properties

        /// <summary>
        /// The collection entity to store our joined order queries {
        /// </summary>
        public ObservableCollection<JoinedOrderInfo> JoinedOrderInfoList { get; set; }

        /// <summary>
        /// The list entity to store our zip query results
        /// </summary>
        public ObservableCollection<string> ZipList { get; }

        /// <summary>
        /// The list entity to store our order query results
        /// </summary>
        public ObservableCollection<P2U_Order> OrderList { get; }

        #endregion

        #region Queries / Methods

        /// <summary>
        /// Test query to display a list of all zipcodes in the DB
        /// </summary>
        public void ReadAllZips()
        {
            // Initialize our database context
            using (var context = new Pharm2UEntities())
            {
                // clear the previous results
                ZipList.Clear();

                // Add the zip for each record found
                foreach (var record in context.P2U_ZipCodes)
                {
                    Console.WriteLine(record.Zip);
                    ZipList.Add(record.Zip);
                }
            }
        }


        /// <summary>
        /// The query to read all orders in the database
        /// </summary>
        public void ReadAllOrders()
        {
            //// Initialize our database context
            //using (var context = new Pharm2UEntities())
            //{
            //    // clear the previous query results
            //    OrderList.Clear();

            //    // Add the orders for each record found
            //    foreach (var record in context.P2U_Order)
            //    {
            //        OrderList.Add(record);
            //    }
            //}

            using (var context = new Pharm2UEntities())
            {
                var AllOrders = (from order in context.P2U_Order
                                 join customer in context.P2U_Customer
                                 on order.CustomerID equals customer.ItemID

                                 select new
                                 {
                                     OrderID = order.ItemID,
                                     DateCreated = (DateTime)order.NewOrderCreatedWhen,
                                     CustomerID = customer.ItemID,
                                     FirstName = customer.FirstName,
                                     LastName = customer.LastName,
                                     Status = order.Status
                                 }).ToList();

                foreach (var p in AllOrders)
                {
                    JoinedOrderInfoList.Add(new JoinedOrderInfo()
                    {
                        OrderId = p.OrderID,
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        CustomerId = p.CustomerID,
                        NewOrderCreatedWhen = p.DateCreated,
                        Status = p.Status
                    });
                    Console.WriteLine($"{p.OrderID},  {p.FirstName}, {p.LastName}");
                }
            }
        }

        #endregion


        #region Default Constructor

        public AllOrdersPage()
        {
            // Initialize our collection
            ZipList = new ObservableCollection<string>();
            OrderList = new ObservableCollection<P2U_Order>();
            JoinedOrderInfoList = new ObservableCollection<JoinedOrderInfo>();

            InitializeComponent();

            DisplayAllOrders();

            DataContext = this;
        }

        /// <summary>
        /// Displays all the order records in the data base
        /// </summary>
        private void DisplayAllOrders()
        {
            //Read all Orders
            ReadAllOrders();
            ReadAllZips();
        }
        #endregion
    }
}
