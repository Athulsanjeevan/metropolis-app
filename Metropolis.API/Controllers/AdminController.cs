using Metropolis.BLL;
using Metropolis.DAL;
using Metropolis.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Metropolis.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminBll _AdminBLL;
        private readonly IActivityBll _ActivityBLL;
        private readonly ApplicationDbContext _db;
        readonly ITokenService _tokenService;
        public AdminController(IAdminBll AdminBLL, IActivityBll ActivityBLL, ApplicationDbContext db, ITokenService tokenService)
        { 
            _AdminBLL = AdminBLL;
            _ActivityBLL = ActivityBLL;
            _db = db;
            _tokenService = tokenService;
        }
        [HttpGet]
        [Authorize]
        public List<Activity> GetAll()
        {
            return _ActivityBLL.GetActivitiesForTheDay();
        }
        
        [HttpPost]
        public IActionResult UserAuth(Admin user)
        {
            var user_exist = _db.Admins.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
            if (user_exist!=null)
            {
                var accessToken = _tokenService.GenerateAccessToken();
                var refreshToken = _tokenService.GenerateRefreshToken();
                user_exist.RefreshToken = refreshToken;
                user_exist.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
                _db.SaveChanges();
                return Ok(new
                {
                    Token = accessToken,
                    RefreshToken = refreshToken
                });

            }
            else
            {
                return Unauthorized();
            }

         }

    }
}
