using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class ApprovedUser
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public bool IsApporoved { get; set; }
    }
}
