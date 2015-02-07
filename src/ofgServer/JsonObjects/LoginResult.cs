
namespace OpenFormGraph.Web.JsonObjects
{
    public class LoginResult
    {
        public string Result { get; set; }
        public string DisplayName { get; set; }
        public string Username { get; set; }
        public string AuthToken { get; set; }
        public string NeedsEula { get; set; }
        public string EulaGuid { get; set; }
        public string EulaText { get; set; }
    }
}