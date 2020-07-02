using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PJ_SourceMau.Models
{
    public class FeedBack
    {
        public FeedBack() { }
        public FeedBack(int id, string username, string fbName, string fbPhone,string fbEmail,string fbCreatedDate)
        {
            this.fbId = id;
            this.fbName = fbName;
            this.fbContent = fbContent;
            this.fbEmail = fbEmail;
            this.fbPhone = fbPhone;
            this.fbCreatedDate = fbCreatedDate;
        }

        public int fbId { get; set; }
        public string fbName { get; set; }
        public string fbContent { get; set; }
        public string fbEmail { get; set; }
        public string fbPhone { get; set; }
        public string fbCreatedDate { get; set; }
   
        public static string getTableName() { return "FeedBack"; }


    }
}
