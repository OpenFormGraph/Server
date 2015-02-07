using TreeGecko.Library.Common.Objects;

namespace OpenFormGraph.Library.Objects
{
    public class ListValue : AbstractTGObject
    {
        public string Value { get; set; }
        public string Code { get; set; }

        public override TGSerializedObject GetTGSerializedObject()
        {
            TGSerializedObject tgs = base.GetTGSerializedObject();

            tgs.Add("Value", Value);
            tgs.Add("Code", Code);

            return tgs;
        }

        public override void LoadFromTGSerializedObject(TGSerializedObject _tgs)
        {
            base.LoadFromTGSerializedObject(_tgs);

            Value = _tgs.GetString("Value");
            Code = _tgs.GetString("Code");
        }
    }
}
