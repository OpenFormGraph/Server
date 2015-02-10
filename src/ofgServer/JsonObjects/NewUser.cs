using TreeGecko.Library.Net.Objects;

namespace OpenFormGraph.Web.JsonObjects
{
    public class NewUser : User
    {
        public NewUser()
        {
            
        }

        public NewUser(TGUser _user, string _password)
            : base(_user)
        {
            Password = _password;
        }

        public string Password { get; set; } 
    }
}