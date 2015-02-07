using OpenFormGraph.Library.DAOs;
using MongoDB.Driver;
using TreeGecko.Library.Mongo.Managers;
using TreeGecko.Library.Net.DAOs;
using TreeGecko.Library.Net.Managers;

namespace OpenFormGraph.Library.Managers
{
    public class FormDataStructureManager : AbstractCoreStructureManager
    {
        public FormDataStructureManager(MongoDatabase _mongoDB) 
            : base(_mongoDB)
        {
        }

        public override void BuildDB()
        {
            BuildDB(true);

            FormRecordDAO formRecordDAO = new FormRecordDAO(MongoDB);
            formRecordDAO.BuildTable();

            ListRecordDAO listRecordDAO = new ListRecordDAO(MongoDB);
            listRecordDAO.BuildTable();

            ListValueDAO listValueDAO = new ListValueDAO(MongoDB);
            listValueDAO.BuildTable();

            QuestionDAO questionDAO = new QuestionDAO(MongoDB);
            questionDAO.BuildTable();

            RelationshipDAO relationshipDAO = new RelationshipDAO(MongoDB);
            relationshipDAO.BuildTable();
        }
    }
}
