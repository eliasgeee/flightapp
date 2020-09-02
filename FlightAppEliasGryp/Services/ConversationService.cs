using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using FlightAppEliasGryp.Models;
using FlightAppEliasGryp.Models.DTO_s;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;

namespace FlightAppEliasGryp.Services
{
    public class ConversationService : IConversationService
    {
        private readonly string baseUri = "Conversation/";

        private readonly IAuthenticationService _authenticationService;
        private HttpClientService _clientService;
        private DataService<Conversation> _dataService;
        private DataService<Passenger> _passengerDataService;

        private HubConnection _connection;
        public HubConnection Connection() { return _connection; }

        public ConversationService(HttpClientService client, IAuthenticationService authenticationService)
        {
            _clientService = client;
            _dataService = new DataService<Conversation>(_clientService);
            _passengerDataService = new DataService<Passenger>(_clientService);
            _authenticationService = authenticationService;
        }

        public async Task InitConnection() {
            var user = await _authenticationService.GetTokenCurrentUser();
            if(user != null)
            _connection = new HubConnectionBuilder()
            .WithAutomaticReconnect()
            .WithUrl("https://localhost:44332/convos", options =>
            {
                options.AccessTokenProvider = () => Task.FromResult(user.Token);
            })
            .Build();

            await _connection.StartAsync();
        }

        public async Task SendMessage(Conversation conversation, string message)
        {
            await _connection.InvokeAsync("SendMessage",
             conversation.Id, new Message(message));
         //  await _connection.SendAsync("SendMessage", )
         //  _connection.InvokeAsync("SendMessage", "heeeeeey");
        }

        public async Task<Conversation> AddNewConversation(List<Passenger> users)
        {
            var request = await _dataService.MakeRequest(new ApiRequest(ApiRequestType.POST)
            {
                Uri = baseUri + "Add",
                Body = new AddConversationDTO() { Users = users}
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

        public async Task<ICollection<Passenger>> GetConversationPartnersForPassenger()
        {
            var request = await _passengerDataService.MakeRequest(new ApiRequest(ApiRequestType.GET)
            {
                Uri = baseUri + "ConversationPartners"
            });
            return request.AsList();
        }

        //public async Task<Conversation> SendMessage(Conversation conversation, Message msg)
        //{
        //    var request = await _dataService.MakeRequest(new ApiRequest(ApiRequestType.POST)
        //    {
        //        Uri = baseUri + conversation.Id + "/Message",
        //        Body = msg
        //    });
        //    return request.AsSingle();
        //}
    }
}
