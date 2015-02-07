using TreeGecko.Library.Common.Objects;

namespace OpenFormGraph.Library.Objects
{
    public class ListRecord : AbstractTGObject
    {
        public string Name { get; set; }
        public string Description { get; set; }
        
        public override TGSerializedObject GetTGSerializedObject()
        {
            TGSerializedObject tgs = base.GetTGSerializedObject();

            tgs.Add("Name", Name);
            tgs.Add("Description", Description);

            return tgs;
        }

        public override void LoadFromTGSerializedObject(TGSerializedObject _tgs)
        {
            base.LoadFromTGSerializedObject(_tgs);

            Name = _tgs.GetString("Name");
            Description = _tgs.GetString("Description");
        }
    }
}
