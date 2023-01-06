using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Data;
using WebAPI.Lib;
using WebAPI.Models;
using WebAPI.Filter;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Login] // this will call Login Filter, you can also use in fron of api instead of controller
    public class CompetitionController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCompetition()
        {
            using(var db = new AppDb())
            {
                string sql = "select * from vd_Competition";
                List<vdCompetition> data = db.Connection.Query<vdCompetition>(sql).ToList();
                return Ok(data);
            }
        }

        [Login]
        [HttpPost]
        public IActionResult AddCompetition([FromBody] CompetitionModel payload)
        {
            using (var db = new AppDb())
            {
                string sql = "xp_CompetitionInsert";
                int UID = (int)(HttpContext.Items["UID"] ?? 0);
                DynamicParameters p = new DynamicParameters();
                p.Add("@CCID", payload.CCID);
                p.Add("@Name", payload.Name);
                p.Add("@Des", payload.Description);
                p.Add("@Organizer", UID);
                p.Add("@NewCID", payload.NewCID, direction: ParameterDirection.Output);
                db.Connection.Execute(sql, p, commandType: CommandType.StoredProcedure);
            }
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateCompetition([FromBody] CompetitionModel payload)
        {
            using (var db = new AppDb())
            {
                string sql = "xp_CompetitionUpdate";
                int UID = (int)(HttpContext.Items["UID"] ?? 0);
                DynamicParameters p = new DynamicParameters();

                p.Add("@CID", payload.NewCID);
                p.Add("@CCID", payload.CCID);
                p.Add("@Organizer", UID);
                p.Add("@Name", payload.Name);
                p.Add("@Des", payload.Description);

                db.Connection.Execute(sql, p, commandType: CommandType.StoredProcedure);
            }
            return Ok();
        }

        [HttpDelete("{CID}")]
        public IActionResult DeleteCompetition(int CID)
        {
            using (var db = new AppDb())
            {
                string sql = "xp_CompetitionDelete";
                DynamicParameters p = new DynamicParameters();
                p.Add("@CID", CID);
                db.Connection.Execute(sql, p);
            }
            return Ok();
        }
    }
}
