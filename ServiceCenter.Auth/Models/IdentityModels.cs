using System;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ServiceCenter.Auth.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public sealed class ApplicationUser : IdentityUser<Guid, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid();     
        }

       
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public ApplicationDbContext()
            : base("name=ApplicationDbContext")
        {
            
        }

        public virtual DbSet<Order> Orders { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

    public class ApplicationUserRole : IdentityUserRole<Guid>
    {
    }

    public class ApplicationUserLogin : IdentityUserLogin<Guid>
    {
    }

    public class ApplicationUserClaim : IdentityUserClaim<Guid>
    {
    }

    public class ApplicationRole : IdentityRole<Guid, ApplicationUserRole>
    {
    }
    public class ApplicatonUserStore :
  UserStore<ApplicationUser, ApplicationRole, Guid, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public ApplicatonUserStore(ApplicationDbContext context)
         : base(context)
        {
        }
    }
}