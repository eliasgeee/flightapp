using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models
{
    public class ApplicationUser : ObservableObject
    {
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public ApplicationUser() { }

        public ApplicationUser(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public virtual string GetFullName()
        {
            return $"{Firstname} {Lastname}";
        }
    }
}
