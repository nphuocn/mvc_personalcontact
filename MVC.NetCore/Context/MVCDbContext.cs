using Microsoft.EntityFrameworkCore;
using MVC.NetCore.Models;

namespace MVC.NetCore.Context
{
    public class MVCDbContext : DbContext
    {
        public MVCDbContext(DbContextOptions<MVCDbContext> options) : base(options)
        {
        }

        public DbSet<PersonalContactModel> PersonalContacts { get; set; }
    }
}
