﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Spedycja.Model.EntityModels
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SpedycjaEntities : DbContext
    {
        public SpedycjaEntities()
            : base("name=SpedycjaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AreaActivity> AreaActivities { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Load> Loads { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<StatusOrder> StatusOrders { get; set; }
        public virtual DbSet<TypesFreight> TypesFreights { get; set; }
        public virtual DbSet<TypesVehicle> TypesVehicles { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<StatusHistory> StatusHistories { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }
        public virtual DbSet<Route> Routes { get; set; }
        public virtual DbSet<StatusHistory1> StatusHistory1 { get; set; }
    }
}
