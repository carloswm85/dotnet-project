using System;
using System.Threading.Tasks;
using BugTrackerAPI.Data.tickets;
using BugTrackerAPI.DTOS.ticket;
using BugTrackerAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BugTrackerAPI.Controllers.Tickets
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketRepository _repo;

        public TicketsController(ITicketRepository repo)
        {
            _repo = repo;
        }

        // routes
        [HttpPost("create-ticket")]
        public async Task<IActionResult> CreateTicket(TicketCreateDTO ticketDTO)
        {
            var validatedTitle = ticketDTO.Title.ToLower();
            var validatedDescription = ticketDTO.Description.ToLower();
            var validatedWebsiteUrl = ticketDTO.WebsiteUrl.ToLower();
            
            // new ticket schema
            var ticketToCreate = new Ticket
            {
                Title = validatedTitle,
                Description = validatedDescription,
                WebsiteUrl = validatedWebsiteUrl,
                Priority = ticketDTO.Priority,
                // CreatedDate = DateTime.Now()
            };

            var createdUser = await _repo.CreateTicket(ticketToCreate);
            // return CreatedAtRoute()
            return StatusCode(201);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicket(int id)
        {
            return Ok(new {
                 ticket = await _repo.GetTicket(id)
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTickets(int id)
        {
            return Ok(new {
                 tickets = await _repo.GetAllTickets()
            });
        }

    }

}