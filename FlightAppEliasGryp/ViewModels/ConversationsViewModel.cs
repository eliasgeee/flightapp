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
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Animation;

namespace FlightAppEliasGryp.ViewModels
{
    public class ConversationsViewModel : ViewModelBase
    {
        public ICollection<Conversation> Conversations { get; set; }
        private IFlightService _flightDataService { get; set; }
        private IConversationService _conversationService { get; set; }
        public NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;

        public ICommand ItemClickCommand => new RelayCommand(LoadConversationPartners);

        public string MessageTxt { get; set; }

        public ConversationsViewModel(IFlightService flightDataService, IConversationService conversationService)
        {
            _flightDataService = flightDataService;
            _conversationService = conversationService;
            Conversations = new ObservableCollection<Conversation>();
        }

        public async void LoadDataAsync()
        {
            Conversations.Clear();
            var data = await _conversationService.GetAllConversationsForUser();
            foreach (var item in data)
            {
                Conversations.Add(item);
            }
        }

        internal void ViewConvoDetails(Conversation conversation)
        {
            NavigationService.Navigate("FlightAppEliasGryp.ViewModels.ConversationDetailViewModel", conversation, new DrillInNavigationTransitionInfo());
        }

        public async void LoadConversationPartners()
        {
            await NavigationService.CreateNewViewAsync<TravelGroupConvoViewModel>();
        }

        public string GetNewMessagesCount()
        {
            return 0.ToString();
        }

        public async void AddNewMessage(Conversation conversation, string message)
        {
            await _conversationService.SendMessage(conversation, new Message(MessageTxt));
        }
    }
}
