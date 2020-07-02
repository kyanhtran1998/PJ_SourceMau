using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PJ_SourceMau.Models
{
    public class DrugDetails
    {
        public DrugDetails() { }
        public DrugDetails(int id, string drugname, int price, string note, int iddrugstore)
        {
            this.id = id;
            this.drugname = drugname;
            this.price = price;
            this.note = note;
            this.iddrugstore = iddrugstore;
        }

        public int id { get; set; }

        public string drugname { get; set; }

        public int price { get; set; }

        public string note { get; set; }

        public int iddrugstore { get; set; }

        public static string getTableName() { return "DrugDetails"; }




    }
}
