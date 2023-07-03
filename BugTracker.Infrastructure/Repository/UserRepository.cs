using BugTracker.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugTracker.Infrastructure.Repository
{
    public class UserRepository : BaseRepository
    {
        public UserRepository(BugTrackerDbContext context) : base(context) { }
    }
}
