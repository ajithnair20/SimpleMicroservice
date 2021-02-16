using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Database.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public String Contact { get; set; }
    }
}
