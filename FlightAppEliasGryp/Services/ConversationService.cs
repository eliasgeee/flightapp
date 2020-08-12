using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using FlightAppEliasGryp.Models;
using Newtonsoft.Json;

namespace FlightAppEliasGryp.Services
{
    public class ConversationService : IConversationService
    {
        private readonly string baseUri = "Conversation/";
        private HttpClientService _clientService;
        private DataService<Conversation> _dataService;

        public ConversationService(HttpClientService client)
        {
            _clientService = client;
            _dataService = new DataService<Conversation>(_clientService);
        }

        public async Task<Conversation> AddNewConversation(Conversation conversation)
        {
            var request = await _dataService.MakeRequest(new ApiRequest(ApiRequestType.POST)
            {
                Uri = baseUri + "Add",
                Body = conversation
            });
            return request.AsSingle();
        }

        public async Task<ICollection<Conversation>> GetAllConversationsForUser()
        {
            var request = await _dataService.MakeRequest(new ApiRequest(ApiRequestType.GET)
            {
                Uri = baseUri
            });
            return request.AsList();
        }

        public async Task<Conversation> SendMessage(Conversation conversation, Message msg)
        {
            var request = await _dataService.MakeRequest(new ApiRequest(ApiRequestType.POST)
            {
                Uri = baseUri + conversation.Id + "/Message",
                Body = msg
            });
            return request.AsSingle();
        }
    }
}
