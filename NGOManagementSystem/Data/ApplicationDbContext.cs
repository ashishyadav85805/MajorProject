using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NGOManagementSystem.Models;

namespace NGOManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {


        public DbSet<NGOManagementSystem.Models.Category> Category { get; set; }




        public DbSet<NGOManagementSystem.Models.DonorInfo> DonorInfo { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<NGOManagementSystem.Models.DonorDetail> DonorDetail { get; set; }

        public DbSet<NGOManagementSystem.Models.Payment> Payment { get; set; }




       


    }

}