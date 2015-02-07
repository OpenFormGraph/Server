using System.Collections.Specialized;

namespace OpenFormGraph.Library.Interfaces
{
    interface IMetadata
    {
        NameValueCollection Metadata { get; set; }
    }
}
