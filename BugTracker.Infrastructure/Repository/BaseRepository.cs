using BugTracker.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugTracker.Infrastructure.Repository
{
    public abstract class BaseRepository
    {
        protected readonly BugTrackerDbContext _context;

        public BaseRepository(BugTrackerDbContext context)
        {
            _context = context;
        }
    }
}
