using Microsoft.EntityFrameworkCore;
using ProjectTracker.DAL.Context;

namespace ProjectTracker.Data
{
    public class ProjectTrackerDbInitializer
    {
        private readonly ProjectTrackerDataBase _db;

        public ProjectTrackerDbInitializer(ProjectTrackerDataBase db) => _db = db;

        public void Initialize() => InitializeAsync().Wait();

        private async Task InitializeAsync()
        {
            var db  = _db.Database;

            await db.MigrateAsync().ConfigureAwait(false);

            if (await _db.Projects.AnyAsync())
                return;

          await  using (var transaction = await db.BeginTransactionAsync().ConfigureAwait(false))
            {
                await _db.Projects.AddRangeAsync(TestData.Projects).ConfigureAwait(false);

                await db.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Projects] ON");

                await _db.SaveChangesAsync().ConfigureAwait(false);

                await db.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Projects] OFF");

                await transaction.CommitAsync().ConfigureAwait(false);
            }

            await using (var transaction = await db.BeginTransactionAsync().ConfigureAwait(false))
            {
                await _db.Tasks.AddRangeAsync(TestData.ProjectTasks).ConfigureAwait(false);

                await db.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Tasks] ON");

                await _db.SaveChangesAsync().ConfigureAwait(false);

                await db.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Tasks] OFF");

                await transaction.CommitAsync().ConfigureAwait(false);
            }
        }
    }
}
