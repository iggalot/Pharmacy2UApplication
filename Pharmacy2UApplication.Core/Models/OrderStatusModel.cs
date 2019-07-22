
namespace Pharmacy2UApplication.Core
{
    public enum OrderStatusTypes{
        STATUS_NEWORDER,
        STATUS_READY_FOR_PAYMENT,
        STATUS_READY_FOR_PACKAGING,
        STATUS_READY_FOR_DELIVERY,
        STATUS_OUT_FOR_DELIVERY,
        STATUS_RETURN_NOT_DELIVERED,
        STATUS_COMPLETED
    };

    public class OrderStatusModel
    {
    }
}
