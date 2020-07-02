using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PJ_SourceMau.Areas.API.Models
{
    public class Member
    {
        public int id { get; set; }
        public int group_id { get; set; }
        public string email { get; set; }
        public Member() { }
        public Member(int id, int group_id, string user_id)
        {
            this.id = id;
            this.group_id = group_id;
            this.email = user_id;
        }
        public static string getTableName() { return "lp_groupuser"; }
    }
}
