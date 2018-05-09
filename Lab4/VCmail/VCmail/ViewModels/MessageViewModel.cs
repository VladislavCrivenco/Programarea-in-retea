using Google.Apis.Gmail.v1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCmail.Extensions;

namespace VCmail.ViewModels
{
    public class MessageViewModel
    {
        public string MessageId { get; set; }
        public string UnreadIconVisibility { get; set; }
        public string Subject { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Body { get; set; }
        public string Date { get; set; }
        public string Snippet { get; set; }

        public MessageViewModel(Message message)
        {
            MessageId = message.Id;
            Date = ParseDate(message.Payload.Headers.GetHeader("Date"));
            Subject = message.Payload.Headers.GetHeader("Subject");
            To = message.Payload.Headers.GetHeader("To");
            From = message.Payload.Headers.GetHeader("From").Split('<')[0];
            Body = message.GetBody();
            Snippet = message.Snippet;
            UnreadIconVisibility = message.IsUnread() ? "Visible" : "Hidden";
        }

        private string ParseDate(string strDate)
        {
            var str = strDate.Split(',')[1];

            return str.Substring(1, 11);
        }

        public bool Contains(string query)
        {
            if (Subject.ToLower().Contains(query) || From.ToLower().Contains(query))
            {
                return true;
            }

            return false;
        }
    }
}
