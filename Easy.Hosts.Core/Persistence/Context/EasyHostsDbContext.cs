using Easy.Hosts.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;

namespace Easy.Hosts.Core.Persistence.Context
{
    public class EasyHostsDbContext: DbContext
    {
        public EasyHostsDbContext(DbContextOptions<EasyHostsDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //Remove delete cascade
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
        public DbSet<User> User { get; set; }
    }
}
