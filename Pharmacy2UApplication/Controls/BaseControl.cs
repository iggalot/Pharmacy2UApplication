
using Pharmacy2UApplication.Core;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Pharmacy2UApplication
{
    /// <summary>
    /// A class to contain the common basic behavior for all UI controls in the application
    /// </summary>
    public class BaseControl : UserControl
    {
        #region Public Members

        /// <summary>
        /// The command to execute when the All Orders button is clicked
        /// </summary>
        public ICommand AllOrdersCommand { get; set; }

        /// <summary>
        /// The command to execute when the New Orders button is clicked.
        /// </summary>
        public ICommand NewOrdersCommand { get; set; }

        /// <summary>
        /// The command to execute when the Ready For Payment button is clicked
        /// </summary>
        public ICommand ReadyForPaymentCommand { get; set; }

        /// <summary>
        /// The command to execute when the Ready For Packaging button is clicked
        /// </summary>
        public ICommand ReadyForPackagingCommand { get; set; }

        /// <summary>
        /// The command to execute when the Ready For Delivery button is clicked
        /// </summary>
        public ICommand ReadyForDeliveryCommand { get; set; }

        /// <summary>
        /// The command to execute when the Out for Delivery button is clicked
        /// </summary>
        public ICommand OutForDeliveryCommand { get; set; }

        /// <summary>
        /// The command to execute when the Returned Orders button is clicked
        /// </summary>
        public ICommand ReturnedOrdersCommand { get; set; }

        /// <summary>
        ///  The command to execute when the Completed Orders button is clicked
        /// </summary>
        public ICommand CompletedOrdersCommand { get; set; }

        /// <summary>
        /// The command to execute when the OTCMedication Admin button is clicked
        /// </summary>
        public ICommand AdminOTCMedicationEditCommand { get; set; }

        /// <summary>
        /// The command to execute when the Food Admin button is clicked
        /// </summary>
        public ICommand AdminFoodEditCommand { get; set; }

        /// <summary>
        /// The command to execute when the Pharmacy admin button is clicked
        /// </summary>
        public ICommand AdminPharmacyEditCommand { get; set; }

        /// <summary>
        /// The command to execute when the Delivery admin button is clicked
        /// </summary>
        public ICommand AdminDeliveryEditCommand { get; set; }

        #endregion

        #region Default Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseControl()
        {
            // The relayed commands to be used by the order status control of the UI
            AllOrdersCommand = new RelayCommand(() => this.GetAllOrders());
            NewOrdersCommand = new RelayCommand(() => this.GetNewOrders());
            ReadyForPaymentCommand = new RelayCommand(() => this.GetReadyForPaymentOrders());
            ReadyForPackagingCommand = new RelayCommand(() => this.GetReadyForPackagingOrders());
            ReadyForDeliveryCommand = new RelayCommand(() => this.GetReadyForDeliveryOrders());
            OutForDeliveryCommand = new RelayCommand(() => this.GetOutForDeliveryOrders());
            ReturnedOrdersCommand = new RelayCommand(() => this.GetReturnedOrders());
            CompletedOrdersCommand = new RelayCommand(() => this.GetCompletedOrders());

            AdminOTCMedicationEditCommand = new RelayCommand(() => this.GetAdminOTCMedicationEdit());
            AdminFoodEditCommand = new RelayCommand(() => this.GetAdminFoodEdit());
            AdminPharmacyEditCommand = new RelayCommand(() => this.GetAdminPharmacyEdit());
            AdminDeliveryEditCommand = new RelayCommand(() => this.GetAdminDeliveryEdit());
        }

        #endregion

        #region Commands 
        /// <summary>
        /// The functionality for when the user clicks the New Order button on the OrderStatusControl
        /// </summary>
        public void GetAllOrders()
        {
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.AllOrdersPage);
        }

        /// <summary>
        /// The functionality for when the user clicks the New Order button on the OrderStatusControl
        /// </summary>
        public void GetNewOrders()
        {
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.NewOrdersPage);
        }

        /// <summary>
        /// The functionality for when the user clicks the Ready For Payment button on the OrderStatusControl
        /// </summary>
        public void GetReadyForPaymentOrders()
        {
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.ReadyForPaymentOrdersPage);
        }

        /// <summary>
        /// The functionality for when the user clicks the Ready for Packaging button on the OrderStatusControl
        /// </summary>
        public void GetReadyForPackagingOrders()
        {
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.ReadyForPackagingOrdersPage);
        }

        /// <summary>
        /// The functionality for when the user clicks the Ready for Delivery button on the OrderStatusControl
        /// </summary>
        public void GetReadyForDeliveryOrders()
        {
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.ReadyForDeliveryOrdersPage);
        }

        /// <summary>
        /// The functionality for when the user clicks the Out for Delivery button on the OrderStatusControl
        /// </summary>
        public void GetOutForDeliveryOrders()
        {
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.OutForDeliveryOrdersPage);
        }

        /// <summary>
        /// The functionality for when the user clicks the Returned Orders button on the OrderStatusControl
        /// </summary>
        public void GetReturnedOrders()
        {
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.ReturnedOrdersPage);
        }

        /// <summary>
        /// The functionality for when the user clicks the Completed Orders button on the OrderStatusControl
        /// </summary>
        public void GetCompletedOrders()
        {
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.CompletedOrdersPage);
        }

        /// <summary>
        /// The functionality for when the user clickes the OTC Medication admin button on the AdminControl
        /// </summary>
        public void GetAdminOTCMedicationEdit()
        {
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.AdminOTCMedicationEditPage);
        }

        /// <summary>
        /// The functionality for when the user clickes the Food admin button on the AdminControl
        /// </summary>
        public void GetAdminFoodEdit()
        {
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.AdminFoodEditPage);
        }

        /// <summary>
        /// The functionality for when the user clickes the Pharmacy admin button on the AdminControl
        /// </summary>
        public void GetAdminPharmacyEdit()
        {
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.AdminPharmacyEditPage);
        }

        /// <summary>
        /// The functionality for when the user clickes the Delivery admin button on the AdminControl
        /// </summary>
        public void GetAdminDeliveryEdit()
        {
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.AdminDeliveryEditPage);
        }




        #endregion
    }
}
