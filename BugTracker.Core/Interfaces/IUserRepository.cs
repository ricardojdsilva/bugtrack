using BugTracker.Core.Entities;
using System;
using System.Collections.Generic;

namespace BugTracker.Core.Interfaces
{
    public interface IUserRepository
    {
        User Login(string username, string password);
    }
}
