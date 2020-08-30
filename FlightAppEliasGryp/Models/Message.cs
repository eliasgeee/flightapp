using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public ApplicationUser Sender { get; set; }
        public DateTime Time { get; set; }
        public bool IsUser { get; set; }
        public int Column { get { if (IsUser) return 1; else return 0; }  }

        public Message(string text)
        {
            Text = text;
            Time = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{Sender.GetFullName()} : {Text}";
        }

        public string GetFormattedTime()
        {
            return $"{Time.ToShortDateString()} {Time.ToShortTimeString()}";
        }
    }
}
