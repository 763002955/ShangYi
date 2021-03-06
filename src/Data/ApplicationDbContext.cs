﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShangYi.Models;

namespace ShangYi.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

		public DbSet<BlobModel> BlobModel { set; get; }

		public DbSet<PhoneNumberModel> PhoneNumber { get; set; }

        public DbSet<CarPoolingModel> CarPooling { get; set; }

        public DbSet<HiringModel> HiringModel { get; set; }

        public DbSet<NotificationModel> NotificationModel { get; set; }

        public DbSet<DocumentModel> DocumentModel { get; set; }

		public DbSet<CategoryModel> CategoryModel { get; set; }

	}
}
