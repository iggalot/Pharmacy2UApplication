using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Pharmacy2UApplication
{
    /// <summary>
    /// The Order tables for our SQL server
    /// using the Entity Framework class design approach
    /// </summary>
    public class P2U_OrderDataModel
    {
        /// <summary>
        /// The unique Id for this entry
        /// </summary>
        [Required]
        [Key]
        public int ItemID { get; set; }

        /// <summary>
        /// Item created by
        /// </summary>
        public int ItemCreatedBy { get; set; }

        /// <summary>
        /// When was the table entry created
        /// </summary>
        public DateTime ItemCreatedWhen { get; set; }

        /// <summary>
        /// Who modified it last?
        /// </summary>
        public int ItemModifiedBy { get; set; }

        /// <summary>
        /// When was it modified last?
        /// </summary>
        public DateTime ItemModifiedWhen { get; set; }

        /// <summary>
        /// Which order is being cancelled
        /// </summary>
        public int ItemOrder { get; set; }

        /// <summary>
        /// Unique identifier for ???
        /// </summary>
        [Required]
        public Guid ItemGUID { get; set; }





        /// <summary>
        /// The customer ID
        /// </summary>
        [Required]
        public int CustomerID { get; set; }

        /// <summary>
        /// The assigned pharmacy id for the order
        /// </summary>
        public int PharmacyID { get; set; }

        /// <summary>
        /// The assigned delivery company for the order
        /// </summary>
        public int DeliveryCompanyID { get; set; }

        /// <summary>
        /// The name of the service provider
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string ProviderUsername { get; set; }

        /// <summary>
        /// Status of the order
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Status { get; set; }

        /// <summary>
        /// Delivery window of the order
        /// </summary>
        [MaxLength(200)]
        public string DeliveryWindow { get; set; }

        /// <summary>
        /// Delivery instructions for the order
        /// </summary>
        [MaxLength]
        public string DeliveryInstructions { get; set; }

        /// <summary>
        /// Cost of the delivery
        /// TODO:  Format precision to 12,2
        /// </summary>
        public decimal DeliveryCost { get; set; }

        /// <summary>
        /// Cost of food for this order
        /// TODO:  Format precision to 12,2
        /// </summary>
        public decimal FoodCost { get; set; }

        /// <summary>
        /// OTC medical items cost
        /// TODO:  Format precision to 12,2
        /// </summary>
        public decimal OTCMedCost { get; set; }

        /// <summary>
        /// Prescription items costs for this order
        /// </summary>
        public decimal PrescriptionCost { get; set; }

        /// <summary>
        /// Tax for the order
        /// </summary>
        public decimal Tax { get; set; }

        /// <summary>
        /// Total cost for the order
        /// </summary>
        public decimal TotalCost { get; set; }

        /// <summary>
        /// Authorization code for the order
        /// </summary>
        [MaxLength(100)]
        public string AuthCode { get; set; }

        /// <summary>
        /// The transaction key for the order
        /// </summary>
        [MaxLength(225)]
        public string TransactionKey { get; set; }

        /// <summary>
        /// The credit card number for the order
        /// </summary>
        [MaxLength(10)]
        public string CardNumber { get; set; }

        /// <summary>
        /// The time when the order was initiated
        /// </summary>
        public DateTime OrderInitiatedWhen { get; set; }

        /// <summary>
        /// The time when the order was created as new
        /// </summary>
        public DateTime NewOrderCreatedWhen { get; set; }

        /// <summary>
        /// The time when the order was tagged as ready for payment
        /// </summary>
        public DateTime ReadyForPaymentWhen { get; set; }

        /// <summary>
        /// The time when the order was tagged as ready for packaging
        /// </summary>
        public DateTime ReadyForPackagingWhen { get; set; }

        /// <summary>
        /// The time when the order was tagged as ready for pickup
        /// </summary>
        public DateTime ReadyForPickupWhen { get; set; }

        /// <summary>
        /// The time when the order was tagged as out for delivery
        /// </summary>
        public DateTime OutForDeliveryWhen { get; set; }

        /// <summary>
        /// The time when the order was tagged as delivered
        /// </summary>
        public DateTime DeliveredWhen { get; set; }

        /// <summary>
        /// The time when the order was tagged as canceled
        /// </summary>
        public DateTime CanceledWhen { get; set; }

        /// <summary>
        /// Reason for a cancellation
        /// </summary>
        [MaxLength(200)]
        public string CanceledReason { get; set; }

        /// <summary>
        /// Time of the return of the order
        /// </summary>
        public DateTime ReturnedWhen { get; set; }

        /// <summary>
        /// Reason for the return
        /// </summary>
        [MaxLength(200)]
        public string ReturnedReason { get; set; }
    }
}


