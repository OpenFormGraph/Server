using OpenFormGraph.Library.Objects;
using MongoDB.Driver;
using TreeGecko.Library.Mongo.DAOs;

namespace OpenFormGraph.Library.DAOs
{
    internal class RelationshipDAO : AbstractMongoDAO<Relationship>
    {
        public RelationshipDAO(MongoDatabase _mongoDB) 
            : base(_mongoDB)
        {
            //FormRecord
            HasParent = false;
        }

        public override string TableName
        {
            get { return "Relationships"; }
        }
    }
}
