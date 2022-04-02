﻿using RunnWebApplication1.Models;

namespace RunnWebApplication1.Interfaces
{
    public interface IDashboardRepository
    {

        Task<List<Race>> GetAllUserRaces();
        Task<List<Club>> GetAllUserClubs();
        Task<AppUser> GetUserById(string id);
        Task<AppUser> GetByIdNoTracking(string id);
        bool Update(AppUser user);
        bool Save();
    }
}
