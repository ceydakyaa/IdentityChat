using IdentityChat.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityChat.Context
{
    public class MailContext : IdentityDbContext<AppUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-74EQVQD\\SQLEXPRESS;initial Catalog=IdeChatDb;integrated Security=true;trust server certificate=true");
        }
        public DbSet<Message> Messages { get; set; }
    }
}
