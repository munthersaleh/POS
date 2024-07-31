using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
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
        [Inject]
        IJSRuntime JSRuntime { get; set; }

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
        private string[] pin = new string[4];
        private bool loginError = false;

        //private async Task OnPinInput(int index)
        //{
        //    // Move to the next input field
        //    if (index < 3 && !string.IsNullOrEmpty(pin[index]))
        //    {
        //        await JSRuntime.InvokeVoidAsync("focusElementById", $"pinInput_{index+1}");

        //    }
        //}
        private async Task OnPinInput(ChangeEventArgs e, int index)
        {
            // Update the pin array with the latest value from the input
            pin[index] = e.Value.ToString();

            // Move focus to the next input field if current one is filled
            if (index < 3 && !string.IsNullOrEmpty(pin[index]))
            {
                await JSRuntime.InvokeVoidAsync("focusElementById", $"pinInput_{index + 1}");
            }
            else if(index > 0 && string.IsNullOrEmpty(pin[index]))
            {
                await JSRuntime.InvokeVoidAsync("focusElementById", $"pinInput_{index - 1}");
            }
        }

        private async Task HandleSubmit()
        {
            var enteredPin = string.Join("", pin);
            // Validate PIN
            if (ValidatePin(enteredPin))
            {
                loginError = false;
                navigationManager.NavigateTo("productOrder");
            }
            else
            {
                loginError = true;
            }
        }

        private bool ValidatePin(string pin)
        {
            // Replace with your actual PIN validation logic
            const string correctPin = "1234";
            return pin == correctPin;
        }
    }
}
