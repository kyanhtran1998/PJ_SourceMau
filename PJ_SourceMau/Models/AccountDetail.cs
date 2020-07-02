using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PJ_SourceMau.Models
{
    public class AccountDetail
    {
        public AccountDetail() { }
        public AccountDetail(int id, string name, string email, string phone, string address, int iduser)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.phone = phone;
            this.address = address;
            this.iduser = iduser;
        }

        public int id { get; set; }
        public string name { get; set; }

        public string email { get; set; }

        public string phone { get; set; }

        public string address { get; set; }

        public int iduser { get; set; }

        public static string getTableName() { return "AccountDetail"; }
    }
}
