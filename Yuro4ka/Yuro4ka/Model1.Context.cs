﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Yuro4ka
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class bakery_kpEntities : DbContext
    {
        public bakery_kpEntities()
            : base("name=bakery_kpEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<OrderList> OrderList { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductOrders___> ProductOrders___ { get; set; }
        public virtual DbSet<ProductOrderSV> ProductOrderSV { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserDocument> UserDocument { get; set; }
        public virtual DbSet<UserService> UserService { get; set; }
    }
}
