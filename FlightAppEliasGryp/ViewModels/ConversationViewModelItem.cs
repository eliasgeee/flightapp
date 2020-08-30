using FlightAppEliasGryp.Models;
using FlightAppEliasGryp.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightAppEliasGryp.ViewModels
{
    public class ConversationViewModelItem : ViewModelBase
    {
        public Conversation Conversation { get; set; }
        private IConversationService _conversationService { get; set; }

        public ICommand AddNewMessageCommand => new RelayCommand<string>(AddNewMessage);

        public ConversationViewModelItem(Conversation conversation, IConversationService conversationService)
        {
            Conversation = conversation;
            _conversationService = conversationService;
        }

        private async void AddNewMessage(string text)
        {
            await _conversationService.SendMessage(Conversation, text);
        }
    }
}
