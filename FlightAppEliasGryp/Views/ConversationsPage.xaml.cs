using FlightAppEliasGryp.Models;
using FlightAppEliasGryp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.WindowManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FlightAppEliasGryp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ConversationsPage : Page
    {

        private ConversationsViewModel ViewModel
        {
            get { return ViewModelLocator.Current.ConversationsViewModel; }
        }

        public ConversationsPage()
        {
            this.InitializeComponent();
        }

        private async void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            AppWindow appWindow = await AppWindow.TryCreateAsync();
            Frame appWindowContentFrame = new Frame();
            appWindowContentFrame.Navigate(typeof(AddConversationPage));
            ElementCompositionPreview.SetAppWindowContent(appWindow, appWindowContentFrame);
            await appWindow.TryShowAsync();
            appWindow.Closed += delegate
            {
                appWindowContentFrame.Content = null;
                appWindow = null;
                ViewModel.AppWindow = null;
            };

            ViewModel.AppWindow = appWindow;
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter != null)
            {
                var convo = (ConversationViewModel)e.Parameter;
                ViewModel.SelectedConversation =
                    ViewModel.Conversations.Where((item) => item.Conversation.Id == convo.Conversation.Id).FirstOrDefault();
            }
            else
            {
                await ViewModel.LoadDataAsync();
                ViewModel.SelectedConversation = ViewModel.Conversations.FirstOrDefault();
            }

            UpdateForVisualState(AdaptiveStates.CurrentState);

            DisableContentTransitions();
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            ConversationsOverViewListView.SelectedItem = ViewModel.SelectedConversation;
        }

        private void ConversationsOverViewListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var clickedItem = (ConversationViewModel)e.ClickedItem;
            ViewModel.SelectedConversation = clickedItem;

            if (AdaptiveStates.CurrentState == NarrowState)
            {
                ViewModel.ViewConvoDetails(clickedItem);
            }
            else
            {
                EnableContentTransitions();
            }
        }

        private void AdaptiveStates_CurrentStateChanged(object sender, VisualStateChangedEventArgs e)
        {
            UpdateForVisualState(e.NewState, e.OldState);
        }

        private void UpdateForVisualState(VisualState newState, VisualState oldState = null)
        {
            var isNarrow = newState == NarrowState;

            if (isNarrow && oldState == DefaultState && ViewModel.SelectedConversation != null)
            {
                Frame.Navigate(typeof(ConversationDetailPage), ViewModel.SelectedConversation, new SuppressNavigationTransitionInfo());
            }

            EntranceNavigationTransitionInfo.SetIsTargetElement(ConversationsOverViewListView, isNarrow);
            if (DetailContentPresenter != null)
            {
                EntranceNavigationTransitionInfo.SetIsTargetElement(DetailContentPresenter, !isNarrow);
            }
        }

        private void EnableContentTransitions()
        {
            DetailContentPresenter.ContentTransitions.Clear();
            DetailContentPresenter.ContentTransitions.Add(new EntranceThemeTransition());
        }

        private void DisableContentTransitions()
        {
            if (DetailContentPresenter != null)
            {
                DetailContentPresenter.ContentTransitions.Clear();
            }
        }

        private void MessageTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textbox = sender as TextBox;
        }
    }
}
