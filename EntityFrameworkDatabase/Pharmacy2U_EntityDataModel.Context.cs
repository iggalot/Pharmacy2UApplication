﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Pharm2UEntities : DbContext
    {
        public Pharm2UEntities()
            : base("name=Pharm2UEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<P2U_CancellationReason> P2U_CancellationReason { get; set; }
        public virtual DbSet<P2U_Customer> P2U_Customer { get; set; }
        public virtual DbSet<P2U_DeliveryArea> P2U_DeliveryArea { get; set; }
        public virtual DbSet<P2U_DeliveryCompany> P2U_DeliveryCompany { get; set; }
        public virtual DbSet<P2U_Food> P2U_Food { get; set; }
        public virtual DbSet<P2U_Order> P2U_Order { get; set; }
        public virtual DbSet<P2U_OrderFood> P2U_OrderFood { get; set; }
        public virtual DbSet<P2U_OrderOTCMeds> P2U_OrderOTCMeds { get; set; }
        public virtual DbSet<P2U_OTCMedication> P2U_OTCMedication { get; set; }
        public virtual DbSet<P2U_Pharmacy> P2U_Pharmacy { get; set; }
        public virtual DbSet<P2U_Provider> P2U_Provider { get; set; }
        public virtual DbSet<P2U_ReturnedReason> P2U_ReturnedReason { get; set; }
        public virtual DbSet<P2U_Statuses> P2U_Statuses { get; set; }
        public virtual DbSet<P2U_ZipCodes> P2U_ZipCodes { get; set; }
    }
}
