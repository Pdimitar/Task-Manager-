using DataProvider;
using DataRepository;
using Microsoft.AspNet.Identity.EntityFramework;
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
    [RoutePrefix("api/admin")]
    [Authorize]
    public class AdminController : ApiController
    {
        private AdminProvider _provider;

        public AdminController()
        {
            var context = new TaskManagerDbContext();
            var repository = new AdminRepository(context);
            var provider = new AdminProvider(repository);

            _provider = provider;
        }

        [Route("getRole")]
        [HttpGet]
        public string GetRole()
        {
            string currentUserName = User.Identity.Name;
            return _provider.GetRole(currentUserName);
        }

        [Route("getAllProjects")]
        [HttpGet]
        public IEnumerable<ProjectWithTasksViewModel> GetAllProjects()
        {
            return _provider.GetAllProjects();
        }

        [Route("getUnAppruvetUsers")]
        [HttpGet]
        public IEnumerable<IdentityUser> UnappruvedUsers()
        {
            return _provider.UnappruvedUsers();
        }

        [Route("activateUser/{userId}")]
        [HttpPut]
        public void ActivateUsers(string userId)
        {
            _provider.ActivateUsers(userId);
        }

        [Route("UnApprovedUser")]
        [HttpGet]
        public string UnApprovedUser()
        {
            string currentUserName = User.Identity.Name;

            return _provider.UnApprovedUser(currentUserName);
        }

        [Route("deactivateUser/{userId}")]
        [HttpPut]
        public void DeactivateUser(string userId)
        {

             _provider.DeactivateUser(userId);
        }


    }
    
}
