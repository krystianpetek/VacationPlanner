﻿using System.Security.Cryptography;
using System.Text;

namespace VacationPlannerAPI.Services
{
    public interface IUserService
    {
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
    }
}