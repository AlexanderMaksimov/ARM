using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BaseForTheAges.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; } 
        public string MessageText { get; set; }
        public string Author { get; set; }
        public string Topic { get; set; }
        public DateTime dateTime { get; set; }
    }
}