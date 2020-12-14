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
    /// A class that controls the reading and retrieving of order data from the data base
    /// TODO:  Move this to .CORE project -- issues with namespace naming in the meantime
    /// </summary>
    public class DatabaseQueryViewModel : BaseViewModel
    {
        #region Constructor

        public DatabaseQueryViewModel()
        {
            // Initialize our database query lists
            FullOrderInfoList = new ObservableCollection<OrderListItemViewModel>();
            FullFoodInfoList = new ObservableCollection<FoodListItemViewModel>();

            // Query the database for all orders
            ReadAllOrders();
            ReadAllFoods();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// The collection entity to store our list of full order data queries
        /// </summary>
        public static ObservableCollection<OrderListItemViewModel> FullOrderInfoList { get; set; }

        /// <summary>
        /// The collection entity for all food items  data queries
        /// </summary>
        public static ObservableCollection<FoodListItemViewModel> FullFoodInfoList { get; set; }

        #endregion

        #region DB Interaction Commands

        /// <summary>
        /// The query to read all orders in the database.  Reads the database one by one rather than
        /// performing one single large join query in the database
        /// </summary>
        public void ReadAllOrders()
        {
            // Clear the JoinedOrderInfoList
            FullOrderInfoList.Clear();

            // Our context for the database
            using (var context = new Pharm2UEntities3())
            {
                // join our order data with our customer data
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

                                     ContactMethod = customer.ContactMethod,
                                     Phone = customer.Phone,
                                     Email = customer.Email,
                                     StreetAddress = customer.StreetAddress,
                                     Zip = customer.Zip,
                                     AddressType = customer.AddressType,

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


                    // Record our database record from the order information search
                    OrderListItemViewModel temp = new OrderListItemViewModel();

                    temp.OrderId = p.OrderID;
                    temp.FirstName = p.FirstName;
                    temp.LastName = p.LastName;
                    temp.CustomerId = p.CustomerID;

                    temp.ContactMethod = p.ContactMethod;
                    temp.Phone = p.Phone;
                    temp.Email = p.Email;
                    temp.StreetAddress = p.StreetAddress;
                    temp.Zip = p.Zip;
                    temp.AddressType = p.AddressType;

                    temp.NewOrderCreatedWhen = p.NewOrderCreatedWhen;
                    temp.ReadyForPaymentWhen = p.ReadyForPaymentWhen;
                    temp.ReadyForPackagingWhen = p.ReadyForPackagingWhen;
                    temp.ReadyForPickupWhen = p.ReadyForPickupWhen;
                    temp.OutForDeliveryWhen = p.OutForDeliveryWhen;
                    temp.DeliveredWhen = p.DeliveredWhen;
                    temp.CanceledWhen = p.CanceledWhen;
                    temp.ReturnedWhen = p.ReturnedWhen;
                    temp.Status = p.Status;
                    temp.StatusType = statusType;

                    // Determine the city information based on the zip code of our query

                    // join our order data with our customer data
                    var cityresult = (from cityinfo in context.P2U_ZipCodes
                                      where cityinfo.Zip == temp.Zip

                                      select new
                                      {
                                          City = cityinfo.City,
                                          State = cityinfo.State,
                                          Country = cityinfo.Country,
                                          County = cityinfo.County
                                      }).ToList();

                    // Take the first matching zipcode that isnt null
                    bool cityFound = false;
                    // Loop through our cityresult search results
                    foreach (var c in cityresult)
                    {
                        // If we have valid strings in all fields on the result, take the first one
                        if (c.City != null && c.State != null && c.Country != null && c.County != null)
                        {
                            temp.City = c.City;
                            temp.State = c.State;
                            temp.Country = c.Country;
                            temp.County = c.County;
                            cityFound = true;
                            break;
                        }
                    }

                    // If no matching record is found, install placeholder information
                    if (!cityFound)
                    {
                        temp.City = "City?";
                        temp.State = "State?";
                        temp.Country = "Country?";
                        temp.County = "County?";
                    }

                    // Add our entry to our list
                    FullOrderInfoList.Add(temp);

                }
            }
        }


        /// <summary>
        /// The query to read all orders in the database.  Reads the database one by one rather than
        /// performing one single large join query in the database
        /// </summary>
        public void ReadAllFoods()
        {
            // Clear the JoinedOrderInfoList
            FullFoodInfoList.Clear();

            // Our context for the database
            using (var context = new Pharm2UEntities3())
            {
                // join our order data with our customer data
                var AllOrders = (from food in context.P2U_Food

                                 select new
                                 {  
                                     FoodIDNumber = food.ItemID,
                                     FoodItemCreatedWhen = food.ItemCreatedWhen,
                                     FoodItemCreatedBy = food.ItemCreatedBy,
                                     FoodItemModifiedWhen = food.ItemModifiedWhen,
                                     FoodItemModifiedBy = food.ItemModifiedBy,
                                     FoodName = food.Name,
                                     FoodDescription = food.Description,
                                     FoodType = food.Type,
                                     FoodIsTaxable = food.Taxable,
                                     FoodPrice = food.Price
                                 }).ToList();

                foreach (var p in AllOrders)
                {
                    // Record our database record from the order information search
                    FoodListItemViewModel temp = new FoodListItemViewModel();

                    temp.FoodIDNumber = p.FoodIDNumber;
                    temp.FoodCreatedWhen = p.FoodItemCreatedWhen;
                    temp.FoodCreatedBy = p.FoodItemCreatedBy;
                    temp.FoodModifiedWhen = p.FoodItemModifiedWhen;
                    temp.FoodModifiedBy = p.FoodItemModifiedBy;
                    temp.FoodName = p.FoodName;
                    temp.FoodDescription = p.FoodDescription;
                    temp.FoodType = p.FoodType;
                    temp.FoodIsTaxable = p.FoodIsTaxable;
                    temp.FoodPrice = p.FoodPrice;

                    

                    // Add our entry to our list
                    FullFoodInfoList.Add(temp);

                }
            }
        }



        /// <summary>
        /// Displays all the order records in the data base
        /// </summary>
        private void DisplayAllOrders()
        {
            //Read all Orders
            ReadAllOrders();
        }
            #endregion

        #region Helper Methods
        /// <summary>
        /// Returns the FullOrderInfoList from the query
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<OrderListItemViewModel> GetFullOrderList()
        {
            return FullOrderInfoList;
        }

        /// <summary>
        /// Returns the FullFoodInfoList from the query
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<FoodListItemViewModel> GetFullFoodList()
        {
            return FullFoodInfoList;
        }

        /// <summary>
        /// A routine to determine the status of an order by looking at which time fields are currently null.
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
            if (NewOrderCreatedWhen != null)
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
                                    if ((CanceledWhen == null) || (ReturnedWhen == null))
                                    {
                                        if ((CanceledWhen == null) && (ReturnedWhen == null))
                                        {
                                            return OrderStatusTypes.STATUS_COMPLETED;
                                        }
                                        else if ((CanceledWhen == null) && (ReturnedWhen != null))
                                            return OrderStatusTypes.STATUS_RETURN_NOT_DELIVERED;
                                        else if ((CanceledWhen != null) && (ReturnedWhen == null))
                                            return OrderStatusTypes.STATUS_CANCELED;
                                        else
                                        {
                                            return OrderStatusTypes.STATUS_UNKNOWN;
                                        }
                                    }
                                    else
                                    {
                                        return OrderStatusTypes.STATUS_COMPLETED;
                                    }

                                }
                                else
                                {
                                    return OrderStatusTypes.STATUS_OUT_FOR_DELIVERY;
                                }
                            }
                            else
                            {
                                return OrderStatusTypes.STATUS_READY_FOR_PICKUP;
                            }

                        }
                        else
                        {
                            return OrderStatusTypes.STATUS_READY_FOR_PACKAGING;
                        }
                    }
                    else
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
    }
}
