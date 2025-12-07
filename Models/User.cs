/* 
*   Data model for User information
*   Takes username and password and stores them in the database
*   Passwords are hashed for security
*/

using System.Text.Json.Serialization;

namespace GymTracker.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime DateJoined { get; set; } = DateTime.MinValue;

        // PROFILE STUFF
        public string Nickname { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;
        public string Pronouns { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        // Profile image as byte array (BLOB)
        public byte[]? ProfileImage { get; set; }
        public string? ProfileImageMimeType { get; set; } // e.g. "image/png"

        // Persisted workout sessions for this user
        [JsonIgnore]
        public List<WorkoutSession> WorkoutSessions { get; set; } = new();
    }
}