using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class ToDoContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-8MUCCB4;Database=ToDo;Trusted_Connection=true");
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Taskk> Tasks { get; set; }
    }
}
