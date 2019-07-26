
using EntityFrameworkDatabase;
using Pharm2UAnimations;
using Pharmacy2UApplication.Core;
using System;
using System.Collections.ObjectModel;
using System.Linq;


namespace Pharmacy2UApplication
{
    /// <summary>
    /// A class to contain the join query for all records
    /// </summary>
    public class JoinedOrderInfo
    {
        public int OrderId { get; set; }
        public DateTime? NewOrderCreatedWhen { get; set; }
        public DateTime? ReadyForPaymentWhen {get; set; }
        public DateTime? ReadyForPackagingWhen { get; set; }
        public DateTime? ReadyForPickupWhen { get; set; }
        public DateTime? OutForDeliveryWhen { get; set; }
        public DateTime? DeliveredWhen { get; set; }
        public DateTime? CanceledWhen { get; set; }
        public DateTime? ReturnedWhen { get; set; }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // the status string as expressed in the Order Table
        public string Status { get; set; } 

        // the inferred status based on the date information of the order record
        public OrderStatusTypes StatusType { get; set; }  
    }

    /// <summary>
    /// Interaction logic for <see cref="AllOrdersPage"/>.xaml
    /// </summary>
    public partial class AllOrdersPage : BasePageAnimation
    {
        #region Private Members

        /// <summary>
        /// Holds the title of this page
        /// </summary>
        private string mPageTitleString;

        #endregion
        

        #region Public Properties

        /// <summary>
        /// The collection entity to store our joined order queries {
        /// </summary>
        public static ObservableCollection<JoinedOrderInfo> JoinedOrderInfoList { get; set; }

        /// <summary>
        /// The list entity to store our zip query results
        /// </summary>
        public ObservableCollection<string> ZipList { get; }

        public string PageTitleString
        {
            get => "All Orders Page -- " + JoinedOrderInfoList.Count.ToString() + " records shown";
            private set => mPageTitleString = value;
        }
        #endregion

        #region Queries / Methods




        /// <summary>
        /// The query to read all orders in the database
        /// </summary>
        public void ReadAllOrders()
        {

            // Clear the JoinedOrderInfoList
            JoinedOrderInfoList.Clear();

            // Get the orders that meet our time / status criteria

            // Join the orders of our criteria with the customer data table

            // Join the orders of our criteria with the food order table
            
            // Join the order of our criteria with the otcmed table

            // Join the order with delivery area and delivery company

            // Join the order with the pharmacy info

            // Join the order with the provider info



            using (var context = new Pharm2UEntities())
            {
                var AllOrders = (from order in context.P2U_Order
                                 join customer in context.P2U_Customer
                                 on order.CustomerID equals customer.ItemID

                                 select new
                                 {
                                     OrderID = order.ItemID,
                                     NewOrderCreatedWhen = order.NewOrderCreatedWhen,
                                     ReadyForPaymentWhen = order.ReadyForPaymentWhen,
                                     ReadyForPackagingWhen = order.ReadyForPackagingWhen,
                                     ReadyForPickupWhen = order.ReadyForPickupWhen,
                                     OutForDeliveryWhen = order.OutForDeliveryWhen,
                                     DeliveredWhen = order.DeliveredWhen,
                                     CanceledWhen = order.CanceledWhen,
                                     ReturnedWhen = order.ReturnedWhen,

                                     CustomerID = customer.ItemID,
                                     FirstName = customer.FirstName,
                                     LastName = customer.LastName,
                                     Status = order.Status
                                 }).ToList();

                foreach (var p in AllOrders)
                {
                    // Determine our status enum for the order using the dates of the database record
                    OrderStatusTypes statusType = DetermineOrderStatus(
                        p.NewOrderCreatedWhen,
                        p.ReadyForPaymentWhen,
                        p.ReadyForPackagingWhen,
                        p.ReadyForPickupWhen,
                        p.OutForDeliveryWhen,
                        p.DeliveredWhen,
                        p.CanceledWhen,
                        p.ReturnedWhen
                        );

                    JoinedOrderInfoList.Add(new JoinedOrderInfo()
                    {
                        OrderId = p.OrderID,
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        CustomerId = p.CustomerID,
                        NewOrderCreatedWhen = p.NewOrderCreatedWhen,

                        ReadyForPaymentWhen = p.ReadyForPaymentWhen,
                        ReadyForPackagingWhen = p.ReadyForPackagingWhen,
                        ReadyForPickupWhen = p.ReadyForPickupWhen,
                        OutForDeliveryWhen = p.OutForDeliveryWhen,
                        DeliveredWhen = p.DeliveredWhen,
                        CanceledWhen = p.CanceledWhen,
                        ReturnedWhen = p.ReturnedWhen,
                        Status = p.Status,
                        StatusType = statusType
                        
                    });
                    //Console.WriteLine($"{p.OrderID},  {p.FirstName}, {p.LastName}");
                }
            }
        }

