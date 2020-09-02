using FlightAppEliasGryp.Models;
using FlightAppEliasGryp.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightAppEliasGryp.ViewModels
{
    public class AddConversationViewModel : ViewModelBase
    {
        private readonly IConversationService _conversationService;

        public ObservableCollection<ConversationPartnerViewModel> ConversationPartners { get; set; }
        public string Message { get; set; }

        public AddConversationViewModel(IConversationService conversationService)
        {
            _conversationService = conversationService;
            ConversationPartners = new ObservableCollection<ConversationPartnerViewModel>();
        }

        public async void LoadDataAsync()
        {
            ConversationPartners = new ObservableCollection<ConversationPartnerViewModel>();
            var data = await _conversationService.GetConversationPartnersForPassenger();
            foreach(var passenger in data)
            {
                ConversationPartners.Add(new ConversationPartnerViewModel() { Passenger = passenger });
            }
        }

        public async Task AddNewConversation()
        {
            var convo = await _conversationService.
                AddNewConversation(ConversationPartners.Where(e => e.IsSelected).Select(e => e.Passenger).ToList());
            await _conversationService.SendMessage(convo, Message);
        }
    }
}
