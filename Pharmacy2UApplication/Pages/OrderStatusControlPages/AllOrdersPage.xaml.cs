
using EntityFrameworkDatabase;
using Pharm2UAnimations;
using Pharmacy2UApplication.Core;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Pharmacy2UApplication
{
    /// <summary>
    /// A class for holding our city info search results from P2U_ZipCodes
    /// </summary>
    public class CityInfo
    {
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string County { get; set; }
    }
    
    /// <summary>
    /// A class to contain the join query for all records
    /// </summary>
    public class JoinedOrderInfo
    {
        // OrderID number
        public int OrderId { get; set; }

        // Order status dates
        public DateTime? NewOrderCreatedWhen { get; set; }
        public DateTime? ReadyForPaymentWhen {get; set; }
        public DateTime? ReadyForPackagingWhen { get; set; }
        public DateTime? ReadyForPickupWhen { get; set; }
        public DateTime? OutForDeliveryWhen { get; set; }
        public DateTime? DeliveredWhen { get; set; }
        public DateTime? CanceledWhen { get; set; }
        public DateTime? ReturnedWhen { get; set; }

        // Customer information
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string ContactMethod { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string StreetAddress { get; set; }

        public string Zip { get; set; }
        public string AddressType { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string County { get; set; }


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
        /// The query to read all orders in the database.  Reads the databse one by one rather than
        /// performing one single large join query in the database
        /// </summary>
        //public void ReadAllOrders()
        //{
        //    MessageBox.Show("Reading all Orders");

        //    // Clear the JoinedOrderInfoList
        //    JoinedOrderInfoList.Clear();

        //    // Get the orders that meet our time / status criteria

        //    // Join the orders of our criteria with the customer data table

        //    // Join the orders of our criteria with the food order table

        //    // Join the order of our criteria with the otcmed table

        //    // Join the order with delivery area and delivery company

        //    // Join the order with the pharmacy info

        //    // Join the order with the provider info


        //    // Our context for the database
        //    using (var context = new Pharm2UEntities())
        //    {
        //        // join our order data with our customer data
        //        var AllOrders = (from order in context.P2U_Order
        //                         join customer in context.P2U_Customer
        //                         on order.CustomerID equals customer.ItemID

        //                         select new
        //                         {
        //                             OrderID = order.ItemID,
        //                             NewOrderCreatedWhen = order.NewOrderCreatedWhen,
        //                             ReadyForPaymentWhen = order.ReadyForPaymentWhen,
        //                             ReadyForPackagingWhen = order.ReadyForPackagingWhen,
        //                             ReadyForPickupWhen = order.ReadyForPickupWhen,
        //                             OutForDeliveryWhen = order.OutForDeliveryWhen,
        //                             DeliveredWhen = order.DeliveredWhen,
        //                             CanceledWhen = order.CanceledWhen,
        //                             ReturnedWhen = order.ReturnedWhen,

        //                             CustomerID = customer.ItemID,
        //                             FirstName = customer.FirstName,
        //                             LastName = customer.LastName,

        //                             ContactMethod = customer.ContactMethod,
        //                             Phone = customer.Phone,
        //                             Email = customer.Email,
        //                             StreetAddress = customer.StreetAddress,
        //                             Zip = customer.Zip,
        //                             AddressType = customer.AddressType,

        //                             Status = order.Status
        //                         }).ToList();

        //        foreach (var p in AllOrders)
        //        {
        //            // Determine our status enum for the order using the dates of the database record
        //            OrderStatusTypes statusType = DetermineOrderStatus(
        //                p.NewOrderCreatedWhen,
        //                p.ReadyForPaymentWhen,
        //                p.ReadyForPackagingWhen,
        //                p.ReadyForPickupWhen,
        //                p.OutForDeliveryWhen,
        //                p.DeliveredWhen,
        //                p.CanceledWhen,
        //                p.ReturnedWhen
        //                );


        //            // Record our database record from the order information search
        //            JoinedOrderInfo temp = new JoinedOrderInfo();

        //            temp.OrderId = p.OrderID;
        //            temp.FirstName = p.FirstName;
        //            temp.LastName = p.LastName;
        //            temp.CustomerId = p.CustomerID;

        //            temp.ContactMethod = p.ContactMethod;
        //            temp.Phone = p.Phone;
        //            temp.Email = p.Email;
        //            temp.StreetAddress = p.StreetAddress;
        //            temp.Zip = p.Zip;
        //            temp.AddressType = p.AddressType;

        //            temp.NewOrderCreatedWhen = p.NewOrderCreatedWhen;
        //            temp.ReadyForPaymentWhen = p.ReadyForPaymentWhen;
        //            temp.ReadyForPackagingWhen = p.ReadyForPackagingWhen;
        //            temp.ReadyForPickupWhen = p.ReadyForPickupWhen;
        //            temp.OutForDeliveryWhen = p.OutForDeliveryWhen;
        //            temp.DeliveredWhen = p.DeliveredWhen;
        //            temp.CanceledWhen = p.CanceledWhen;
        //            temp.ReturnedWhen = p.ReturnedWhen;
        //            temp.Status = p.Status;
        //            temp.StatusType = statusType;

        //            // Determine the city information based on the zip code of our query

        //            // join our order data with our customer data
        //            var cityresult = (from cityinfo in context.P2U_ZipCodes
        //                              where cityinfo.Zip == temp.Zip

        //                              select new
        //                              {
        //                                  City = cityinfo.City,
        //                                  State = cityinfo.State,
        //                                  Country = cityinfo.Country,
        //                                  County = cityinfo.County
        //                              }).ToList();

        //            // Take the first matching zipcode that isnt null
        //            bool cityFound = false;
        //            // Loop through our cityresult search results
        //            foreach (var c in cityresult)
        //            {
        //                // If we have valid strings in all fields on the result, take the first one
        //                if (c.City != null && c.State != null && c.Country != null && c.County != null)
        //                {
        //                    temp.City = c.City;
        //                    temp.State = c.State;
        //                    temp.Country = c.Country;
        //                    temp.County = c.County;
        //                    cityFound = true;
        //                    break;
        //                }
        //            }

        //            // If no matching record is found, install placeholder information
        //            if (!cityFound)
        //            {
        //                temp.City = "City?";
        //                temp.State = "State?";
        //                temp.Country = "Country?";
        //                temp.County = "County?";
        //            }

        //            // Add our entry to our list
        //            JoinedOrderInfoList.Add(temp);

        //        }
        //    }
        //}

        #endregion

        //#region Helper Methods
        ///// <summary>
        ///// A routine to determine the status of an order by looking at which time fields are currently null.
        ///// </summary>
        ///// <param name="NewOrderCreatedWhen">Time when the order was placed</param>
        ///// <param name="ReadyForPaymentWhen">Time when the order was marked ready for payment</param>
        ///// <param name="ReadyForPackagingWhen">Time when the order was marked ready for packaging</param>
        ///// <param name="ReadyForPickupWhen">Time when the order was marked ready for pickup</param>
        ///// <param name="OutForDeliveryWhen">Time when the order was marked out for delivery</param>
        ///// <param name="DeliveredWhen">Time when the order was marked as deliered / completed</param>
        ///// <param name="CanceledWhen">Time when the order was marked as canceled</param>
        ///// <param name="ReturnedWhen">Time as when the order was marked as returned</param>
        ///// <returns></returns>
        //public OrderStatusTypes DetermineOrderStatus(
        //                    DateTime? NewOrderCreatedWhen,
        //                    DateTime? ReadyForPaymentWhen,
        //                    DateTime? ReadyForPackagingWhen,
        //                    DateTime? ReadyForPickupWhen,
        //                    DateTime? OutForDeliveryWhen,
        //                    DateTime? DeliveredWhen,
        //                    DateTime? CanceledWhen,
        //                    DateTime? ReturnedWhen
        //    )
        //{
        //    // Check for null fields in the database UTC time fields to determine our status.
        //    // This is very ugly...
        //    if(NewOrderCreatedWhen != null)
        //    {
        //        if (ReadyForPaymentWhen != null)
        //        {
        //            if (ReadyForPackagingWhen != null)
        //            {
        //                if (ReadyForPickupWhen != null)
        //                {
        //                    if (OutForDeliveryWhen != null)
        //                    {
        //                        if (DeliveredWhen != null)
        //                        {
        //                            if ((CanceledWhen == null) || (ReturnedWhen == null))
        //                            {
        //                                if ((CanceledWhen == null) && (ReturnedWhen == null))
        //                                {
        //                                    return OrderStatusTypes.STATUS_COMPLETED;
        //                                }
        //                                else if ((CanceledWhen == null) && (ReturnedWhen != null))
        //                                    return OrderStatusTypes.STATUS_RETURN_NOT_DELIVERED;
        //                                else if ((CanceledWhen != null) && (ReturnedWhen == null))
        //                                    return OrderStatusTypes.STATUS_CANCELED;
        //                                else
        //                                {
        //                                    return OrderStatusTypes.STATUS_UNKNOWN;
        //                                }
        //                            } else
        //                            {
        //                                return OrderStatusTypes.STATUS_COMPLETED;
        //                            }

        //                        } else
        //                        {
        //                            return OrderStatusTypes.STATUS_OUT_FOR_DELIVERY;
        //                        }
        //                    } else
        //                    {
        //                        return OrderStatusTypes.STATUS_READY_FOR_PICKUP;
        //                    }

        //                } else
        //                {
        //                    return OrderStatusTypes.STATUS_READY_FOR_PACKAGING;
        //                }
        //            } else
        //            {
        //                return OrderStatusTypes.STATUS_READY_FOR_PAYMENT;
        //            }
        //        }
        //        else
        //        {
        //            return OrderStatusTypes.STATUS_NEWORDER;
        //        }
        //    }
        //    else
        //        return OrderStatusTypes.STATUS_UNKNOWN;
        //}
        //#endregion


        #region Default Constructor
        /// <summary>
        /// Default constructor
        /// </summary>

        ///// <summary>
        ///// Displays all the order records in the data base
        ///// </summary>
        //private void DisplayAllOrders()
        //{
        //    //Read all Orders
        //    ReadAllOrders();
        //}
        #endregion
    }
}
