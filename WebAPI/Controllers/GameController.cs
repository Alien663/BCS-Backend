using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebAPI.Lib;
using WebAPI.Models;
using WebAPI.Filter;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Login] // this will call Login Filter, you can also use in fron of api instead of controller
    public class GameController : ControllerBase
    {
        [HttpGet("{GID}")]
        public IActionResult GetGameData(int GID)
        {
            using(var db = new AppDb())
            {
                string sql = "select * from vd_GamePlayer where GID = @GID";
                var data = db.Connection.Query(sql, new { GID }).ToList();
                return Ok(data);
            }
        }

        [HttpPost]
        public IActionResult AddGame([FromBody] TTModel payload)
        {
            using (var db = new AppDb())
            {
                string sql = "xp_GameInsert";
                DynamicParameters p = new DynamicParameters();
                p.Add("@TID", payload.TID);
                p.Add("@TName", payload.TName);
                p.Add("@TDes", payload.TDes);
                db.Connection.Execute(sql, p, commandType: CommandType.StoredProcedure);
            }
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateGame([FromBody] TTModel payload)
        {
            using (var db = new AppDb())
            {
                string sql = "xp_GameUpdate";
                DynamicParameters p = new DynamicParameters();
                p.Add("@TID", payload.TID, direction: ParameterDirection.Output);
                p.Add("@TName", payload.TName);
                p.Add("@TDes", payload.TDes);
                db.Connection.Execute(sql, p, commandType: CommandType.StoredProcedure);
            }
            return Ok(new { payload.TID });
        }

        [HttpDelete("{GID}")]
        public IActionResult DeleteGame(int GID)
        {
            using (var db = new AppDb())
            {
                string sql = "xp_GameDelete";
                DynamicParameters p = new DynamicParameters();
                p.Add("@GID", GID);
                db.Connection.Execute(sql, p);
            }
            return Ok();
        }
    }
}
