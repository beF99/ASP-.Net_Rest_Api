using System;
using System.Collections.Generic;

namespace Domain_Test.Models
{
    public partial class TenantTable
    {
        public TenantTable()
        {
            UserTables = new HashSet<UserTable>();
        }

        public int TenantId { get; set; }
        public string? TenantName { get; set; }
        public string? Emaill { get; set; }
        public string? Phone { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual ICollection<UserTable> UserTables { get; set; }
    }
}
