using Domain_Test.Data;
using Domain_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Test.Service
{
    public class UserService
    {
        TUserDBContext dbb = new TUserDBContext();

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public List<UserData> UsersByTenant()
        {
            try
            {
                var u = dbb.UserTables.OrderBy(x => x.TenantId).Select(u => new UserData
                {
                    UserId = u.UserId,
                    UserFirstName = u.FirstName,
                    UserLastName = u.LastName,
                    UserPhone= u.Phone, 
                    UserEmail = u.Emaill,
                    UserCreationDate = (DateTime)u.CreationDate,
                    TenantName = u.Tenant.TenantName

                }).ToList();
                return u;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);

                return null;
            }

        }

        
    }
}
