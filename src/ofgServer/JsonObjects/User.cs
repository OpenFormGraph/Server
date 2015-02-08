using System;
using TreeGecko.Library.Net.Objects;

namespace OpenFormGraph.Web.JsonObjects
{
    public class User
    {
        public User(TGUser _user)
        {
            Guid = _user.Guid;
            Username = _user.Username;
            FirstName = _user.GivenName;
            LastName = _user.FamilyName;
            EmailAddress = _user.EmailAddress;
        }

        public Guid Guid { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public bool IsDataAdmin { get; set; }
        public bool IsUserAdmin { get; set; }
    }
}