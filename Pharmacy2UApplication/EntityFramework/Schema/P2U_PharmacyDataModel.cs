using System;
using System.ComponentModel.DataAnnotations;

namespace Pharmacy2UApplication
{
    /// <summary>
    /// The Pharmacy tables for our SQL server
    /// using the Entity Framework class design approach
    /// </summary>
    public class P2U_PharmacyDataModel
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
        /// The name of the pharmacy
        /// </summary>
        [MaxLength(200)]
        public string Name { get; set; }

        /// <summary>
        /// The address of the pharmacy
        /// </summary>
        [MaxLength(400)]
        public string Address { get; set; }

        /// <summary>
        /// Phone number for the pharmacy
        /// </summary>
        [MaxLength(20)]
        public string Phone { get; set; }

        /// <summary>
        /// The zip code for the pharmacy
        /// </summary>
        [MaxLength(20)]
        public string Zip { get; set; }

        /// <summary>
        /// Use global pricing?
        /// </summary>
        public bool UseGlobalPricing { get; set; }

        /// <summary>
        /// The global delivery price
        /// TODO: set precision to 12,2
        /// </summary>
        public decimal GlobalDeliveryPrice { get; set; }

        /// <summary>
        /// Flag that indicates if the minimum delivery amount should be used
        /// </summary>
        public Boolean UseMinDeliveryAmt { get; set; }

        /// <summary>
        /// The minimum delivery amount for this pharmacy
        /// </summary>
        public decimal MinDeliveryAmt { get; set; }

        /// <summary>
        /// The order timeout for this pharmacy
        /// </summary>
        public int OrderTimeout { get; set; }

        /// <summary>
        /// The payment timeout for this pharmacy
        /// </summary>
        public int PaymentTimeout { get; set; }

        /// <summary>
        /// The GL number for the pharmacy
        /// </summary>
        public string GLNumber { get; set; }

        /// <summary>
        /// The ID for hte default delivery company
        /// </summary>
        public int DefaultDeliveryCompany { get; set; }

        /// <summary>
        /// The tax rate for this pharmacy
        /// TODO: Set precision to 19,4
        /// </summary>
        public decimal TaxRate { get; set; }

        /// <summary>
        /// The email address for the pharmacy?
        /// </summary>
        [MaxLength(200)]
        public string OrderEmailAddress { get; set; }

        /// <summary>
        /// The email subject for emails that are sent to the pharmacy?
        /// </summary>
        [MaxLength(200)]
        public string OrderEmailSubject { get; set; }




    }
}


