using System.Collections.Specialized;
using TreeGecko.Library.Common.Objects;
using TreeGecko.Library.Geospatial.Objects;


namespace OpenFormGraph.Library.Extensions
{
    public static class TGSerializedObjectExtensions
    {
        public static NameValueCollection GetMetadata(this TGSerializedObject _tgs, string _name)
        {
            NameValueCollection nvc = new NameValueCollection();

            foreach (string key in _tgs.Properties.Keys)
            {
                if (key.StartsWith(_name))
                {
                    string subkey = _name.Substring(_name.Length);
                    string value = _tgs.GetString(key);

                    nvc.Add(subkey, value);
                }
            }

            return nvc;
        }

        public static void AddMetadata(this TGSerializedObject _tgs, 
            string _name, NameValueCollection _metadata)
        {
            foreach (string key in _metadata.AllKeys)
            {
                string value = _metadata.Get(key);

                _tgs.Add(_name + key, value);
            }
        }

    
    }
}
