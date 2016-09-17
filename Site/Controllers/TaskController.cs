using DataProvider;
using DataRepository;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ViewModels;

namespace Site.Controllers
{
    [RoutePrefix("api/task")]
    [Authorize]
    public class TaskController : ApiController
    {
        private TaskProvider _provider;

        public TaskController()
        {
            var context = new TaskManagerDbContext();
            var repository = new TaskRepository(context);
            var provider = new TaskProvider(repository);

            _provider = provider;
        }
       
        [Route("addProject")]
        [HttpPost]
        public void AddPoject(ProjectViewModel projectModel)
        {
            _provider.AddPoject(projectModel);
        }

        [Route("getProjects")]
        [HttpGet]
        public IEnumerable<Project> GetProjecst()
        {
           return _provider.GetProjecst();
        }
            
        [Route("getTasks/{projectId}")]
        [HttpGet]
        public IEnumerable<Tasks> GetAllTasks(int projectId)
        {
            return _provider.GetAllTasks(projectId);
        }

        [Route("addTask")]
        [HttpPost]
        public void AddTask(Tasks tasks)
        {
            _provider.AddTask(tasks);
        }

        [Route("editTask")]
        [HttpPut]
        public void EditTask(Tasks tasks)
        {
            _provider.EditTask(tasks);
        }

        [Route("deleteTask/{taskId}")]
        [HttpDelete]
        public void DeletTask(int taskId)
        {
             _provider.DeletTask(taskId);
        }

        [Route("deleteproject/{projectId}")]
        [HttpDelete]
        public void DeleteProject(int projectId)
        {
            _provider.DeleteProject(projectId);
        }

        [Route("getUserId")]
        [HttpGet]
        public IdentityUser GetUser()
        {
            string currentUserName = User.Identity.Name;
            return _provider.GetUser(currentUserName);
        }

        [Route("getAllTasks")]
        [HttpGet]
        public IEnumerable<Tasks> GetAllTasks()
        {
            string currentUserName = User.Identity.Name;
            return _provider.GetAllTasks(currentUserName);
        }

        [Route("getUsserRole")]
        [HttpGet]
        public IEnumerable<Client> GetCurrentUsser()
        {
            string currentUserName = User.Identity.Name;
            return _provider.GetCurrentUsser(currentUserName);
        }


    }
}