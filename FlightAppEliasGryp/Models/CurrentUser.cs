using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models
{
    public class CurrentUser : ObservableObject
    {
        public string UserID { get; set; }
        public int Row { get; set; }
        public char Chair { get; set; }
        public string Token { get; set; }

        private UserRole _userRole;
        public UserRole UserRole { get { return _userRole; } set {
                Set("UserRole", ref _userRole, value);
                if(value == UserRole.PASSENGER) { IsPassenger = true; _isCrewMember = false; }
                if (value == UserRole.CREW) { IsPassenger = false; _isCrewMember = true; }
            } 
        }

        private bool _isPassenger;
        public bool IsPassenger { get { return _isPassenger; } set { Set("IsPassenger", ref _isPassenger, value); } }

        private bool _isCrewMember;
        public bool IsCrewMember { get { return _isCrewMember; } set { Set("IsCrewMember", ref _isCrewMember, value); } }
    }

    public enum UserRole
    {
        CREW, PASSENGER
    }
}
