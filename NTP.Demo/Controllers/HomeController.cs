using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Dapper;

namespace NTP.Demo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public async Task<ActionResult> Index()
        {
            using (var db = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                var serverDateTime = await db.QueryFirstOrDefaultAsync<DateTime>("select getdate()");
                var milliseconds = serverDateTime.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;

                ViewBag.ServerTime = milliseconds ;
            }

            return View();
        }
    }
}