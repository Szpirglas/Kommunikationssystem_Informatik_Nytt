﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dal
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<BlogEntries> BlogEntries { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Category_Blog> Category_Blog { get; set; }
        public virtual DbSet<Feed_Section> Feed_Section { get; set; }
        public virtual DbSet<File> File { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<Meeting> Meeting { get; set; }
        public virtual DbSet<Notificationer> Notificationer { get; set; }
        public virtual DbSet<User_Private_Meeting> User_Private_Meeting { get; set; }
    }
}
