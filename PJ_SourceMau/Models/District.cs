using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PJ_SourceMau.Models
{
    public class District
    {

        public int ID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui Lòng nhập Tên Quận")]
        public string Name { get; set; }

        public District() { }
        public District(int ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }
        public static string getTableName() { return "District"; }

    }
}
