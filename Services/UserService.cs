/*
*   This file is for user-related operations
*   such as creating a user, retrieving user details, etc.
*   It interacts with the database using Entity Framework Core.
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

        // Method to create a new user
        public async Task<User> CreateUserAsync(string username, string passwordHash)
        {
            var user = new User
            {
                Username = username,
                PasswordHash = passwordHash
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        // Method to retrieve a user by username
        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
        
    }
}