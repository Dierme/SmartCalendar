﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SmartCalendar.Models.Abstracts;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SmartCalendar.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public virtual List<Event> Events { get; set; }

    }

    public class Event
    {
        [Key]
        [HiddenInput(DisplayValue = false)] 
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateAdd { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateStart { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateEnd { get; set; }

        public string Location { get; set; }

        [Required]
        public Category Category { get; set; }
        
        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }

    public enum Category { Home, Business, Study, Fun }


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IStoreAppContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Event> Events { get; set; }

        public void MarkAsModified(Event item)
        {
            Entry(item).State = EntityState.Modified;
        }
    }
}