using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenFormGraph.Web.JsonObjects
{
    public class QuestionTemplate : AbstractBaseItem
    {
        public bool IsRequired { get; set; }
        public string QuestionType { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string Format { get; set; }

        public string Answer { get; set; }
        public Guid? PreviousQuestion { get; set; }
        public Guid? NextQuestion { get; set; }
    }
}