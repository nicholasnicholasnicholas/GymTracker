namespace GymTracker.Services
{
    public class UserSessionService
    {
        public bool IsLoggedIn { get; private set; } = false;
        public string Username { get; private set; } = string.Empty;

        public void Login(string username)
        {
            IsLoggedIn = true;
            Username = username;
        }

        public void Logout()
        {
            IsLoggedIn = false;
            Username = string.Empty;
        }

        public event Action? OnProfileSaved;
        
        public void TriggerProfileSaved()
        {
            OnProfileSaved?.Invoke();
        }

    }
}

