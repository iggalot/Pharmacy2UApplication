using System;
using System.ComponentModel.DataAnnotations;

namespace Pharmacy2UApplication
{
    /// <summary>
    /// The Delivery Area tables for our SQL server
    /// using the Entity Framework class design approach
    /// </summary>
    public class P2U_DeliveryAreaDataModel
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
        /// The zip code for the delivery
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Zip { get; set; }

        /// <summary>
        /// ID for the responsible pharmacy
        /// </summary>
        public int PharmacyID { get; set; }

        /// <summary>
        /// Delivery price (should be precision 12,2) -- need to set this in OnModelCreating with
        /// .HasPrecision(12,2) set.
        /// </summary>
        public decimal DeliveryPrice { get; set; }

    }
}


