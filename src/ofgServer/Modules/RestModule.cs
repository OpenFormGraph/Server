using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace OpenFormGraph.Web.Modules
{
    public class RestModule : NancyModule
    {
        public RestModule()
        {
            Get["/rest/form/{guid}"] = _parameters =>
            {
                //Response response = HandleResetPassword(_parameters);
                //response.ContentType = "application/json";
                //return response;
                return null;
            };

            Post["/rest//form"] = _parameters =>
            {
                //Response response = HandleResetPassword(_parameters);
                //response.ContentType = "application/json";
                //return response;
                return null;
            };

            Get["/rest/list/{guid}"] = _parameters =>
            {
                return null;
            };

            Post["/rest/list"] = _parameters =>
            {
                return null;
            };

            Get["/rest/formtemplates"] = _parameters =>
            {
                return null;
            };
        }

    }
}