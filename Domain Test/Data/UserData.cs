using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Test.Data
{
    public class UserData
    {
        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserPhone { get; set; }
        public string UserEmail { get; set; }

        public DateTime UserCreationDate { get; set; }

        public string TenantName { get; set; }

    }
}
