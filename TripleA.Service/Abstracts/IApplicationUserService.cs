﻿using TripleA.Data.Entities.Identity;
using TripleA.Domain.Results;

namespace TripleA.Service.Abstracts
{
    public interface IApplicationUserService
    {
        Task<string> AddUserAsync(User user, string password);
        Task<JwtAuthResult> GetJWTToken(User user);
        Task<string> getUserIdAsync();
        Task upUser(string userId);
        public Task<string> DeleteUserAsync(User user);

        // Task<User> getUserByIdAsync(string userId);

        Task DownUser(string userId);

        Task<User> GetUserByIdAsync(string userId);
        Task<List<User>> GetUsersListAsync();
    }
}
