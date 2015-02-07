using System;
using System.Collections.Specialized;
using OpenFormGraph.Library.Extensions;
using OpenFormGraph.Library.Interfaces;
using TreeGecko.Library.Common.Objects;

namespace OpenFormGraph.Library.Objects
{
    public class Relationship : AbstractTGObject, IMetadata
    {
        public Guid RelatedObjectGuid { get; set; }
        public string RelationshipType { get; set; }
        public NameValueCollection Metadata { get; set; }

        public override TGSerializedObject GetTGSerializedObject()
        {
            TGSerializedObject tgs = base.GetTGSerializedObject();

            tgs.Add("RelatedObjectGuid", RelatedObjectGuid);
            tgs.Add("RelationshipType", RelationshipType);
            tgs.AddMetadata("meta_", Metadata);

            return tgs;
        }

        public override void LoadFromTGSerializedObject(TGSerializedObject _tgs)
        {
            base.LoadFromTGSerializedObject(_tgs);

            RelatedObjectGuid = _tgs.GetGuid("RelatedObjectGuid");
            RelationshipType = _tgs.GetString("RelationshipType");
            Metadata = _tgs.GetMetadata("meta_");
        }

    }
}
