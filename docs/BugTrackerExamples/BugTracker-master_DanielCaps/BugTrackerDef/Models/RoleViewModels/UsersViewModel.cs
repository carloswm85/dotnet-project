using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackerDef.Models.RoleViewModels
{
    public class UsersViewModel
    {
        public string Email { get; set; }
        public IEnumerable<UsersRole> Roles { get; set; }

    }
}
