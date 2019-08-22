
namespace Pharmacy2UApplication.Core
{
    public enum OrderStatusTypes{
        STATUS_NEWORDER                 = 0,
        STATUS_READY_FOR_PAYMENT        = 1,
        STATUS_READY_FOR_PACKAGING      = 2,
        STATUS_READY_FOR_PICKUP         = 3,
        STATUS_OUT_FOR_DELIVERY         = 4,
        STATUS_RETURN_NOT_DELIVERED     = 5,
        STATUS_CANCELED                 = 6,
        STATUS_COMPLETED                = 7,
        STATUS_UNKNOWN                  = 8
    };

    public class OrderStatusModel
    {
    }
}
