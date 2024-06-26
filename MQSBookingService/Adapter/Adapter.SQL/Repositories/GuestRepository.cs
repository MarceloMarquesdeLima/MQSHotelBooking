﻿using Domain.Entities;
using Domain.Ports;
using Microsoft.EntityFrameworkCore;

namespace Adapter.SQL.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        private MQSDbContext _context;
        public GuestRepository(MQSDbContext context) 
        {
            _context = context;
        }
        public async Task<int> Create(Guest guest)
        {
            _context.Guests.Add(guest);
            await _context.SaveChangesAsync();
            return guest.Id;
        }

        public Task<Guest> Get(int Id)
        {
            return _context.Guests.Where(g => g.Id == Id).FirstOrDefaultAsync();
        }
    }
}
