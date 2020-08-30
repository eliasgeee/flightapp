using FlightAppEliasGryp.Models;
using FlightAppEliasGryp.Models.DTO_s;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace FlightAppEliasGryp.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private const string userFilename = "user.json";
        private LocalStorageService<CurrentUser> _storageService;
        private HttpClientService _clientService;
        private DataService<CurrentUser> _dataService;
        private readonly string baseUri = "Account/";

        public AuthenticationService(HttpClientService client)
        {
            _storageService = new LocalStorageService<CurrentUser>();
            _clientService = client;
            _dataService = new DataService<CurrentUser>(_clientService);
        }

        public async Task<CurrentUser> PassengerLogIn (int row, char chair)
        {
            var request = await _dataService.MakeRequest(new ApiRequest(ApiRequestType.POST)
            {
                Uri = baseUri + "Passenger",
                Body = new LoginDTO { Chair = chair, Row = row }
            });
            var token = request.AsSingle();
            CurrentUser result = null;
            if (token != null)
                result = await Authenticate(token);
            return result;
        }

        public async Task<CurrentUser> CrewMemberLogIn(string username, string password)
        {
            var request = await _dataService.MakeRequest(new ApiRequest(ApiRequestType.POST)
            {
                Uri = baseUri + "Crew",
                Body = new CrewMemberLoginDTO() { UserName = username, Password = password }
            });
            var token = request.AsSingle();
            CurrentUser result = null;
            if (token != null)
                result = await Authenticate(token);
            return result;
        }

        private async Task<CurrentUser> Authenticate(CurrentUser currentUser)
        {
            await SaveToken(currentUser);
            var result = await GetTokenCurrentUser();
            _clientService.Authenticate(result.Token);
            return result;
        }

        private async Task SaveToken(CurrentUser user)
        {
            await _storageService.SaveFileInStorage(userFilename, user, CreationCollisionOption.ReplaceExisting);
        }

        public async Task<CurrentUser> GetTokenCurrentUser()
        {
            var currentUser = await _storageService.GetFileFromStorage(userFilename);
            return currentUser;
        }

        public async Task LogOut()
        {
            var folder = ApplicationData.Current.LocalFolder;
            var newFile = await folder.CreateFileAsync(userFilename, CreationCollisionOption.ReplaceExisting);
            var text = "";
            await FileIO.WriteTextAsync(newFile, text);
        }
    }
}
