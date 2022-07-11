using System;
using System.Collections.Generic;

namespace BugTrackerAPI.Models
{
    // employee class
    // for validations visit /DTOS/employee/*
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public string Position { get; set; } 
        public string Team { get; set; } 
        public DateTime HireDate { get; set; }
        public DateTime LastActive { get; set; }
        public string ProfilePicture { get; set; }  
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; } 
        // public ICollection<Ticket> TicketsResponsible { get; set; }
    }
}