        #endregion

        #region Helper Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="NewOrderCreatedWhen">Time when the order was placed</param>
        /// <param name="ReadyForPaymentWhen">Time when the order was marked ready for payment</param>
        /// <param name="ReadyForPackagingWhen">Time when the order was marked ready for packaging</param>
        /// <param name="ReadyForPickupWhen">Time when the order was marked ready for pickup</param>
        /// <param name="OutForDeliveryWhen">Time when the order was marked out for delivery</param>
        /// <param name="DeliveredWhen">Time when the order was marked as deliered / completed</param>
        /// <param name="CanceledWhen">Time when the order was marked as canceled</param>
        /// <param name="ReturnedWhen">Time as when the order was marked as returned</param>
        /// <returns></returns>
        public OrderStatusTypes DetermineOrderStatus(
                            DateTime? NewOrderCreatedWhen,
                            DateTime? ReadyForPaymentWhen,
                            DateTime? ReadyForPackagingWhen,
                            DateTime? ReadyForPickupWhen,
                            DateTime? OutForDeliveryWhen,
                            DateTime? DeliveredWhen,
                            DateTime? CanceledWhen,
                            DateTime? ReturnedWhen
            )
        {
            // Check for null fields in the database UTC time fields to determine our status.
            // This is very ugly...
            if(NewOrderCreatedWhen != null)
                {
                    if (ReadyForPaymentWhen != null)
                    {
                        if (ReadyForPackagingWhen != null)
                        {
                            if (ReadyForPickupWhen != null)
                            {
                                if (OutForDeliveryWhen != null)
                                {
                                    if (DeliveredWhen != null)
                                    {
                                        if(CanceledWhen == null &&  ReturnedWhen == null)
                                        {
                                        return OrderStatusTypes.STATUS_COMPLETED;

                                        } else
                                        {
                                        if (CanceledWhen == null || ReturnedWhen == null)
                                            return (CanceledWhen == null ? OrderStatusTypes.STATUS_RETURN_NOT_DELIVERED
                                                : OrderStatusTypes.STATUS_CANCELED);
                                        else
                                            return OrderStatusTypes.STATUS_UNKNOWN;
                                    }
                                    } else
                                    {
                                        return OrderStatusTypes.STATUS_OUT_FOR_DELIVERY;
                                    }
                                } else
                                {
                                    return OrderStatusTypes.STATUS_READY_FOR_PICKUP;
                                }

                            } else
                            {
                                return OrderStatusTypes.STATUS_READY_FOR_PACKAGING;
                            }
                        } else
                        {
                            return OrderStatusTypes.STATUS_READY_FOR_PAYMENT;
                        }
                    }
                    else
                    {
                        return OrderStatusTypes.STATUS_NEWORDER;
                    }
                }
            else
                return OrderStatusTypes.STATUS_UNKNOWN;
        }
        #endregion


        #region Default Constructor

        public AllOrdersPage()
        {
            // Initialize our collection
            JoinedOrderInfoList = new ObservableCollection<JoinedOrderInfo>();
            PageTitleString = "All Orders Page - No Records Visible";

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
            //ReadAllZips();
        }
        #endregion
    }
}
