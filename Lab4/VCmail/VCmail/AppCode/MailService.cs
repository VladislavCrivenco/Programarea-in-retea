using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace VCmail
{
    class MailService : GmailService
    {
        private static string ApplicationName = "Gmail Custom Client";

        private static MailService _service;

        public static MailService GetInstance()
        {
            if (_service == null)
            {
                var credentials = Credentials.Get();
                _service = new MailService(credentials);
            }

            return _service;
        }

        private MailService(UserCredential credential) :
            base(new Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            })
        { }



    }
}
