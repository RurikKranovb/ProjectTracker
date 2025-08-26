using Microsoft.EntityFrameworkCore;
using ProjectTracker.DAL.Context;

namespace ProjectTracker.Infrastructure.Services
{
    public class IdService
    {

        private readonly ProjectTrackerDataBase _db;
        public IdService(ProjectTrackerDataBase db)
        {
            _db = db;
        }

        public async Task<int> GetNextProjectIdAsync(ProjectTrackerDataBase dataBase)
        {
            var usedIds = await dataBase.Projects
                .OrderBy(p => p.Id)
                .Select(p => p.Id)
                .ToListAsync();

            int expectedId = 1;

            foreach (var usedId in usedIds)
            {
                if (usedId > expectedId)
                {
                    return expectedId;
                }
                expectedId++;
            }
            return expectedId;
        }
    }
}
