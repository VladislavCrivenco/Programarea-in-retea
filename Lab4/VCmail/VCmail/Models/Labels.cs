using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCmail.Models
{
    public enum LabelsName
    {
        INBOX,
        SENT,
        DRAFT,
        TRASH,
        SPAM,
        UNREAD,
    };

    public class Labels
    {
        public static List<Label> GetList()
        {
            // Define parameters of request.
            var request = MailService.GetInstance().Users.Labels.List("me");

            // List labels.
            var allLabels = request.Execute().Labels;

            var selectedLabels = allLabels.Where((x) => Enum.TryParse<LabelsName>(x.Name, out var val));

            var finalList = new List<Label>();
            foreach(var label in selectedLabels)
            {
                finalList.Add(Get(label.Id));
            }

            return finalList;
        }

        public static Label Get(string labelId)
        {
            return MailService.GetInstance().Users.Labels.Get("me", labelId).Execute();
        }
    }
}
