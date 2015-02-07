using OpenFormGraph.Library.Objects;
using MongoDB.Driver;
using TreeGecko.Library.Mongo.DAOs;

namespace OpenFormGraph.Library.DAOs
{
    internal class ListRecordDAO: AbstractMongoDAO<ListRecord>
    {
        public ListRecordDAO(MongoDatabase _mongoDB) 
            : base(_mongoDB)
        {
            HasParent = false;
        }

        public override string TableName
        {
            get { return "ListRecords"; }
        }
    }
}
