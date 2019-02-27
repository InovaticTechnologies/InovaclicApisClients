using AADB2C.WebClientMvc.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AADB2C.WebClientMvc.Controllers
{
    [Authorize]
    public class ResponsesController : Controller
    {
        private static string serviceUrl = ConfigurationManager.AppSettings["api:InovApiUrl"];

        
        public async Task<ActionResult> Index()
        {
            

                var bootstrapContext = ClaimsPrincipal.Current.Identities.First().BootstrapContext as System.IdentityModel.Tokens.BootstrapContext;

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(serviceUrl);
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "adac3c3114aa4ee19f8c5ea0f97b8e87");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bootstrapContext.Token);


            HttpResponseMessage response;

                byte[] byteData = Encoding.UTF8.GetBytes("{\"callbackCompleted\": \"string\"," +
                    "\"callbackManual\": \"string\"," +
                    "\"files\": [ {\"fileName\": \"string\"," +
                    "\"data\": \"string\"," +
                    "\"cloture\": \"string\"," +
                    "\"siren\": \"string\"," +
                    "\"externalId\": \"string\"} ] }");

                using (var content = new ByteArrayContent(byteData))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    response = await client.PostAsync(serviceUrl, content);
                }

                

                    var res = new ResponseModel();
                    res.StatusCode = response.StatusCode.ToString();

                    return View(res);
                
            
        }

        
        

    }

}