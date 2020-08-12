using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models
{
    public class Conversation
    {
        public int Id { get; set; }
        public ICollection<ConversationPerson> Users { get; private set; }
        public ICollection<Message> Messages { get; private set; }

        public Conversation()
        {
            Messages = new List<Message>();
            Users = new List<ConversationPerson>();
        }

        public string GetLatestMessage() { return Messages.Last().Text; }
        public string GetLatestMessageTime() {
            if (Messages.Last().Time < DateTime.Today.AddDays(-1))
                return Messages.Last().Time.ToShortDateString();
            else
                return Messages.Last().Time.ToShortTimeString();
        }
        public string GetNamesUsersInConversation() {
            var names = "";
            for(int i = 0; i < Users.Count; i++)
            {
                if (!Users.ElementAt(i).IsCurrentUser)
                    names += $"{Users.ElementAt(i).User.GetFullName()}";
                if (i != Users.Count - 1 && i >= 1)
                    names += ",";
            }
            return names;
        }
    }
}
