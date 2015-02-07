using System;

namespace OpenFormGraph.Web.JsonObjects
{
    public class User
    {
        public Guid Guid { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }

    }
}