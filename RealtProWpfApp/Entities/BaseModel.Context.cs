﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RealtProWpfApp.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RealtProEntities : DbContext
    {
        public RealtProEntities()
            : base("name=RealtProEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AdditionalImageOfApartment> AdditionalImageOfApartments { get; set; }
        public virtual DbSet<AdditionalImageOfHouse> AdditionalImageOfHouses { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<AdOwner> AdOwners { get; set; }
        public virtual DbSet<Apartment> Apartments { get; set; }
        public virtual DbSet<AuthHistory> AuthHistories { get; set; }
        public virtual DbSet<Bathroom> Bathrooms { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Developer> Developers { get; set; }
        public virtual DbSet<GasSupply> GasSupplies { get; set; }
        public virtual DbSet<HeadOfSalesDepartment> HeadOfSalesDepartments { get; set; }
        public virtual DbSet<Heating> Heatings { get; set; }
        public virtual DbSet<House> Houses { get; set; }
        public virtual DbSet<Layout> Layouts { get; set; }
        public virtual DbSet<Market> Markets { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<ObjectStatu> ObjectStatus { get; set; }
        public virtual DbSet<Realtor> Realtors { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Sewerage> Sewerages { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WaterSupply> WaterSupplies { get; set; }
        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<Money> Moneys { get; set; }
        public virtual DbSet<Office> Offices { get; set; }
        public virtual DbSet<Balcony> Balconies { get; set; }
        public virtual DbSet<Activate> Activates { get; set; }
    }
}
