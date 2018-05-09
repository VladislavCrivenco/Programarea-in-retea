using Google.Apis.Gmail.v1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCmail.ViewModels
{
    public class LabelViewModel
    {
        public string UndreadMsgNr { get; set; }
        public string Name { get; set; }

        public LabelViewModel(Label label)
        {
            Name = label.Name;

            if (label.MessagesUnread.HasValue && label.MessagesUnread.Value != 0)
            {
                UndreadMsgNr = label.MessagesUnread.Value.ToString();
            }
        }
    }
}
