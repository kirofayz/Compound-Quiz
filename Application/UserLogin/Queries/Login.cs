using Application.common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserLogin.Queries
{
    public record LoginCommand : IRequest<int>
    {
        public required string EmailAddress { get; set; }

        public required string Password { get; set; }

    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, int>
    {
        private readonly IApplicationDbContext context;

        public LoginCommandHandler(IApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<int> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await context.Users.FirstOrDefaultAsync(t => t.Email == request.EmailAddress);
            if (user == null) {
                return -1; // user not exist
            }
            if(VerifyPassword(request.Password,user.Password))
            {
                return user.Id;
            }
            else
            {
                return 0; // password incorrect
            }
         
        }


        private bool VerifyPassword(string enteredPassword, string hashedPassword)
        {
            byte[] hashBytes = Convert.FromBase64String(hashedPassword);

            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    return false;
                }
            }
            return true;
        }

    }

}
