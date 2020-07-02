using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PJ_SourceMau.Models
{
    public class Account
    {
        public Account() { }
        public Account(int id, string username, string password, int groupId)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.groupId = groupId;
        }

        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }


        public int groupId { get; set; }

        public static string getTableName() { return "Account"; }


    }
}
