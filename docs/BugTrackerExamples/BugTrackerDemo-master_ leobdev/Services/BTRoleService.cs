﻿using BugTrackerDemo.Data;
using BugTrackerDemo.Models;
using BugTrackerDemo.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BugTrackerDemo.Services
{
    public class BTRoleService : IBTRolesService
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<BTUser> _userManager;

        public BTRoleService(ApplicationDbContext context,
            RoleManager<IdentityRole> roleManager,
            UserManager<BTUser> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<bool> AddUserRoleAsync(BTUser user, string roleName)
        {
            bool result = (await _userManager.AddToRoleAsync(user, roleName)).Succeeded;

            return result;
        }

        public async Task<List<IdentityRole>> GetRolesAsync()
        {

            try
            {
                List<IdentityRole> result = new List<IdentityRole>();

                result = await _context.Roles.ToListAsync();

                return result;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> GetRoleNameByIdAsync(string roleId)
        {
            IdentityRole role = _context.Roles.Find(roleId);

            string result = await _roleManager.GetRoleNameAsync(role);

            return result;
        }

        public async Task<IEnumerable<string>> GetUserRolesAsync(BTUser user)
        {
            IEnumerable<string> result = await _userManager.GetRolesAsync(user);

            return result;
        }

        public async Task<List<BTUser>> GetUsersInRoleAsync(string roleName, int companyId)
        {
            List<BTUser> users = (await _userManager.GetUsersInRoleAsync(roleName)).ToList();

            List<BTUser> result = users.Where(x => x.CompanyId == companyId).ToList();

            return result;
        }

        public async Task<List<BTUser>> GetUsersNotInRoleAsync(string roleName, int companyId)
        {
            List<string> userIds = (await _userManager.GetUsersInRoleAsync(roleName)).Select(x => x.Id).ToList();

            List<BTUser> roleUsers = _context.Users.Where(x => !userIds.Contains(x.Id)).ToList();

            List<BTUser> result = roleUsers.Where(x => x.CompanyId == companyId).ToList();

            return result;
        }

        public async Task<bool> IsUserInRoleAsync(BTUser user, string roleName)
        {
            bool result = await _userManager.IsInRoleAsync(user, roleName);

            return result;
        }

        public async Task<bool> RemoveUserFromroleAsync(BTUser user, string roleName)
        {
            bool result = (await _userManager.RemoveFromRoleAsync(user, roleName)).Succeeded;

            return result;
        }

        public async Task<bool> RemoveUserFromRolesAsync(BTUser user, IEnumerable<string> roles)
        {
            bool result = (await _userManager.RemoveFromRolesAsync(user, roles)).Succeeded;

            return result;
        }
    }
}
