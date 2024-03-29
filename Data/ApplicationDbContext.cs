using Microsoft.EntityFrameworkCore;

namespace QuantumPMTestTask.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<NoteModel> NotesList { get; set; }
    }
}
