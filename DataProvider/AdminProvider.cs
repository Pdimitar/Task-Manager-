using DataRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Microsoft.AspNet.Identity.EntityFramework;
using ViewModels;
using Plivo.API;
using RestSharp;

namespace DataProvider
{
    public class AdminProvider
    {
        private AdminRepository _repo;

        public AdminProvider(AdminRepository repo)
        {
            _repo = repo;
        }

        public string GetRole(string currentUserName)
        {
            return _repo.GetRole(currentUserName);
        }

        public IEnumerable<ProjectWithTasksViewModel> GetAllProjects()
        {
            return _repo.GetAllProjects();

        }

        public IEnumerable<IdentityUser> UnappruvedUsers()
        {
            return _repo.UnappruvedUsers();
        }

        public void ActivateUsers(string userId)
        {
           var  currentUser = _repo.ActivateUsers(userId);


            RestAPI plivo = new RestAPI("MAZGEYYMQYMWUYMJEWMM", "YWY1NDJiMjE3MGVlN2QwMDdiODM2YWIxZjdkMjdi");

            IRestResponse<MessageResponse> resp = plivo.send_message(new Dictionary<string, string>()
            {  { "src", "TaskManager" }, // Sender's phone number with country code
                { "dst", currentUser.PhoneNumber }, // Receiver's phone number wiht country code
                { "text", "Task Manager" }, // Your SMS text message
                // To send Unicode text
                // {"text", "こんにちは、元気ですか？"} // Your SMS text message - Japanese
                // {"text", "Ce est texte généré aléatoirement"} // Your SMS text message - French
                { "url", "http://example.com/report/"}, // The URL to which with the status of the message is sent
                { "method", "POST"} // Method to invoke the url
            });

        }

        public string UnApprovedUser(string currentUserName)
        {
            return _repo.UnApprovedUser(currentUserName);
        }

        public void DeactivateUser(string userId)
        {
             _repo.DeactivateUser(userId);
        }
    }
}
