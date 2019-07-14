using System;
using System.ComponentModel.DataAnnotations;

namespace Pharmacy2UApplication
{
    /// <summary>
    /// The Cancellation Reason tables for our SQL server
    /// using the Entity Framework class design approach
    /// </summary>
    public class P2U_ZipCodesDataModel
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
        /// The zipcode
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Zip { get; set; }

        /// <summary>
        /// The city associated with the zipcode
        /// </summary>
        [MaxLength(100)]
        public string City { get; set; }

        /// <summary>
        /// The county associated with the zipcode
        /// </summary>
        [MaxLength(100)]
        public string County { get; set; }

        /// <summary>
        /// The state associated with the zipcode
        /// </summary>
        [MaxLength(2)]
        public string State { get; set; }

        /// <summary>
        /// The country associated with the zipcode
        /// </summary>
        [MaxLength(200)]
        public string Country { get; set; }

        /// <summary>
        /// The latitude associated with the zipcode
        /// </summary>
        public float Latitude { get; set; }

        /// <summary>
        /// The longitude associated with the zipcode
        /// </summary>
        public float Longitude { get; set; }
    }
}
