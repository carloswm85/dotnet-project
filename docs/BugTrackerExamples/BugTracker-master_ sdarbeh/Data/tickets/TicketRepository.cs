using System.Collections.Generic;
using System.Threading.Tasks;
using BugTrackerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BugTrackerAPI.Data.tickets
{
    public class TicketRepository : ITicketRepository
    {
        private readonly DataContext _context;
        public TicketRepository(DataContext context)
        {
            _context = context;

        }

        // creates ticket
        public async Task<Ticket> CreateTicket(Ticket ticket)
        {
            await _context.Tickets.AddAsync(ticket);
            await _context.SaveChangesAsync();

            return ticket;
        }

        public async Task<List<Ticket>> GetAllTickets()
        {
            return await _context.Tickets.ToListAsync();
        }

        // queries db for ticket matching the id
        public async Task<Ticket> GetTicket(int id)
        {
            var ticket = await _context.Tickets
                .FirstOrDefaultAsync(foundTicket => foundTicket.Id == id);
            
            // will return null if no ticket is found in db
            return ticket;
        }

        // Checks db for employees matching the fullname and email
        public async Task<bool> TicketExists(string title)
        {
            if (await _context.Tickets.AnyAsync(foundTicket => foundTicket.Title == title))
                return true;

            return false;
        }
    }
}