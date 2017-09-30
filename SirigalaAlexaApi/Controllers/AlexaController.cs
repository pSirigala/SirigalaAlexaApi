using SirigalaAlexaApi.Models;
using SirigalaAlexaApi.Models.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SirigalaAlexaApi.Controllers
{
    public class AlexaController : ApiController
    {
        private const string ApplicationId = "amzn1.ask.skill.487f326b-c234-477f-a3f4-0af3c45eb31b";

        [HttpPost, Route("api/alexa")]
        public AlexaResponse Sirigala(AlexaRequest request)
        {
            //if (request.Session.Application.ApplicationId != ApplicationId)
            //    throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));

            //var totalSeconds = (DateTime.UtcNow - request.Request.Timestamp).TotalSeconds;
            //if (totalSeconds < -15 || totalSeconds > 150)
            //    throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));

            AlexaResponse response = null;

            if (request != null)
            {
                switch (request.Request.Type)
                {
                    case "LaunchRequest":
                        response = RequestHandlers.LaunchRequestHandler(request);
                        break;

                    case "IntentRequest":
                        response = RequestHandlers.IntentRequestHandler(request);
                        break;

                    case "SessionEndedRequest":
                        response = RequestHandlers.SessionEndedRequestHandler(request);
                        break;
                }
            }

            return response;
        }
    }
}
