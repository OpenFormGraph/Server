using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using OpenFormGraph.Library.Extensions;
using OpenFormGraph.Library.Interfaces;
using TreeGecko.Library.Common.Objects;

namespace OpenFormGraph.Library.Objects
{
    public class FormRecord : AbstractTGObject, IMetadata
    {
        //ParentGuid - Not Used

        public bool IsTemplate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FormSubject { get; set; }
        public Guid? SuperclassGuid { get; set; }
        public Guid? TemplateGuid { get; set; }
        public NameValueCollection Metadata { get; set; }

        public override TGSerializedObject GetTGSerializedObject()
        {
            TGSerializedObject tgs = base.GetTGSerializedObject();

            tgs.Add("Description", Description);
            tgs.Add("FormSubject", FormSubject);
            tgs.Add("IsTemplate", IsTemplate);
            tgs.Add("Name", Name);
            tgs.Add("SuperclassGuid", SuperclassGuid);
            tgs.Add("TemplateGuid", TemplateGuid);
            tgs.AddMetadata("meta_", Metadata);

            return tgs;
        }

        public override void LoadFromTGSerializedObject(TGSerializedObject _tgs)
        {
            base.LoadFromTGSerializedObject(_tgs);

            Description = _tgs.GetString("Description");
            FormSubject = _tgs.GetString("FormSubject");
            IsTemplate = _tgs.GetBoolean("IsTemplate");
            Name = _tgs.GetString("Name");
            SuperclassGuid = _tgs.GetNullableGuid("SuperclassGuid");
            TemplateGuid = _tgs.GetNullableGuid("TemplateGuid");
            Metadata = _tgs.GetMetadata("meta_");
        }
    }
}
