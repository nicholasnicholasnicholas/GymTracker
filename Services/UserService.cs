/*
*   This service handles all user-related operations:
*   - Registering new users
*   - Authenticating existing users (login)
*   - Retrieving user information
*   
*   It interacts with the SQLite database through Entity Framework Core.
*/

using GymTracker.Data;
using GymTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace GymTracker.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        // ✅ Register a new user (only if username doesn't exist)
        public async Task<bool> RegisterAsync(string username, string password)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return false;

            // Check if username already exists
            bool exists = await _context.Users.AnyAsync(u => u.Username == username);
            if (exists)
                return false;

            // Create and save new user with hashed password
            var user = new User
            {
                Username = username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                DateJoined = DateTime.Today
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return true;
        }

        // ✅ Authenticate user (login)
        public async Task<User?> AuthenticateAsync(string username, string password)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return null;

            // Look for a user with the matching username
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

            // Reject if username not found
            if (user == null)
                return null;

            // Verify the password using BCrypt
            bool passwordValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
            if (!passwordValid)
                return null;

            // ✅ Login success
            return user;
        }

        // ✅ Optional: Get a user by username (for profile, etc.)
        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return null;

            return await _context.Users
                .Include(u => u.WorkoutSessions)
                    .ThenInclude(s => s.WorkoutEntries)
                        .ThenInclude(e => e.Sets)
                .FirstOrDefaultAsync(u => u.Username == username);
        }

        // Update profile image
        public async Task<bool> UpdateProfileImageAsync(string username, byte[] imageData, string mimeType)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user == null) return false;

            user.ProfileImage = imageData;
            user.ProfileImageMimeType = mimeType;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }

        // Save or update a WorkoutSession for a user (create if new)
        public async Task<bool> SaveWorkoutSessionAsync(string username, WorkoutSession session)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user == null) return false;

            session.UserId = user.Id;

            // if session has Id==0, it's new; otherwise update
            if (session.Id == 0)
            {
                _context.WorkoutSessions.Add(session);
            }
            else
            {
                _context.WorkoutSessions.Update(session);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        // Fetch a workout session for a user by date (date portion only)
        public async Task<WorkoutSession?> GetWorkoutSessionByDateAsync(string username, DateTime date)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user == null) return null;

            var target = await _context.WorkoutSessions
                .Include(s => s.WorkoutEntries)
                    .ThenInclude(e => e.Sets)
                .Where(s => s.UserId == user.Id && s.Date.Year == date.Year && s.Date.Month == date.Month && s.Date.Day == date.Day)
                .FirstOrDefaultAsync();

            return target;
        }

    }
}
