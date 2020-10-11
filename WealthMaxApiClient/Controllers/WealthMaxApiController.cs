using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using System.Web.Http.Cors;
using WealthMaxApiClient.cors;
using WealthMaxApiClient.Models;

namespace WealthMaxApiClient.Controllers
{
    public class WealthMaxApiController : ApiController
    {
        [AllowAnonymous]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]

        public ReponseObject Post([FromBody]RequestObject commandObj)
        {
            var client = new RestClient("https://crm.wealthmax.co.uk/api/api/values?title=" + commandObj.title +
                "&firstname=" + commandObj.firstname +
                "&middlename=" + commandObj.middlename +
                "&lastname=" + commandObj.lastname +
                "&nexIBO=" + commandObj.nexIBO +
                "&martial_status=" + commandObj.martial_status +
                "&email=" + commandObj.email +
                "&phone=" + commandObj.phone +
                "&lead_source_id=1" +
                "&gender=Male" + commandObj.gender +
                "&mortgage=" + commandObj.mortgage +
                "&customer_isSmoker=" + commandObj.customer_isSmoker +
                "&annual_income=" + commandObj.annual_income +
                "&address1=Flat%201" + commandObj.address1 +
                "&address2=153%20Sutton%20Lane" + commandObj.address2 +
                "&city=Hounslow" + commandObj.city +
                "&county=Middlesex" + commandObj.county +
                "&country=United%20Kingdom" + commandObj.country +
                "&postcode=TW3%204JW" + commandObj.postcode +
                "&username=leads@nex-protect.co.uk" +
                "&password=joshi123" +
                "&apiKey=EuMysjk9YrW2rMYB4e5tt2Wxgs4NgkZV" +
                "&selected_products=" + commandObj.selected_products +
                "&date_of_birth=" + commandObj.date_of_birth
                );
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);
            var result = response.Content;
            //SendEmail(commandObj);
            return JsonConvert.DeserializeObject<ReponseObject>(result);
        }


        [HttpGet]
        public void SendEmail(RequestObject commandObj)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress("fromEmailAddress");
            message.To.Add(new MailAddress("ToAddress"));
            message.Subject = "Sending Email";
            message.IsBodyHtml = true; //to make message body as html  
            message.Body = "&firstname=" + commandObj.firstname +
                "&middlename=" + commandObj.middlename +
                "&lastname=" + commandObj.lastname +
                "&nexIBO=" + commandObj.nexIBO +
                "&martial_status=" + commandObj.martial_status +
                "&email=" + commandObj.email;
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com"; //for gmail host  
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("requiredEmail", "password");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);
        }
    }
}
