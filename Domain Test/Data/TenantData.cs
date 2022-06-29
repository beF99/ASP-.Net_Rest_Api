using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Test.Data
{
    public class TenantData
    {
        public int TenantId { get; set; }
        public string TenantName { get; set; }
        public string TenantEmail { get; set; }
        public string TenantPhone { get; set; }
        public DateTime TenantCreationDate { get; set; }
    }
}
