using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Pharmacy2UApplication
{
    /// <summary>
    /// The Food tables for our SQL server
    /// using the Entity Framework class design approach
    /// </summary>
    public class P2U_OTCMedicationDataModel
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
        /// The name of the food
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        /// <summary>
        /// The description for the food
        /// </summary>
        [MaxLength]
        public string Description { get; set; }

        /// <summary>
        /// Price of the food item
        /// TODO: Set the precision for this table to (12, 2)
        /// </summary>
        [Required]
        public decimal Price { get; set; }

        /// <summary>
        /// Is this item taxable?
        /// </summary>
        [Required]
        public bool Taxable { get; set; }

    }
}


