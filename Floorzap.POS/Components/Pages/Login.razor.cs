using Microsoft.AspNetCore.Components;
using POSModel.Models;
using POSServices.Services.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floorzap.POS.Components.Pages
{
    public partial class Login
    {

        public UserLogin userLoginModel { get; set; } = new UserLogin();
        [Inject]
        IAccountService accountService { get; set; }
        [Inject]
        NavigationManager navigationManager { get; set; }

        public bool isInvalidCredentials  = false;

        private async Task LoginUser()
        {
            isInvalidCredentials = false;
            bool isAuth = await accountService.Login(userLoginModel);
            if (isAuth)
            {
                navigationManager.NavigateTo("customerOrder");
            }
            else
            {
                isInvalidCredentials = true;
            }
        }
    }
}
