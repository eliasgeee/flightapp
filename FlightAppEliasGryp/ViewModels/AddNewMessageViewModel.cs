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
    public class AddNewMessageViewModel : ViewModelBase
    {
        private readonly IConversationService _conversationService;
        public ConversationsViewModel ConversationsViewModel { get { return ViewModelLocator.Current.ConversationsViewModel; } }

        private string _newMessage;
        public string NewMessage { get { return _newMessage; } set { Set("NewMessage", ref _newMessage, value); } }

        public AddNewMessageViewModel(IConversationService conversationService)
        {
            _conversationService = conversationService;
        }

        public ICommand AddNewMessageCommand => new RelayCommand(AddNewMessage);

        public async void AddNewMessage()
        {
           await _conversationService.SendMessage(ConversationsViewModel.SelectedConversation.Conversation, NewMessage);
        }
    }
}
