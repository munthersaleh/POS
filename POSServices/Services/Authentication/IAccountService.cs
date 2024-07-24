using POSModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSServices.Services.Authentication
{
    public interface IAccountService
    {
        public Task<bool> Login(UserLogin data);
    }
}
