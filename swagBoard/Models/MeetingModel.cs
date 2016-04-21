using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Whiteboard.Models
{
    public class MeetingModel
    {
        public int Id { get; set; }
        public int Reciever { get; set; }
        public bool Confirmed { get; set; }
        public int Sender { get; set; }
        public string Text { get; set; }
    }
}