/* 
*   Data model for User information
*   Takes username and password and stores them in the database
*   Passwords are hashed for security
*/


namespace GymTracker.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
    }
}