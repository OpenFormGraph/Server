using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using OpenFormGraph.Library.Constants;
using OpenFormGraph.Library.Managers;
using OpenFormGraph.Library.Objects;
using OpenFormGraph.Web.Constants;
using OpenFormGraph.Web.JsonObjects;
using TreeGecko.Library.Net.Objects;

namespace OpenFormGraph.Web.Helpers
{
    public static class JsonHelper
    {
        public static string GetLookup(string _type)
        {
            switch (_type)
            {
                case "formsubject":
                    return GetFormSubjects();
            }

            return null;
        }

        public static string GetFormTemplate(OpenFormGraphManager _manager, Guid _formTemplateGuid)
        {
            FormRecord formRecord = _manager.GetFormRecord(_formTemplateGuid);

            if (formRecord != null)
            {
                FormTemplate jFormTemplate = new FormTemplate(formRecord);

                return JsonConvert.SerializeObject(jFormTemplate);
            }


            return null;
        }

        public static string GetFormSubjects()
        {
            List<NameValuePair> formSubjects = new List<NameValuePair>
            {
                new NameValuePair() {Name = FormSubject.Person, Value = FormSubject.Person},
                new NameValuePair() {Name = FormSubject.Place, Value = FormSubject.Place},
                new NameValuePair() {Name = FormSubject.Thing, Value = FormSubject.Thing},
                new NameValuePair() {Name = FormSubject.Event, Value = FormSubject.Event},
                new NameValuePair() {Name = FormSubject.Review, Value = FormSubject.Review}
            };


            return JsonConvert.SerializeObject(formSubjects);
        }

        public static void PersistFormTemplate(OpenFormGraphManager _manager, string _json)
        {
            if (_json != null)
            {
                FormTemplate jFormTemplate = JsonConvert.DeserializeObject<FormTemplate>(_json);

                FormRecord form = null;

                if (!string.IsNullOrEmpty(jFormTemplate.Guid))
                {
                    Guid guid;
                    if (Guid.TryParse(jFormTemplate.Guid, out guid))
                    {
                        form = _manager.GetFormRecord(guid);
                    }
                }

                if (form == null)
                {
                    form = new FormRecord
                    {
                        Active = true,
                        IsTemplate = true
                    };
                }

                form.Description = jFormTemplate.Description;
                form.FormSubject = jFormTemplate.FormSubject;
                form.Name = jFormTemplate.Name;
                form.SuperclassGuid = jFormTemplate.SuperclassGuid;

                _manager.Persist(form);
            }
        }

        public static List<JsonObjects.FormTemplate> GetFormTemplates(OpenFormGraphManager _manager, 
            List<FormRecord> _formRecords)
        {
            List<JsonObjects.FormTemplate> jFormTemplates = new List<FormTemplate>();

            foreach (FormRecord formRecord in _formRecords)
            {
                FormTemplate jFormTemplate = new FormTemplate(formRecord);
                jFormTemplates.Add(jFormTemplate);

                //Load child objects
            }

            return jFormTemplates;
        }

        public static List<JsonObjects.User> GetUsers(OpenFormGraphManager _manager, List<TGUser> _users)
        {
            List<JsonObjects.User> jUsers = new List<User>();

            foreach (TGUser tgUser in _users)
            {
                JsonObjects.User user = new User(tgUser);

                if (_manager.HasUserRole(user.Guid, UserRoles.UserAdmin))
                {
                    user.IsUserAdmin = true;
                }
                else
                {
                    user.IsUserAdmin = false;
                }

                if (_manager.HasUserRole(user.Guid, UserRoles.DataAdmin))
                {
                    user.IsDataAdmin = true;
                }
                else
                {
                    user.IsDataAdmin = false;
                }

                jUsers.Add(user);
            }

            return jUsers;
        }

    }
}