using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PJ_SourceMau.Models
{
    public class DrugCategory
    {   

        public int categoryId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui Lòng nhập loại nhà thuốc")]
        public string categoryName { get; set; }

        public DrugCategory() { }
        public DrugCategory(int categoryId, string categoryName)
        {
            this.categoryId = categoryId;
            this.categoryName = categoryName;
        }
        public static string getTableName() { return "DrugCategory"; }

    }
}
