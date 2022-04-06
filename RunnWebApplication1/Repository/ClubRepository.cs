﻿using Microsoft.EntityFrameworkCore;
using RunnWebApplication1.Data;
using RunnWebApplication1.Interfaces;
using RunnWebApplication1.Models;

namespace RunnWebApplication1.Repository
{
    public class ClubRepository : IClubRepository
    {
        private readonly ApplicationDbContext _context;

        public ClubRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Club club)
        {
            _context.Add(club);
            return Save();
        }

        public bool Delete(Club club)
        {
            _context.Remove(club);
            return Save();
        }

        public async Task<IEnumerable<Club>> GetAll()
        {
           return await _context.Clubs.ToListAsync();
        }

        public async Task<Club> GetByIdAsync(int id)
        {
            return await _context.Clubs.Include(x => x.Address).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Club>> GetClubByCity(string city)
        {
            return await _context.Clubs.Where(x => x.Address.City.Contains(city)).ToListAsync();
        }
        public async Task<Club> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Clubs.Include(x => x.Address).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }



        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Club club)
        {
            _context.Update(club);
            return Save();
        }
    }
}
