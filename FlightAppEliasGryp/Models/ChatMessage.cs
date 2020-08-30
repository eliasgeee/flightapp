using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models
{
    public class ChatMessage
    {
        public string Sender { get; set; }
        public string Text { get; set; }
        public int ConvoId { get; set; }

        public override string ToString()
        {
            return $"{Sender} : {Text}";
        }
    }
}
