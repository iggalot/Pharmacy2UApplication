using System;
using System.ComponentModel.DataAnnotations;

namespace Pharmacy2UApplication
{
    /// <summary>
    /// The Provider tables for our SQL server
    /// using the Entity Framework class design approach
    /// </summary>
    public class P2U_ProviderDataModel
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
        /// The provider ID number (used by Deaconess)
        /// </summary>
        [MaxLength(20)]
        public string ProviderID { get; set; }

        /// <summary>
        /// The full name of the provider
        /// </summary>
        [MaxLength(200)]
        public string FullName { get; set; }

        /// <summary>
        /// The email address of the provider
        /// </summary>
        [MaxLength(200)]
        public string Email { get; set; }
    }
}
