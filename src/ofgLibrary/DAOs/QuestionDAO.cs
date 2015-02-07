using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenFormGraph.Library.Objects;
using MongoDB.Driver;
using TreeGecko.Library.Mongo.DAOs;

namespace OpenFormGraph.Library.DAOs
{
    internal class QuestionDAO: AbstractMongoDAO<Question>
    {
        public QuestionDAO(MongoDatabase _mongoDB) 
            : base(_mongoDB)
        {
            //FormRecord
            HasParent = true;
        }

        public override string TableName
        {
            get { return "Questions"; }
        }
    }
}
