using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TaskState TaskStates { get; set; }
        public int ProjectId { get; set; }
        public string UserId { get; set; }
    }
    public enum TaskState
    {
        ToDo = 0,
        InProgres = 1,
        Testing = 2,
        Complited = 3
    }

}
