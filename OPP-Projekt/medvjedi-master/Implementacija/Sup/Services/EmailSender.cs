using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using RestSharp;
using RestSharp.Authenticators;

namespace Sup.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {

        private readonly EmailSettings _emailSettings = new EmailSettings
        {
            ApiBaseUri = "https://api.mailgun.net/v3/sandbox3798929d5ded4c89b4c56dfc0efd0c2f.mailgun.org",
            ApiKey = "key-93b569103906227b285cf20d9ad8f636",
            From = "postmaster@sandbox3798929d5ded4c89b4c56dfc0efd0c2f.mailgun.org",
            RequestUri = "sandbox3798929d5ded4c89b4c56dfc0efd0c2f.mailgun.org/messages",
            DomainName = "sandbox3798929d5ded4c89b4c56dfc0efd0c2f.mailgun.org"
        };

        
        public async Task<IRestResponse> SendEmailAsync(string email, string subject, string message)
        {
            RestClient client = new RestClient ();
            client.BaseUrl = new Uri ("https://api.mailgun.net/v3");
            client.Authenticator =
                new HttpBasicAuthenticator ("api",
                    _emailSettings.ApiKey);
            RestRequest request = new RestRequest ();
            request.AddParameter ("domain", _emailSettings.DomainName, ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter ("from", "SUP <sup@sup.hr>");
            request.AddParameter ("to", email);
            //request.AddParameter ("to", "YOU@YOUR_DOMAIN_NAME");
            request.AddParameter ("subject", subject);
            request.AddParameter ("text", message);
            request.Method = Method.POST;
            return client.Execute(request);
        }
    }
}
