using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BaseForTheAges.Models
{
    public class MessagesContext:DbContext
    {
        public DbSet<Message> Messages { get; set; }
    }
}