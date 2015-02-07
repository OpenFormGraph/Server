using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Amazon.SimpleWorkflow.Model;
using OpenFormGraph.Library.DAOs;
using OpenFormGraph.Library.Objects;
using MongoDB.Driver;
using TreeGecko.Library.AWS.Helpers;
using TreeGecko.Library.Common.Helpers;
using TreeGecko.Library.Common.Objects;
using TreeGecko.Library.Net.Helpers;
using TreeGecko.Library.Net.Managers;
using TreeGecko.Library.Net.Objects;

namespace OpenFormGraph.Library.Managers
{
    public class FormDataManager : AbstractCoreManagerWithUser
    {
        public FormDataManager()
            : base("FormData")
        {
        }

        #region FormRecord

        public FormRecord GetFormRecord(Guid _guid)
        {
            FormRecordDAO dao = new FormRecordDAO(MongoDB);
            return dao.Get(_guid);
        }

        public void DeleteFormRecord(Guid _guid)
        {
            FormRecordDAO dao = new FormRecordDAO(MongoDB);
            dao.Delete(_guid);

            //TODO - Cascade Delete Relationships & questions
        }

        public void Persist(FormRecord _formRecord)
        {
            FormRecordDAO dao = new FormRecordDAO(MongoDB);
            dao.Persist(_formRecord);
        }

        #endregion

        #region ListRecord

        public ListRecord GetListRecord(Guid _listRecordGuid)
        {
            ListRecordDAO dao = new ListRecordDAO(MongoDB);
            return dao.Get(_listRecordGuid);
        }

        public void DeleteListRecord(Guid _listRecordGuid)
        {
            ListRecordDAO dao = new ListRecordDAO(MongoDB);
            dao.Delete(_listRecordGuid);

            //TODO - Cascade ListValue
        }

        public List<ListRecord> GetListRecords()
        {
            ListRecordDAO dao = new ListRecordDAO(MongoDB);
            return dao.GetAll();
        }

        public void Persist(ListRecord _listRecord)
        {
            ListRecordDAO dao = new ListRecordDAO(MongoDB);
            dao.Persist(_listRecord);
        }

        #endregion

        #region ListValue

        public void DeleteListValue(Guid _listValueGuid)
        {
            ListValueDAO dao = new ListValueDAO(MongoDB);
            dao.Delete(_listValueGuid);
        }

        public ListValue GetListValue(Guid _listValueGuid)
        {
            ListValueDAO dao = new ListValueDAO(MongoDB);
            return dao.Get(_listValueGuid);
        }

        public void Persist(ListValue _listValue)
        {
            ListValueDAO dao = new ListValueDAO(MongoDB);
            dao.Persist(_listValue);
        }

        public List<ListValue> GetListValues()
        {
            ListValueDAO dao = new ListValueDAO(MongoDB);
            return dao.GetAll();
        }

        public List<ListValue> GetListValues(Guid _listRecordGuid)
        {
            ListValueDAO dao = new ListValueDAO(MongoDB);
            return dao.GetChildrenOf(_listRecordGuid);
        }

        #endregion

        #region Question

        public Question GetQuestion(Guid _questionGuid)
        {
            QuestionDAO dao = new QuestionDAO(MongoDB);
            return dao.Get(_questionGuid);
        }

        public void DeleteQuestion(Guid _questionGuid)
        {
            QuestionDAO dao = new QuestionDAO(MongoDB);
            dao.Delete(_questionGuid);
        }

        public void Persist(Question _question)
        {
            QuestionDAO dao = new QuestionDAO(MongoDB);
            dao.Persist(_question);
        }

        public List<Question> GetQuestions(Guid _formRecordGuid)
        {
            QuestionDAO dao = new QuestionDAO(MongoDB);
            return dao.GetChildrenOf(_formRecordGuid);
        }

        #endregion

        #region Relationship

        public Relationship GetRelationship(Guid _relationshipGuid)
        {
            RelationshipDAO dao = new RelationshipDAO(MongoDB);
            return dao.Get(_relationshipGuid);
        }

        public void DeleteRelationship(Guid _relationshipGuid)
        {
            RelationshipDAO dao = new RelationshipDAO(MongoDB);
            dao.Delete(_relationshipGuid);
        }

        public List<Relationship> GetRelationships(Guid _formRecordGuid)
        {
            RelationshipDAO dao = new RelationshipDAO(MongoDB);
            return dao.GetChildrenOf(_formRecordGuid);
        }

        public void Persist(Relationship _relationship)
        {
            RelationshipDAO dao = new RelationshipDAO(MongoDB);
            dao.Persist(_relationship);
        }

        #endregion

        #region Email

        public bool SendCannedEmail(TGUser _tgUser,
                                    string _cannedEmailName,
                                    NameValueCollection _additionParameters)
        {
            try
            {
                CannedEmail cannedEmail = GetCannedEmail(_cannedEmailName);

                if (cannedEmail != null)
                {
                    SystemEmail email = new SystemEmail(cannedEmail.Guid);

                    TGSerializedObject tgso = _tgUser.GetTGSerializedObject();
                    foreach (string key in _additionParameters.Keys)
                    {
                        string value = _additionParameters.Get(key);
                        tgso.Add(key, value);
                    }

                    CannedEmailHelper.PopulateEmail(cannedEmail, email, tgso);

                    SESHelper.SendMessage(email);
                    Persist(email);

                    return true;
                }

                TraceFileHelper.Warning("Canned email not found");
            }
            catch (Exception ex)
            {
                TraceFileHelper.Exception(ex);
            }

            return false;
        }


        #endregion

    }
}
