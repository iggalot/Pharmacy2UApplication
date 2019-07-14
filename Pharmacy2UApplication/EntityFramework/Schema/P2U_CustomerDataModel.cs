using System;
using System.ComponentModel.DataAnnotations;

namespace Pharmacy2UApplication
{
    /// <summary>
    /// The Customer tables for our SQL server
    /// using the Entity Framework class design approach
    /// </summary>
    public class P2U_CustomerDataModel
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
        /// Custom reason for the cancellation
        /// </summary>
        [MaxLength(200)]
        public string FirstName { get; set; }

        /// <summary>
        /// Custom reason for the cancellation
        /// </summary>
        [MaxLength(200)]
        public string LastName { get; set; }

        /// <summary>
        /// Custom reason for the cancellation
        /// </summary>
        [MaxLength(20)]
        public string ContactMethod { get; set; }

        /// <summary>
        /// Custom reason for the cancellation
        /// </summary>
        [MaxLength(20)]
        public string Phone { get; set; }

        /// <summary>
        /// Custom reason for the cancellation
        /// </summary>
        [MaxLength(200)]
        public string Email { get; set; }

        /// <summary>
        /// Custom reason for the cancellation
        /// </summary>
        [MaxLength(500)]
        public string StreetAddress { get; set; }

        /// <summary>
        /// Custom reason for the cancellation
        /// </summary>
        [MaxLength(500)]
        public string Zip { get; set; }

        /// <summary>
        /// ????
        /// </summary>
        [MaxLength(20)]
        public string AddressType { get; set; }

    }
}

