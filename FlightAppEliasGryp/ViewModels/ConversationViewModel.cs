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
    public class ConversationViewModel : ViewModelBase
    {
        private IConversationService _conversationService { get { return ViewModelLocator.Current.ConversationService; } }
        public NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;

        private Conversation _conversation;
        public Conversation Conversation { get { return _conversation; }
            set { Set("Conversation", ref _conversation, value);  } }

        public ConversationViewModel(Conversation conversation)
        {
            Conversation = conversation;
        }
    }
}
