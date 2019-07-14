using System;
using System.ComponentModel.DataAnnotations;

namespace Pharmacy2UApplication
{
    /// <summary>
    /// The Delivery Company tables for our SQL server
    /// using the Entity Framework class design approach
    /// </summary>
    public class P2U_DeliveryCompanyDataModel
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
        /// The name of the delivery company
        /// </summary>
        [MaxLength(200)]
        public string Name { get; set; }

        /// <summary>
        /// The address of the delivery company
        /// </summary>
        [MaxLength(400)]
        public string Address { get; set; }

        /// <summary>
        /// The zip code for the delivery
        /// </summary>
        [MaxLength(20)]
        public string Zip { get; set; }

        /// <summary>
        /// Phone number for the delivery company
        /// </summary>
        [MaxLength(20)]
        public string Phone { get; set; }

        /// <summary>
        /// Fax number for the delivery company
        /// </summary>
        [MaxLength(20)]
        public string Fax { get; set; }

        /// <summary>
        /// Email for the delivery company
        /// </summary>
        public string Email { get; set; }

    }
}


