using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SCCBakery.Models
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
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Invoice> AnInvoice { get; set; }
        public DbSet<Order> AnOrder { get; set; }
        public DbSet<Product> AProduct { get; set;}
        public DbSet<CustomerInfo> ACustomer { get; set; }
        public DbSet<CartItem> ACartItem { get; set; }
        public DbSet<Cart> ACart { get; set; }

        public ApplicationDbContext()
            : base("SCCBakery1", throwIfV1Schema: false)
        //: base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

       // public System.Data.Entity.DbSet<SCCBakery.Models.CartItem> CartItems { get; set; }
    }
}