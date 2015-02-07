using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenFormGraph.Web.JsonObjects
{
    public class Form
    {
        public Form(Library.Objects.FormRecord _form,
            List<Library.Objects.Question> _questions,
            List<Library.Objects.Relationship> _relationships)
        {



            Questions = new List<Question>();
            foreach (Library.Objects.Question question in _questions)
            {
                Question q = new Question(question);
                Questions.Add(q);
            }

            Relationships = new List<Relationship>();
            foreach (Library.Objects.Relationship relationship in _relationships)
            {
                Relationship r = new Relationship(relationship);
                Relationships.Add(r);
            }
        }

        public List<Question> Questions { get; set; }
        public List<Relationship> Relationships { get; set; }
    
    }
}