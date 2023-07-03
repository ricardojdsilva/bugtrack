using BugTracker.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BugTracker.Infrastructure.Repository
{
    public class CategoryRepository : BaseRepository
    {
        public CategoryRepository(BugTrackerDbContext context) : base(context) { }
    }
}
