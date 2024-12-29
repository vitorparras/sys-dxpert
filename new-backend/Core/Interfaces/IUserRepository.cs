﻿using Core.Entities;

namespace Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid id);
        Task<User> GetByEmailAsync(string email);
        Task<User> CreateAsync(User user);
        Task UpdateAsync(User user);
    }
}
