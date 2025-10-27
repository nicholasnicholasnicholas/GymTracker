/*
*   This file handles all user-related operations,
*   such as registering, authenticating, and retrieving users.
*   It interacts with the database via Entity Framework Core.
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

        // ✅ Register a new user (creates record if username doesn't exist)
        public async Task<bool> RegisterAsync(string username, string password)
        {
            // Check if username already exists
            if (await _context.Users.AnyAsync(u => u.Username == username))
                return false;

            var user = new User
            {
                Username = username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password) // Hash password securely
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        // ✅ Authenticate user (for Login)
        public async Task<User?> AuthenticateAsync(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                return user; // success

            return null; // failed login
        }

        // ✅ Optional: Get user by username
        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
