using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PJ_SourceMau.Models
{
    public partial class DrugStore
    {
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui Lòng nhập Tên")]
        public string name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui Lòng nhập Địa Chỉ")]
        public string address { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui Lòng nhập Quận")]
        public int district { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui Lòng nhập Số Điện Thoại")]
        [Phone(ErrorMessage = "Vui Lòng Đúng Số Điện Thoại")]
        public string phone { get; set; }

        public string imgSrc { get; set; }
        public int status { get; set; }
        public int categoryId { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui Lòng Nhập giờ mở cửa")]
        public string openTime { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui Lòng Nhập giờ đóng cửa")]

        public string closedTime { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui Lòng Nhập Mô tả Cửa Hàng")]
        public string description { get; set; }
        public int iduser { get; set; }

        public int averageRating { get; set; }
        public DrugStore() { }
        public DrugStore(int ID, string name, string address, int district, string phone, string imgSrc, int status, int categoryId,
            string description, string openTime, string closedTime, int iduser, float lat, float lng, int averageRating)
        {
            this.ID = ID;
            this.name = name;
            this.address = address;
            this.district = district;
            this.phone = phone;
            this.imgSrc = imgSrc;
            this.status = status;
            this.categoryId = categoryId;
            this.description = description;
            this.openTime = openTime;
            this.closedTime = closedTime;
            this.iduser = iduser;
            this.lat = lat;
            this.lng = lng;
            this.averageRating = averageRating;

        }

        public static string getTableName() { return "DrugStore"; }
    }
}
