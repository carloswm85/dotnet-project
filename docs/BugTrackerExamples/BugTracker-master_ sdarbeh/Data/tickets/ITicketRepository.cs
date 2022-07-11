using System.Collections.Generic;
using System.Threading.Tasks;
using BugTrackerAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BugTrackerAPI.Data.tickets
{
    /* 
    Repository Patterns allows all of your code to use objects without having to know how the objects are persisted.
    All of the knowledge of persistence, including mapping from tables to objects, is safely contained in the repository.
    */
    public interface ITicketRepository
    {
        Task<bool> TicketExists(string title);
        Task<Ticket> CreateTicket(Ticket ticket);
        Task<Ticket> GetTicket(int id);
        // Task<IEnumerable<Ticket>> GetAllTickets();
        Task<List<Ticket>> GetAllTickets();
    }
}