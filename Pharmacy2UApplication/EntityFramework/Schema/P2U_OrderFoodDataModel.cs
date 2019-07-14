using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Pharmacy2UApplication
{
    /// <summary>
    /// The OrderFood tables for our SQL server
    /// using the Entity Framework class design approach
    /// </summary>
    public class P2U_OrderFoodDataModel
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
        /// The order ID
        /// </summary>
        [Required]
        public int OrderID { get; set; }

        /// <summary>
        /// The food id entry
        /// </summary>
        public int FoodID { get; set; }
        
        /// <summary>
        /// The price of the food item
        /// TODO:  Set precision on decimal to 12,2
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The quantity of this item
        /// </summary>
        [Required]
        public int Qty { get; set; }

        /// <summary>
        /// The taxable bit for this food item
        /// </summary>
        [Required]
        public Boolean Taxable { get; set; }
    }
}


