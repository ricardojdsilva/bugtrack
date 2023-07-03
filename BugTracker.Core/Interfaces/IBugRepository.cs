using BugTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace BugTracker.Core.Interfaces
{
    public interface IBugRepository
    {
        Task<ICollection<Bug>> GetAsync();
    }
}
