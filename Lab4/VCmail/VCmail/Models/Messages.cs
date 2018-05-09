using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCmail.Models
{
    class Messages
    {
        public static List<Message> GetList(string labelId)
        {
            var messagesRequest = MailService.GetInstance().Users.Messages.List("me");
            var messagesData = messagesRequest.Execute().Messages;

            var filterList = new List<Message>();
            foreach (var messageInfo in messagesData)
            {
                var message = Get(messageInfo.Id);
                if (message.LabelIds != null)
                {
                    foreach (var msglabelId in message.LabelIds)
                    {
                        if (msglabelId.Equals(labelId))
                        {
                            filterList.Add(message);
                        }
                    }
                }
            }

            return filterList;
        }

        public static Message Get(string messageId)
        {
            var request = MailService.GetInstance().Users.Messages.Get("me", messageId);
            request.Format = UsersResource.MessagesResource.GetRequest.FormatEnum.Full;

            return request.Execute();
        }

        public static void Send(string rawMessage)
        {
            try
            {
                var request = MailService.GetInstance().Users.Messages.Send(new Message
                {
                    Raw = rawMessage
                }, "me").Execute();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

        }

        public static void SaveToDrafts(string rawMessage)
        {
            try
            {
                var request = MailService.GetInstance().Users.Drafts.Create(new Draft
                {
                    Message = new Message
                    {
                        Raw = rawMessage
                    }
                }, "me").Execute();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

        }

    }
}
