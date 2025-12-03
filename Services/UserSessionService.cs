using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace GymTracker.Services
{
    public class UserSessionService
    {
        private readonly IJSRuntime jsRuntime;

        public bool IsLoaded { get; private set; } = false;
        public bool IsLoggedIn { get; private set; } = false;
        public string Username { get; private set; } = string.Empty;

        public event Action? OnProfileSaved;

        public UserSessionService(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }

        public async Task LoadUserSessionAsync()
        {
            try
            {
                string? storedUser = await jsRuntime.InvokeAsync<string?>(
                    "localStorage.getItem", "loggedInUser");

                if (!string.IsNullOrWhiteSpace(storedUser))
                {
                    Username = storedUser;
                    IsLoggedIn = true;
                }
                else
                {
                    Username = "";
                    IsLoggedIn = false;
                }
            }
            catch
            {
                Username = "";
                IsLoggedIn = false;
            }

            IsLoaded = true;
        }

        public async Task Login(string username)
        {
            Username = username;
            IsLoggedIn = true;
            await jsRuntime.InvokeVoidAsync("localStorage.setItem", "loggedInUser", username);
        }

        public async Task Logout()
        {
            Username = "";
            IsLoggedIn = false;
            await jsRuntime.InvokeVoidAsync("localStorage.removeItem", "loggedInUser");
        }

        public void TriggerProfileSaved()
        {
            OnProfileSaved?.Invoke();
        }
    }
}
