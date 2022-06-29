using System;
using System.Collections.Generic;

namespace Domain_Test.Models
{
    public partial class UserTable
    {
        public int UserId { get; set; }
        public int? TenantId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Emaill { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual TenantTable? Tenant { get; set; }
    }
}
