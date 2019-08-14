using System;

namespace Pharmacy2UApplication.Core
{
     public class OrderListItemViewModel : BaseViewModel
    {
        #region Public Properties

        // OrderID number
        public int OrderId { get; set; }

        // Order status dates
        public DateTime? NewOrderCreatedWhen { get; set; }
        public DateTime? ReadyForPaymentWhen { get; set; }
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
        #endregion


        #region Constructor 

        /// <summary>
        /// Default parameterless constructor to be used by the database queries
        /// </summary>
        public OrderListItemViewModel() { }

        /// <summary>
        /// Constructor for a partial view model
        /// </summary>
        /// <param name="first">First name</param>
        /// <param name="last">Last name</param>
        /// <param name="num">Order ID number</param>
        public OrderListItemViewModel(string first, string last, int num)
        {
            FirstName = first;
            LastName = last;
            OrderId = num;
        }

        #endregion
    }
}
