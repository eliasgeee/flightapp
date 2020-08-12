using FlightAppEliasGryp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Services
{
    public interface IConversationService
    {
        Task<Conversation> AddNewConversation(Conversation conversation);
        Task<ICollection<Conversation>> GetAllConversationsForUser();
        Task<Conversation> SendMessage(Conversation conversation, Message message);
    }
}
