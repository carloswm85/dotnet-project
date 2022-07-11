using Microsoft.AspNetCore.SignalR.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackerDef.Domain
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int EmployeeID { get; set; }
        public int TicketID { get; set; }
        public string EmployeeName { get; set; }
        public string Text { get; set; }

        public DateTime TimeStamp { get; set; }

    }
}
