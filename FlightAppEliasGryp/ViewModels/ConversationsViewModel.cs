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
using Windows.UI.WindowManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Animation;

namespace FlightAppEliasGryp.ViewModels
{
    public class ConversationsViewModel : ViewModelBase
    {
        public ObservableCollection<ConversationViewModel> Conversations { get; set; }
        public AppWindow AppWindow { get; set; }
        private IFlightService _flightDataService { get; set; }
        private IConversationService _conversationService { get; set; }
        public NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;

        private ConversationViewModel _selectedConversation;
        public ConversationViewModel SelectedConversation { get { return _selectedConversation; }
            set { Set("SelectedConversation", ref _selectedConversation, value); } }

        public ICommand ItemClickCommand => new RelayCommand(LoadConversationPartners);

        public ConversationsViewModel(IFlightService flightDataService, IConversationService conversationService)
        {
            _flightDataService = flightDataService;
            _conversationService = conversationService;
            Conversations = new ObservableCollection<ConversationViewModel>();
        }

        public async Task LoadDataAsync()
        {
            var data = await _conversationService.GetAllConversationsForUser();
            Conversations.Clear();
            foreach (var item in data)
            {
                Conversations.Add(new ConversationViewModel(item));
            }
            SelectedConversation = Conversations.FirstOrDefault();
        }

        internal void ViewConvoDetails(ConversationViewModel conversation)
        {
            SelectedConversation = conversation;
            NavigationService.Navigate("FlightAppEliasGryp.ViewModels.ConversationDetailViewModel", conversation, new DrillInNavigationTransitionInfo());
        }

        public async void LoadConversationPartners()
        {
            await NavigationService.CreateNewViewAsync<TravelGroupConvoViewModel>();
        }

        public ConversationViewModel GetConvo(int convoId)
        {
            return Conversations.Where(e => e.Conversation.Id == convoId).FirstOrDefault();
        }

        public string GetNewMessagesCount()
        {
            return 0.ToString();
        }
    }
}
