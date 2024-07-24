using POSModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace POSServices.Services.Authentication
{
    public class AccountService : IAccountService
    {
        public async Task<bool> Login(UserLogin userLogin)
        {
            if (userLogin == null) return false;
           
            UserLogin authUser = new UserLogin()
            {
                SiteUrl = "ken.floorzap.com",
                UserName = "admin@floorzap.com",
                Password = "Admin@123"
            };
            if (userLogin.SiteUrl.Equals(authUser.SiteUrl) && userLogin.UserName.Equals(authUser.UserName) && userLogin.Password.Equals(authUser.Password)) return true; 
            return false;
        }
    }
}
