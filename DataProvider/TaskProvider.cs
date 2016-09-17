using DataRepository;
using Microsoft.AspNet.Identity.EntityFramework;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace DataProvider
{
    public class TaskProvider
    {
        private TaskRepository _repo;

        public TaskProvider(TaskRepository repo)
        {
            _repo = repo;
        }

        public void AddPoject(ProjectViewModel projectModel)
        {
            Project project = new Project()
            {
                ProjectName = projectModel.ProjectName,
                Description = projectModel.Description,
                StartDate = projectModel.StartDate,
                EndDate = projectModel.EndDate
            };

            _repo.AddPoject(project);
        }

        public IEnumerable<Project> GetProjecst()
        {
            return _repo.GetProjecst();
        }

        public IEnumerable<Tasks> GetAllTasks(int projectId)
        {
            return _repo.GetAllTasks(projectId);
        }

        public void AddTask(Tasks tasks)
        {
            _repo.AddTask(tasks);
        }

        public void EditTask(Tasks tasks)
        {
            _repo.EditTask(tasks);
        }

        public void DeletTask(int taskId)
        {
            _repo.DeletTask(taskId);
        }

        public void DeleteProject(int projectId)
        {
            _repo.DeleteProject(projectId);
        }

        public IdentityUser GetUser(string currentUserName)
        {
            return _repo.GetUser(currentUserName);

        }

        public IEnumerable<Tasks> GetAllTasks(string currentUserName)
        {
            return _repo.GetAllTasks(currentUserName);

        }

        public IEnumerable<Client> GetCurrentUsser(string currentUserName)
        {
            return _repo.GetCurrentUsser(currentUserName);
        }
    }
}
