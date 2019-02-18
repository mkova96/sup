using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;

namespace Sup.Services
{
    public interface IEmailSender
    {
        Task<IRestResponse> SendEmailAsync(string email, string subject, string message);
    }
}
