using Domain_Test.Data;
using Domain_Test.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Domain_Test.Service
{
    
    public class TenantService
    {


        TUserDBContext db = new TUserDBContext();

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
      
        public List<TenantData> AllTanants()
        {

            try {
                var t = db.TenantTables.Select(t => new TenantData
                {
                    TenantId = t.TenantId,
                    TenantName = t.TenantName,
                    TenantEmail = t.Emaill,
                    TenantPhone= t.Phone,   
                    TenantCreationDate = (DateTime)t.CreationDate
                }).ToList();
              return t;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return null;
            }


        }


    }
}
