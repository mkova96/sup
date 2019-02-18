using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Sup.Services;

namespace Sup.Services
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(email, "Email confirmation",
                $"Please confirm your email by clicking here: <a href='{link}'>link</a>");
        }

        public static Task SendEmailPasswordRessetAsync(this IEmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(email, "Reset Password",
                $"Please reset your password by clicking here: <a href='{link}'>link</a>");
        }
    }
}
