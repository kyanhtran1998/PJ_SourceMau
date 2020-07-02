using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PJ_SourceMau.Models
{
    public class Comment
    {
        public Comment() { }
        public Comment(int cid, string name, string email, string comment, int rating, DateTime datetime, int storeId)
        {
            this.cid = cid;
            this.name = name;
            this.email = email;
            this.comment = comment;
            this.datetime = datetime;
            this.rating = rating;
            this.storeId = storeId;
        }

        public int cid { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui Lòng Nhập Tên")]
        public string name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui Lòng Nhập Email")]
        public string email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Thêm bình luận của bạn")]
        public string comment { get; set; }

        public DateTime datetime { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui Lòng đánh giá cho nhà thuốc")]
        public int rating { get; set; }

        public int storeId { get; set; }

        public static string getTableName() { return "Comments"; }
    }
}
