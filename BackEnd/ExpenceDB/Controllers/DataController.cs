using DAL;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ExpenceDB.Controllers
{
  [RoutePrefix("api/Expance")]
  public class DataController : ApiController
    {
      public readonly ExpanceDBModel expanceDBEntities = new ExpanceDBModel();

    [HttpGet]
    [Route("GetAllExpanceData")]
    public List<tbl_ExpanceData> GetAllExpanceData()
    {

      using (expanceDBEntities)
      {
        return expanceDBEntities.tbl_ExpanceDatas.ToList();
      }

    }

    [HttpPost]
    [Route("InsertExpance")]
    public async Task<IHttpActionResult> postExpanceData(tbl_ExpanceData tbl_ExpanceDatas)
      {
      using (expanceDBEntities)
      {
        try
        {
          expanceDBEntities.tbl_ExpanceDatas.Add(tbl_ExpanceDatas);
          await expanceDBEntities.SaveChangesAsync();
        }
        catch(Exception ex)
        {

        }
       
      }
        return Ok(tbl_ExpanceDatas);
      }
      
    }
}
