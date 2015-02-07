using OpenFormGraph.Library.Objects;
using MongoDB.Driver;
using TreeGecko.Library.Mongo.DAOs;

namespace OpenFormGraph.Library.DAOs
{
    internal class ListValueDAO: AbstractMongoDAO<ListValue>
    {
        public ListValueDAO(MongoDatabase _mongoDB) 
            : base(_mongoDB)
        {
            //ListRecord
            HasParent = true;
        }

        public override string TableName
        {
            get { return "Relationships"; }
        }
    }
}
