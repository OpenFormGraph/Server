using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using OpenFormGraph.Library.Objects;


namespace OpenFormGraph.Web.JsonObjects
{
    public class FormTemplate
    {
        public string Guid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FormSubject { get; set; }
        public Guid? SuperclassGuid { get; set; }
        //public NameValueCollection Metadata { get; set; }

        public List<Question> Questions { get; set; }

        public FormTemplate()
        {
            
        }

        public FormTemplate(Library.Objects.FormRecord _formRecord)
        {
            Guid = _formRecord.Guid.ToString();
            Name = _formRecord.Name;
            Description = _formRecord.Description;
            FormSubject = _formRecord.FormSubject;
            SuperclassGuid = _formRecord.SuperclassGuid;
            //Metadata = _formRecord.Metadata;
        }
    }
}