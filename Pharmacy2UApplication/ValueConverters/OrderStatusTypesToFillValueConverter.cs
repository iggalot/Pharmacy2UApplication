using Pharmacy2UApplication.Core;
using System;
using System.Globalization;
using System.Windows.Media;

namespace Pharmacy2UApplication
{

    /// <summary>
    /// A converter that takes in the StatusType of the Order and converts it to a brush color.  It also adjusts the individual
    /// display of the bars based on the status as well -- completed has all bars colored.  New order only has one bar colored;
    /// </summary>
    public class OrderStatusTypesToFillValueConverter : BaseValueConverter<OrderStatusTypesToFillValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Determine the rectangle number
            int rectNum;
            // Retrieve which rectangle of the display we are looking at
            switch((string)parameter)
            {
                case "1": rectNum = 1; break;
                case "2": rectNum = 2; break;
                case "3": rectNum = 3; break;
                case "4": rectNum = 4; break;
                case "5": rectNum = 5; break;
                case "6": rectNum = 6; break;
                case "7": rectNum = 7; break;
                default: rectNum = 8; break;
            }

            // Now determine the color
            OrderStatusTypes status = (OrderStatusTypes)value;
            Color color;

            // If the order status is unknow -- return all bars as black
            if(status == OrderStatusTypes.STATUS_UNKNOWN)
                return new SolidColorBrush(Colors.Black);

            // Otherwise, find the color based on the determined status of the order
            // Find the appropriate color
            switch (status)
            {
                case (OrderStatusTypes.STATUS_NEWORDER):
                    color = Colors.Red;
                    break;
                case (OrderStatusTypes.STATUS_READY_FOR_PAYMENT):
                    color = Colors.Orange;
                    break;
                case (OrderStatusTypes.STATUS_READY_FOR_PACKAGING):
                    color = Colors.Yellow;
                    break;
                case (OrderStatusTypes.STATUS_READY_FOR_PICKUP):
                    color = Colors.Green;
                    break;
                case (OrderStatusTypes.STATUS_OUT_FOR_DELIVERY):
                    color = Colors.Blue;
                    break;
                case (OrderStatusTypes.STATUS_COMPLETED):
                    color = Colors.Purple;
                    break;
                case (OrderStatusTypes.STATUS_CANCELED):
                    color = Colors.Gray;
                    break;
                case (OrderStatusTypes.STATUS_RETURN_NOT_DELIVERED):
                    color = Colors.DarkGray;
                    break;
                default:
                    color = Colors.Black;
                    break;
            }

            // If the bar should be filled based on the status, return the rush for the color, otherwise return it as transparent
            return new SolidColorBrush((rectNum <= (int)status) ? color : Colors.Transparent);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
