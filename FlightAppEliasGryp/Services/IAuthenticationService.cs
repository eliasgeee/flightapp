using FlightAppEliasGryp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Services
{
    public interface IAuthenticationService
    {
        Task<CurrentUser> PassengerLogIn(int row, char chair);
        Task<CurrentUser> GetTokenCurrentUser();
        Task LogOut();
    }
}
