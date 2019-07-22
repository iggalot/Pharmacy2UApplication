
namespace Pharmacy2UApplication.Core
{
    /// <summary>
    /// A page of the application
    /// </summary>
    public enum ApplicationPage
    {
        /// <summary>
        /// For no page to be displayed
        /// </summary>
        None = 0,

        /// <summary>
        /// The initial login page
        /// </summary>
        Login = 1,

        /// <summary>
        /// The register page
        /// </summary>
        Register = 2,

        /// <summary>
        /// The search page
        /// </summary>
        Search = 3,

        /// <summary>
        /// The order information page
        /// </summary>
        OrderInformationPage = 4,

        /// <summary>
        /// For displaying the information about NewOrders
        /// </summary>
        NewOrdersPage = 5,

        /// <summary>
        /// For displaying the information about Ready for Payment Orders
        /// </summary>
        ReadyForPaymentOrdersPage = 6,

        /// <summary>
        /// For displaying the information about Ready for Packaging Orders
        /// </summary>
        ReadyForPackagingOrdersPage = 7,

        /// <summary>
        /// For displaying the information about Ready for Delivery Orders
        /// </summary>
        ReadyForDeliveryOrdersPage = 8,

        /// <summary>
        /// For displaying the information about Out for Delivery Orders
        /// </summary>
        OutForDeliveryOrdersPage = 9,

        /// <summary>
        /// For displaying the information about Returned Orders
        /// </summary>
        ReturnedOrdersPage = 10,

        /// <summary>
        /// For displaying the information about Completed Orders
        /// </summary>
        CompletedOrdersPage = 11,

        /// <summary>
        /// For displaying the information about ALL Orders
        /// </summary>
        AllOrdersPage = 12,

    }
}
