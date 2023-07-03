using BugTracker.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace BugTracker.Infrastructure.Repository
{
    public class BugRepository : BaseRepository
    {
        public BugRepository(BugTrackerDbContext context) : base(context) { }
    }
}
