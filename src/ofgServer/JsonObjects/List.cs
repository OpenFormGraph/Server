using System;
using System.Collections.Generic;

namespace OpenFormGraph.Web.JsonObjects
{
    public class List
    {
        public List(Library.Objects.ListRecord _listRecord,
            List<Library.Objects.ListValue> _values)
        {
            Guid = _listRecord.Guid;
            Name = _listRecord.Name;
            Description = _listRecord.Description;

            Values = new List<ListValue>();
            foreach (Library.Objects.ListValue value in _values)
            {
                ListValue lv = new ListValue(value);
                Values.Add(lv);
            }
        }

        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ListValue> Values { get; set; }
    }
}