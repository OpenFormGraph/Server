
namespace OpenFormGraph.Web.JsonObjects
{
    public class LoginResult : BaseResult
    {
        public string DisplayName { get; set; }
        public string Username { get; set; }
        public string AuthToken { get; set; }
        public string NeedsEula { get; set; }
        public string EulaGuid { get; set; }
        public string EulaText { get; set; }
        public bool IsUserAdmin { get; set; }
        public bool IsDataAdmin { get; set; }
    }
}