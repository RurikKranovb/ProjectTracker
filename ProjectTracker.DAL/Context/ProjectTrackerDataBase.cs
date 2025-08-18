using Microsoft.EntityFrameworkCore;
using ProjectTracker.Domain.Entities;

namespace ProjectTracker.DAL.Context
{
    public class ProjectTrackerDataBase : DbContext/*IdentityDbContext<ApplicationUser>*/
    {

        public DbSet<Project> Projects => Set<Project>();
        public DbSet<ProjectTask> Tasks => Set<ProjectTask>();

        public ProjectTrackerDataBase(DbContextOptions<ProjectTrackerDataBase> options) : base(options) { }


        //public DbSet<ProjectMember> ProjectMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<ProjectMember>()
            //    .HasKey(p => new
            //    {
            //        p.ProjectId,
            //        p.UserId
            //    });
        }
    }
}
