using FlightAppEliasGryp.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Services
{
    public interface IConversationService
    {
        Task<ICollection<Passenger>> GetConversationPartnersForPassenger();
        Task<Conversation> AddNewConversation(List<Passenger> users, string message);
        Task<ICollection<Conversation>> GetAllConversationsForUser();
       // Task<Conversation> SendMessage(Conversation conversation, Message message);
        Task SendMessage(Conversation conversation, string message);
        HubConnection Connection();
        Task InitConnection();
    }
}
