using Google.Apis.Gmail.v1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCmail.Extensions
{
    public static class MessagePartHeaderExtensions
    {
        public static string From = "From";
        public static string Subject = "Subject";
        public static string GetHeader(this IList<MessagePartHeader> headers, string key)
        {
            return headers.FirstOrDefault((x) => x.Name.Equals(key, StringComparison.CurrentCultureIgnoreCase))?.Value;
        }
    }
}
