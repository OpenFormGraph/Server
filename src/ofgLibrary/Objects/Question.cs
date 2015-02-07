using System;
using TreeGecko.Library.Common.Objects;

namespace OpenFormGraph.Library.Objects
{
    public class Question : AbstractTGObject
    {
        public bool IsRequired { get; set; }
        public string QuestionType { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string Format { get; set; }
        public string Answer { get; set; }
        public Guid? PreviousQuestion { get; set; }
        public Guid? NextQuestion { get; set; }

        public override TGSerializedObject GetTGSerializedObject()
        {
            TGSerializedObject tgs = base.GetTGSerializedObject();

            tgs.Add("IsRequired", IsRequired);
            tgs.Add("QuestionType", QuestionType);
            tgs.Add("Text", Text);
            tgs.Add("Description", Description);
            tgs.Add("Format", Format);
            tgs.Add("Answer", Answer);
            tgs.Add("NextQuestion", NextQuestion);
            tgs.Add("PreviousQuestion", PreviousQuestion);

            return tgs;
        }

        public override void LoadFromTGSerializedObject(TGSerializedObject _tgs)
        {
            base.LoadFromTGSerializedObject(_tgs);

            IsRequired = _tgs.GetBoolean("IsRequired");
            QuestionType = _tgs.GetString("QuestionType");
            Text = _tgs.GetString("Text");
            Description = _tgs.GetString("Description");
            Format = _tgs.GetString("Format");
            Answer = _tgs.GetString("Answer");
            NextQuestion = _tgs.GetNullableGuid("NextQuestion");
            PreviousQuestion = _tgs.GetNullableGuid("PreviousQuestion");
        }
    }
}
