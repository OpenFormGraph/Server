using System;
using System.Collections.Generic;
using OpenFormGraph.Library.Objects;
using MongoDB.Driver;
using TreeGecko.Library.Mongo.DAOs;

namespace OpenFormGraph.Library.DAOs
{
    internal class FormRecordDAO : AbstractMongoDAO<FormRecord>
    {
        public FormRecordDAO(MongoDatabase _mongoDB) 
            : base(_mongoDB)
        {
            HasParent = false;
        }

        public override string TableName
        {
            get { return "FormRecords"; }
        }

        public List<FormRecord> GetFormRecordTemplates()
        {
            return null;
        }

        public List<FormRecord> GetFormRecordTemplates(string _formSubject)
        {
            return null;
        }

        public List<FormRecord> GetFormRecords(Guid _templateGuid)
        {
            return null;
        }

        public List<FormRecord> GetChildFormRecordTemplates(Guid _parentGuid)
        {
            return null;
        }

        public List<FormRecord> GetChildFormRecords(Guid _parentGuid)
        {
            return null;
        }


    }
}
