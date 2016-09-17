using Microsoft.AspNet.Identity.EntityFramework;
using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace DataRepository
{
    public class TaskRepository
    {
        private TaskManagerDbContext _context;

        public TaskRepository(TaskManagerDbContext context)
        {
            _context = context;
        }



        public void Dispose()
        {
            _context.Dispose();
        }

        public void AddPoject(Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();
        }

        public IEnumerable<Project> GetProjecst()
        {
            return _context.Projects.ToList();
        }

        public IEnumerable<Tasks> GetAllTasks(int projectId)
        {
            return _context.Tasks.Where(ta => ta.ProjectId == projectId);
        }

        public void AddTask(Tasks tasks)
        {
            _context.Tasks.Add(tasks);
            _context.SaveChanges();
        }

        public void EditTask(Tasks tasks)
        {
            _context.Entry(tasks).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeletTask(int taskId)
        {
            Tasks task = _context.Tasks.Single(c => c.Id == taskId);
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }

        public void DeleteProject(int projectId)
        {
            Project project = _context.Projects.Single(p => p.Id == projectId);
            _context.Projects.Remove(project);
            _context.SaveChanges();
        }

        public IdentityUser GetUser(string currentUserName)
        {
            var user = _context.Users.Single(ac => ac.UserName == currentUserName);

            return _context.Users.Single(us => us.Id == user.Id);
        }

        public IEnumerable<Tasks> GetAllTasks(string currentUserName)
        {
            var user = _context.Users.Single(ac => ac.UserName == currentUserName);

            return _context.Tasks.Where(ta => ta.UserId == user.Id);
        }

        public IEnumerable<Client> GetCurrentUsser(string currentUserName)
        {
            var user = _context.Users.Single(ac => ac.UserName == currentUserName);

            return _context.Clients.Where(u => u.Id == user.Id).ToList();
        }

    }
}
