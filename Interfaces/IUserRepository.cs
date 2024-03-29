﻿using CookingClub.Models;

namespace CulinaryClub.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<AppUser>> GetAllUser();
        Task<AppUser> GetUserById(string Id);
        bool Add(AppUser user);
        bool Update (AppUser user);
        bool Delete(AppUser user);
        bool Save();
    }
}
