using Microsoft.AspNet.Identity.EntityFramework;
using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace DataRepository
{
    public class TaskManagerDbContext : IdentityDbContext<IdentityUser>
    {
        public TaskManagerDbContext()
            : base("taskManagerDb")
        {

        }
        public DbSet<ApprovedUser> ApprovedUsers { get; set; }
        public DbSet<Client> Clients { get; set; }  
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Models.Tasks> Tasks { get; set; }
    }
}
