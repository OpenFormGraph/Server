using System;

namespace OpenFormGraph.Web.JsonObjects
{
    public class ListValue
    {
        public Guid Guid { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }

        public ListValue(Library.Objects.ListValue _value)
        {
            Guid = _value.Guid;
            Code = _value.Code;
            Value = _value.Value;
        }
    }
}