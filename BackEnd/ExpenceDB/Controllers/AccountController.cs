using ExpenceDB.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
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
        public readonly ExpanceDBEntities expanceDBEntities = new ExpanceDBEntities();

        [HttpGet]
        [Route("GetUser")]
        public List<tbl_User> getAllUser()
        {
            
                using (expanceDBEntities)
                {
                   return expanceDBEntities.tbl_User.ToList();
                }
            
        }

        [HttpGet]
        [Route("GetUser/{userId}")]
        public List<tbl_User> getUserById(string userId)
        {
            List<tbl_User>objtbl_user = new List<tbl_User>();
            using (expanceDBEntities)
            {
                objtbl_user = expanceDBEntities.tbl_User.Where(u => u.userId == userId).ToList();
               // var pass = objtbl_user.password;
            }
            return objtbl_user;
            
        }

        [HttpPost,Route("login")]
        public IHttpActionResult userLogin(Login user)
        {
            using (expanceDBEntities)
            {
                var pass = expanceDBEntities.tbl_User.Where(u => u.userId == user.email && u.password == user.password).FirstOrDefault();
                if(pass!=null)
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    var tokeOptions = new JwtSecurityToken(
                        issuer: "http://localhost:64376",
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
        public async Task<IHttpActionResult> postUser(tbl_User user)
        {
            try
            {
                using (expanceDBEntities)
                {
                    expanceDBEntities.tbl_User.Add(user);
                    await expanceDBEntities.SaveChangesAsync();
                }
                    
            }
            catch(Exception ex)
            {

            }

            return Ok(user);
        }
    }
}
