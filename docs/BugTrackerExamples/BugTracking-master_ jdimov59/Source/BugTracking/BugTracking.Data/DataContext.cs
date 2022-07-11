using BugTracking.Models;
using System.Data.Entity;

namespace BugTracking.Data
{
    public class DataContext :DbContext
    {
        public IDbSet<Bug> Bugs { get; set; }
    }
}
