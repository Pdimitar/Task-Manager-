using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace DataRepository
{
    public class AdminRepository
    {
        private TaskManagerDbContext _context;

        public AdminRepository(TaskManagerDbContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public string GetRole(string currentUserName)
        {
            var currentUser = _context.Users.Single(ac => ac.UserName == currentUserName);
            var isAdmin = currentUser.Roles.Any(r => r.UserId == currentUser.Id && r.RoleId == "1");

            if (isAdmin)
            {
                return "admin";
            }

            else
            {
                return "user";

            }


        }


        public IEnumerable<ProjectWithTasksViewModel> GetAllProjects()
        {

            IEnumerable<Project> projetc = _context.Projects;
            IEnumerable<IdentityUser> Users = _context.Users;
            IEnumerable<Tasks> task = _context.Tasks;
            var projectTasks = from p in projetc

                               select new ProjectWithTasksViewModel
                               {
                                   ProjectName = p.ProjectName,
                                   Description = p.Description,
                                   StartDate = p.StartDate,
                                   EndDate = p.EndDate,
                                   Tasks = task.Where(t => t.ProjectId == p.Id).ToList()
                               };

            return projectTasks.ToList();
        }

      

        public IEnumerable<IdentityUser> UnappruvedUsers()
        {
            return _context.Users.ToList();
        }

        public IdentityUser ActivateUsers(string userId)
        {
            var editUser = _context.Users.Single(ua => ua.Id == userId);
            editUser.LockoutEnabled = false;
            _context.Entry(editUser).State = EntityState.Modified;
            _context.SaveChanges();

            return _context.Users.Single(ua => ua.Id == userId);

        }


        public string UnApprovedUser(string currentUserName)
        {
            return _context.Users.Single(ua => ua.UserName == currentUserName).LockoutEnabled.ToString();

        }

        public IdentityUser UserToSendSMS(string userId)
        {
            return _context.Users.Single(ua => ua.Id == userId);

        }

        public void DeactivateUser(string userId)
        {
            var editUser = _context.Users.Single(ua => ua.Id == userId);
            editUser.LockoutEnabled = true;
            _context.Entry(editUser).State = EntityState.Modified;
            _context.SaveChanges();
        }

    }
}

