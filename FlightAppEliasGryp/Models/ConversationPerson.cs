using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models
{
    public class ConversationPerson
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public bool Seen { get; set; }
        public bool IsCurrentUser { get; set; }

        public ConversationPerson() { }

        public ConversationPerson(ApplicationUser user)
        {
            User = user;
        }
    }
}
