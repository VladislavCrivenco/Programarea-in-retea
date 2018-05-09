using Google.Apis.Gmail.v1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCmail.AppCode;
using VCmail.Models;

namespace VCmail.Extensions
{
    public static class MessageExtensions
    {
        public static bool HasAttachments(this Message msg)
        {
            if (msg.Payload.Body?.AttachmentId != null)
            {
                return true;
            }

            if (msg.Payload.Parts != null)
            {
                foreach (var part in msg.Payload.Parts)
                {
                    if (part.Body?.AttachmentId != null)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool IsUnread(this Message msg)
        {
            if (msg.LabelIds.Contains(LabelsName.UNREAD.ToString()))
            {
                return true;
            }

            return false;
        }

        public static List<MessagePart> GetAttachments(this Message msg)
        {
            var list = new List<MessagePart>();
            if (msg.Payload.Parts!= null)
            {
                foreach (var part in msg.Payload.Parts)
                {
                    if (part.Filename.IsNotEmpty())
                    {
                        list.Add(part);
                    }
                }
            }

            return list;
        }

        public static string GetBody(this Message msg)
        {
            if (msg.Payload.Body.Data != null)
            {
                return DecodeBody(msg.Payload.Body.Data);
            }

            var result = "";
            foreach (var part in msg.Payload.Parts)
            {
                if (part.MimeType == MimeTypes.PlainText)
                {
                    result = DecodeBody(part.Body.Data);
                }
                else if (part.MimeType == MimeTypes.HTML)
                {
                    result = GetHTMLBody(part);
                }
                else if (part.MimeType == MimeTypes.MultipartAlternative)
                {
                    result = GetMultiPartAlternativeBody(part);
                }
            }

            return result;
        }

        private static string GetMultiPartAlternativeBody(MessagePart msg)
        {
            var result = "";
            foreach (var containerPart in msg.Parts)
            {
                if (containerPart.MimeType == MimeTypes.HTML)
                {
                    result = GetHTMLBody(containerPart);
                }
            }

            return result;
        }

        private static string GetHTMLBody(MessagePart msg)
        {
            var result = DecodeBody(msg.Body.Data);
            if (result.IndexOf("<head>") != -1)
            {
                result = result.Insert(result.IndexOf("<head>"), "<meta http-equiv='Content-Type' content='text/html;charset=UTF-8'>");
            }

            return result;
        }

        private static string DecodeBody(string msg)
        {
            if (msg.IsEmpty())
            {
                return "";
            }

            var bytes = AppCode.Encoding.FromBase64ForUrlString(msg);
            return System.Text.Encoding.UTF8.GetString(bytes);
        }
    }
}
