using Domain_Test.Data;
using Domain_Test.Service;
using Microsoft.AspNetCore.Mvc;
using IronXL;
using log4net.Config;
[assembly: XmlConfigurator(Watch = true)]

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test_API.Controllers
{

    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        TenantService TS = new TenantService();
        UserService US = new UserService();


        // GET: api/<ValuesController>
        [HttpGet]
        public void GetAllTanants()
        {
            log.Info(": Starting GetAllTanants");

            try
            {
                List<TenantData> TenantList = TS.AllTanants();//I get the list from the service
                log.Info("GetAllTanants is successfully");

                //export to exel sheet
                WorkBook workbook = WorkBook.Create(ExcelFileFormat.XLSX);
                var sheet = workbook.CreateWorkSheet("example_sheet");
                sheet["A1" ].Value = "TenantId";
                sheet["A1"].Style.Font.Bold = true;
                sheet["B1" ].Value = "TenantName";
                sheet["B1"].Style.Font.Bold = true;
                sheet["C1" ].Value = "Email";
                sheet["C1"].Style.Font.Bold = true;
                sheet["D1" ].Value = "Phone";
                sheet["D1"].Style.Font.Bold = true;
                sheet["E1" ].Value = "CreationDate";
                sheet["E1"].Style.Font.Bold = true;

                for (int i = 0; i < TenantList.Count; i++)
                {
                    sheet["A" + (i + 2)].Value = TenantList[i].TenantId ;
                    sheet["B" + (i + 2)].Value = TenantList[i].TenantName;
                    sheet["C" + (i + 2)].Value = TenantList[i].TenantEmail;
                    sheet["D" + (i + 2)].Value = TenantList[i].TenantPhone;
                    sheet["E" + (i + 2)].Value = TenantList[i].TenantCreationDate;                }
                workbook.SaveAs(".//AllTenant.xlsx");

                log.Info(": export AllTanants to exel sheet is successfully");
            }
            catch (Exception ex)
            {
                log.Error(": GetAllTanants Get Erro: "+ ex.Message);
            }
            finally
            {
                log.Info(": GetAllTanants is finish");
            }
           
        }

        // GET: api/<ValuesController>
        [HttpGet]

        public List<UserData> GetUsersByTenant()
        {
            log.Info(": Starting GetAllTanants");

            try
            {
                List<UserData> users =US.UsersByTenant();//I get the list from the service
                log.Info( ": GetUsersByTenant is successfully");
                return users;
            }
            catch (Exception ex)
            {
                log.Error(": GetUsersByTenant Get Erro: " + ex.Message);
                return null;    
            }
            finally
            {
                log.Info(": GetUsersByTenant is finish");

            }
        }

       




        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
