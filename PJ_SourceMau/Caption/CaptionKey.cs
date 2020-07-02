
namespace PJ_SourceMau.Caption
{
    public class CaptionKey
    {
        public static string Language = "vi";
        public static string HomeMenu => (Language.Equals("en")) ? "Home" : "Trang chủ";
        public static string ChiTietThongBao => (Language.Equals("en")) ? "New Detail" : "Chi tiết thông báo";
        public static string DanhSachThongBao => (Language.Equals("en")) ? "List News" : "Danh sách thông báo";
        public static string TatCaThongBao => (Language.Equals("en")) ? "All News" : "Danh sách Thông báo";
        public static string DeleteConfirm =>
            (Language.Equals("en")) ? "Confirm to Deleta data!" : "Xác nhận xóa dữ liệu!";
        public static string Cancel =>
            (Language.Equals("en")) ? "Cancel" : "Hủy bỏ";
        public static string OK =>
            (Language.Equals("en")) ? "OK" : "Đồng ý";
        public static string Add =>
            (Language.Equals("en")) ? "Add" : "Tạo mới";
        public static string Update =>
            (Language.Equals("en")) ? "Update" : "Cập nhật";
        public static string TenChuDe =>
            (Language.Equals("en")) ? "Category Name" : "Tên chủ đề";
        public static string QuanLyChuDe =>
            (Language.Equals("en")) ? "Category Name" : "Quản lý chủ đề";
        public static string STT =>
            (Language.Equals("en")) ? "No" : "STT";
        public const string EmptyError = "Dữ liệu này không được để trống!";

        #region Admin
        public static string AdminMenu => (Language.Equals("en")) ? "Administrator" : "Quản trị viên";
        public static string GroupMenu => (Language.Equals("en")) ? "Group management" : "Quản lý nhóm";
        public static string ListDrugCategory => (Language.Equals("en")) ? "Drug Store Category management " : "Quản lý Loại Nhà Thuốc";
        public static string ListDrugStore => (Language.Equals("en")) ? "Drug Store management  " : "Quản lý  Nhà Thuốc";
        public static string ListComment => (Language.Equals("en")) ? "Drug Store comment management  " : "Quản lý Bình Luận Nhà Thuốc";
        public static string AddDrugStore => (Language.Equals("en")) ? "Add Drug Store " : "Thêm mới Nhà Thuốc";
        public static string UpdateDrugStore => (Language.Equals("en")) ? "Updatae Drug Store " : "Cập nhật Nhà Thuốc";

        public static string ListAccount => (Language.Equals("en")) ? " Account management  " : "Quản lý  tài khoản";
        public static string DetailAccount => (Language.Equals("en")) ? " Detail Account " : " Thông Tin Chi tiết tài khoản";

        public static string ListDrugDetailStore => (Language.Equals("en")) ? "Drug Store management  " : "Chi tiết  Nhà Thuốc";

        public static string GroupMenuSubper => (Language.Equals("en")) ? "Subper Group management" : "SP quản lý nhóm";
        public static string AddGroupForm => (Language.Equals("en")) ? "Add group" : "Thêm nhóm";
        public static string EditGroupForm => (Language.Equals("en")) ? "Edit group" : "Cập nhật nhóm";
        public static string MemberofGroupForm => (Language.Equals("en")) ? "Members" : "Thành viên";
        public static string PermissionofGroupForm => (Language.Equals("en")) ? "Members" : "Thành viên";
        public static string FunctionForm => (Language.Equals("en")) ? "Function" : "Chức năng";
        public static string AddFunctionForm => (Language.Equals("en")) ? "Add function" : "Thêm chức năng";
        public static string EditFunctionForm => (Language.Equals("en")) ? "Edit function" : "Cập nhật chức năng";
        public static string AddDrugCategoryForm => (Language.Equals("en")) ? "Add Loại Nhà Thuốc function" : "Add Loại Nhà Thuốc";
        public static string EditDrugCategoryForm => (Language.Equals("en")) ? "Edit Loại Nhà Thuốc function" : "Edit Loại Nhà Thuốc";

        #endregion
    }
}
