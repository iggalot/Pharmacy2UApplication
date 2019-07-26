
namespace Pharmacy2UApplication.Core
{
    public enum OrderStatusTypes{
        STATUS_NEWORDER                 = 1,
        STATUS_READY_FOR_PAYMENT        = 2,
        STATUS_READY_FOR_PACKAGING      = 3,
        STATUS_READY_FOR_PICKUP         = 4,
        STATUS_OUT_FOR_DELIVERY         = 5,
        STATUS_RETURN_NOT_DELIVERED     = 6,
        STATUS_CANCELED                 = 7,
        STATUS_COMPLETED                = 8,
        STATUS_UNKNOWN                  = 9
    };

    public class OrderStatusModel
    {
    }
}
