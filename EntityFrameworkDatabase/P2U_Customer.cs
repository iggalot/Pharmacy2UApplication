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
    
    public partial class P2U_Customer
    {
        public int ItemID { get; set; }
        public Nullable<int> ItemCreatedBy { get; set; }
        public Nullable<System.DateTime> ItemCreatedWhen { get; set; }
        public Nullable<int> ItemModifiedBy { get; set; }
        public Nullable<System.DateTime> ItemModifiedWhen { get; set; }
        public Nullable<int> ItemOrder { get; set; }
        public System.Guid ItemGUID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactMethod { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string StreetAddress { get; set; }
        public string Zip { get; set; }
        public string AddressType { get; set; }
    }
}