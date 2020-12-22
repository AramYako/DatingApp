using DatingAppApi.Data;
using DatingAppApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _dbCtx;
        public UsersController(DataContext dbCtx)
        {
            this._dbCtx = dbCtx;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await _dbCtx.Users.ToListAsync();

            return users;
        }

        [HttpGet("{int: id})")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            var users = await _dbCtx.Users.FirstOrDefaultAsync(u=>u.Id == id);

            return users;
        }
    }
}
