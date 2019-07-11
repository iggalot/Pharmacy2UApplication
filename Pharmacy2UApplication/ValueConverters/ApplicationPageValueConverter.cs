
using System;
using System.Diagnostics;
using System.Globalization;

namespace Pharmacy2UApplication
{
    /// <summary>
    /// Converts the <see cref="ApplicationPage"/> to an actual view/page
    /// </summary>
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Find the appropriate page
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.Login:
                    return new LoginPage();

                case ApplicationPage.OrderInformationPage:
                    return new OrderInformationPage();

                case ApplicationPage.NewOrdersPage:
                    return new NewOrdersPage();

                case ApplicationPage.ReadyForPaymentOrdersPage:
                    return new ReadyForPaymentOrdersPage();

                case ApplicationPage.ReadyForPackagingOrdersPage:
                    return new ReadyForPackagingOrdersPage();

                case ApplicationPage.ReadyForDeliveryOrdersPage:
                    return new ReadyForDeliveryOrdersPage();

                case ApplicationPage.OutForDeliveryOrdersPage:
                    return new OutForDeliveryOrdersPage();

                case ApplicationPage.ReturnedOrdersPage:
                    return new ReturnedOrdersPage();

                case ApplicationPage.CompletedOrdersPage:
                    return new CompletedOrdersPage();

                case ApplicationPage.AllOrdersPage:
                    return new AllOrdersPage();
                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
