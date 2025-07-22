using EnqueryFormSubmit.Models;
using Microsoft.EntityFrameworkCore;

namespace EnqueryFormSubmit.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Enquiry> Enquiries { get; set; }
    }
}
