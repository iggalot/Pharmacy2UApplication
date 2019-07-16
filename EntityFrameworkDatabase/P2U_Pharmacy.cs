//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFrameworkDatabase
{
    using System;
    using System.Collections.Generic;
    
    public partial class P2U_Pharmacy
    {
        public int ItemID { get; set; }
        public Nullable<int> ItemCreatedBy { get; set; }
        public Nullable<System.DateTime> ItemCreatedWhen { get; set; }
        public Nullable<int> ItemModifiedBy { get; set; }
        public Nullable<System.DateTime> ItemModifiedWhen { get; set; }
        public Nullable<int> ItemOrder { get; set; }
        public System.Guid ItemGUID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Zip { get; set; }
        public Nullable<bool> UseGlobalPricing { get; set; }
        public Nullable<decimal> GlobalDeliveryPrice { get; set; }
        public Nullable<bool> UseMinDeliveryAmt { get; set; }
        public Nullable<decimal> MinDeliveryAmt { get; set; }
        public Nullable<int> OrderTimeout { get; set; }
        public Nullable<int> PaymentTimeout { get; set; }
        public string GLNumber { get; set; }
        public Nullable<int> DefaultDeliveryCompany { get; set; }
        public Nullable<decimal> TaxRate { get; set; }
        public string OrderEmailAddress { get; set; }
        public string OrderEmailSubject { get; set; }
    }
}