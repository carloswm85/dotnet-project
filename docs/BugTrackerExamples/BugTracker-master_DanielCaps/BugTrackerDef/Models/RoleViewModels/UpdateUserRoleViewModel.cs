using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackerDef.Models.RoleViewModels
{
    public class UpdateUserRoleViewModel
    {
        public IEnumerable<UsersViewModel> Users { get; set; }
        public IEnumerable<string> Roles { get; set; }

        public string UserEmail { get; set; }
        public string Role { get; set; }
        public bool Delete { get; set; }
    }
}
