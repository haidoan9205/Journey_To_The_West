using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly jwwtContext _context;


        public AuthRepository(jwwtContext context)
        {
            _context = context;

        }


        public async Task<User> Login(string userId, string password)
        {
            var user = await _context.User.FirstOrDefaultAsync(x =>
                x.UserId == userId);

            if (user.Password == password)
                return user;

            return null;
        }









        //}
    }
}
