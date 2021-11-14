using AutoMapper;
using DAL;
using DAL.Model;
using ExpenceDB.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ExpenceDB.Controllers
{
    [RoutePrefix("api/User")]
    public class AccountController : ApiController
    {
        public readonly ExpanceDBModel expanceDBEntities = new ExpanceDBModel();

    [HttpGet]
    [Route("GetUser")]
    public List<tbl_Users> getAllUser()
    {

      using (expanceDBEntities)
      {
        return expanceDBEntities.tbl_User.ToList();
      }

    }

    //[HttpGet]
    //[Route("GetUser/{userId}")]
    //public List<tbl_User> getUserById(string userId)
    //{
    //    List<tbl_User>objtbl_user = new List<tbl_User>();
    //    using (expanceDBEntities)
    //    {
    //        objtbl_user = expanceDBEntities.tbl_User.Where(u => u.userId == userId).ToList();
    //       // var pass = objtbl_user.password;
    //    }
    //    return objtbl_user;

    //}

    [HttpPost,Route("login")]
        public IHttpActionResult userLogin(Login user)
        {
            using (expanceDBEntities)
            {
                var pass = expanceDBEntities.tbl_User.Where(u => ( u.UserPassword == user.password && u.UserEmail == user.loginID || u.UserID == user.loginID)).FirstOrDefault();
                if(pass!=null)
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    var tokeOptions = new JwtSecurityToken(
                        //issuer: "http://localhost:64376",
                        issuer:" http://192.168.0.5:6012/",
                        audience: "http://localhost:4200",
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(5),
                        signingCredentials: signinCredentials
                    );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                    return Ok(new { Token = tokenString });
                }
                else
                {
                    return Unauthorized();
                   // return BadRequest("Invalid client request");
                }
                    
            }
                
        }



    [HttpPost]
    [Route("InsertUser")]
    public async Task<IHttpActionResult> postUser(tbl_UsersDTO user)
    {
      try
      {
        var config = new MapperConfiguration(cfg => { cfg.CreateMap<tbl_Users, tbl_UsersDTO>(); });
        IMapper iMapper = config.CreateMapper();
        var source = new tbl_Users();
        source.UserName = user.UserName;
        source.UserEmail = user.UserEmail;
        source.UserPassword = user.UserPassword;
        source.FullName = user.FullName;
        source.UserID = user.UserID;
        var destination = iMapper.Map<tbl_Users, tbl_UsersDTO>(source);
        using (expanceDBEntities)
        {
          expanceDBEntities.tbl_User.Add(source);
          await expanceDBEntities.SaveChangesAsync();
        }

      }
      catch (Exception ex)
      {

      }

      return Ok(user);
    }

    [NonAction]
    protected void EmailSending()
    {
      string emailSender = ConfigurationManager.AppSettings["emailsender"].ToString();
    }
  }
}
