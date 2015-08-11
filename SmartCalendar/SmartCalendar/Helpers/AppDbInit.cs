using SmartCalendar.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SmartCalendar.Helpers
{
    public class AppDbInit :DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var testEvent = new Event()
            {
                Id = "1",
                DateAdd = DateTime.Now,
                DateEnd = DateTime.Now.AddDays(3),
                DateStart = DateTime.Now,
                Category = Category.Fun,
                Description = "test",
                Location = "test",
                Title = "test",
                UserId = "e7525ab1-56cd-4488-8e6f-7b83d06071e1"
            };
            var testEvent2 = new Event()
            {
                Id = "2",
                DateAdd = DateTime.Now,
                DateEnd = DateTime.Now.AddMonths(1).AddDays(3),
                DateStart = DateTime.Now.AddMonths(1),
                Category = Category.Fun,
                Description = "test",
                Location = "test",
                Title = "test",
                UserId = "e7525ab1-56cd-4488-8e6f-7b83d06071e1"
            };
            context.Events.Add(testEvent);
            context.Events.Add(testEvent2);
            base.Seed(context);
        }
        public AppDbInit() { this.Seed(ApplicationDbContext.Create()); }

    }
}