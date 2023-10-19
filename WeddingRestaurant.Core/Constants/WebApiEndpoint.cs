namespace WeddingRestaurant.Core.Constants
{
    public static class WebApiEndpoint
    {
        public const string AreaName = "api";

        public static class DatTiec
        {
            private const string BaseEndpoint = "~/" + AreaName + "/dat-tiec";
            public const string GetDatTiec = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllDatTiec = BaseEndpoint + "/get-all";
            public const string AddDatTiec = BaseEndpoint + "/add";
            public const string UpdateDatTiec = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteDatTiec = BaseEndpoint + "/delete" + "/{keyId}";
            public const string CountDatTiec = BaseEndpoint + "/count-tiec";
            public const string SortByNgayToChuc = BaseEndpoint + "/sap-xep-ngay-to-chuc";
            public const string SortByDescendingNgayToChuc = BaseEndpoint + "/sap-xep-ngay-to-chuc-giam-dan";
            public const string UpdateStatus = BaseEndpoint + "/update-status";
        }
        public static class MonAn
        {
            private const string BaseEndpoint = "~/" + AreaName + "/mon-an";
            public const string GetMonAn = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllMonAn = BaseEndpoint + "/get-all";
            public const string AddMonAn = BaseEndpoint + "/add";
            public const string UpdateMonAn = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteMonAn = BaseEndpoint + "/delete" + "/{keyId}";
            public const string CountMonAn = BaseEndpoint + "/count-monan" + "/{keyId}";
        }
        public static class Nuoc
        {
            private const string BaseEndpoint = "~/" + AreaName + "/nuoc-uong";
            public const string GetNuoc = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllNuoc = BaseEndpoint + "/get-all";
            public const string AddNuoc = BaseEndpoint + "/add";
            public const string UpdateNuoc = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteNuoc = BaseEndpoint + "/delete" + "/{keyId}";
            public const string CountNuoc = BaseEndpoint + "/count-nuoc" + "/{keyId}";
        }
        public static class Menu
        {
            private const string BaseEndpoint = "~/" + AreaName + "/menu";
            public const string GetMenu = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllMenu = BaseEndpoint + "/get-all";
            public const string AddMenu = BaseEndpoint + "/add";
            public const string UpdateMenu = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteMenu = BaseEndpoint + "/delete" + "/{keyId}";
            public const string CountMenu = BaseEndpoint + "/count-menu" + "/{keyId}";
        }
        public static class KhuyenMai
        {
            private const string BaseEndpoint = "~/" + AreaName + "/khuyen-mai";
            public const string GetKhuyenMai = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllKhuyenMai = BaseEndpoint + "/get-all";
            public const string AddKhuyenMai = BaseEndpoint + "/add";
            public const string UpdateKhuyenMai = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteKhuyenMai = BaseEndpoint + "/delete" + "/{keyId}";
            public const string CountKhuyenMai = BaseEndpoint + "/count-khuyenmai" + "/{keyId}";
        }
        public static class DichVu
        {
            private const string BaseEndpoint = "~/" + AreaName + "/dich-vu";
            public const string GetDichVu = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllDichVu = BaseEndpoint + "/get-all";
            public const string AddDichVu = BaseEndpoint + "/add";
            public const string UpdateDichVu = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteDichVu = BaseEndpoint + "/delete" + "/{keyId}";
            public const string CountDichVu = BaseEndpoint + "/count-dichvu" + "/{keyId}";
        }
        public static class Sanh
        {
            private const string BaseEndpoint = "~/" + AreaName + "/sanh";
            public const string GetSanh = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllSanh = BaseEndpoint + "/get-all";
            public const string AddSanh = BaseEndpoint + "/add";
            public const string UpdateSanh = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteSanh = BaseEndpoint + "/delete" + "/{keyId}";
            public const string CountSanh = BaseEndpoint + "/count-sanh" + "/{keyId}";
            public const string PrintSucChua = BaseEndpoint + "/print-succhua" + "/{keyId}";
        }
        public static class LichSanhTiec
        {
            private const string BaseEndpoint = "~/" + AreaName + "/lich-sanh-tiec";
            public const string GetLichSanhTiec = BaseEndpoint + "/get-single" + "/{MaSanh}-{MaTiec}";
            public const string GetAllLichSanhTiec = BaseEndpoint + "/get-all";
            public const string AddLichSanhTiec = BaseEndpoint + "/add";
            public const string UpdateLichSanhTiec = BaseEndpoint + "/update" + "/{MaSanh}-{MaTiec}";
            public const string DeleteLichSanhTiec = BaseEndpoint + "/delete" + "/{MaSanh}-{MaTiec}";
            public const string CountLichSanhTiec = BaseEndpoint + "/count-lichsanhtiec" + "/{MaSanh}-{MaTiec}";
            public const string PrintAllLichForSanh = BaseEndpoint + "/print-lichsanhtiec-sanh" + "/{MaSanh}";
            public const string PrintAllLichForNgayToChuc = BaseEndpoint + "/print-lichsanhtiec-ngaytochuc" + "/{NgayToChuc}";
            public const string SortByNgayToChuc = BaseEndpoint + "/sap-xep-ngay-to-chuc";
            public const string SortByDescendingNgayToChuc = BaseEndpoint + "/sap-xep-ngay-to-chuc-giam-dan";
        }
        public static class KhachHang
        {
            private const string BaseEndpoint = "~/" + AreaName + "/khach-hang";
            public const string GetKhachHang = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllKhachHang = BaseEndpoint + "/get-all";
            public const string AddKhachHang = BaseEndpoint + "/add";
            public const string UpdateKhachHang = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteKhachHang = BaseEndpoint + "/delete" + "/{keyId}";
            public const string CountKhachHang = BaseEndpoint + "/count-kh" + "/{keyId}";
        }
        public static class LoaiMonAn
        {
            private const string BaseEndpoint = "~/" + AreaName + "/loai-mon-an";
            public const string GetLoaiMonAn = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllLoaiMonAn = BaseEndpoint + "/get-all";
            public const string AddLoaiMonAn = BaseEndpoint + "/add";
            public const string UpdateLoaiMonAn = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteLoaiMonAn = BaseEndpoint + "/delete" + "/{keyId}";
            public const string CountLoaiMonAn = BaseEndpoint + "/count-loaimonan" + "/{keyId}";
        }
        public static class LoaiNuoc
        {
            private const string BaseEndpoint = "~/" + AreaName + "/loai-nuoc";
            public const string GetLoaiNuoc = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllLoaiNuoc = BaseEndpoint + "/get-all";
            public const string AddLoaiNuoc = BaseEndpoint + "/add";
            public const string UpdateLoaiNuoc = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteLoaiNuoc = BaseEndpoint + "/delete" + "/{keyId}";
            public const string CountLoaiNuoc = BaseEndpoint + "/count-loainuoc" + "/{keyId}";
        }
        public static class MonAnTrongMenu
        {
            private const string BaseEndpoint = "~/" + AreaName + "/mon-an-trong-menu";
            public const string GetMonAnTrongMenu = BaseEndpoint + "/get-single" + "/{MaMenu}-{MaMonAn}";
            public const string GetAllMonAnTrongMenu = BaseEndpoint + "/get-all";
            public const string AddMonAnTrongMenu = BaseEndpoint + "/add";
            public const string UpdateMonAnTrongMenu = BaseEndpoint + "/update" + "/{MaMenu}-{MaMonAn}";
            public const string DeleteMonAnTrongMenu = BaseEndpoint + "/delete" + "/{MaMenu}-{MaMonAn}";
            public const string CountMonAnTrongMenu = BaseEndpoint + "/count-monantrongmenu" + "/{MaMenu}-{MaMonAn}";
        }
        public static class SuDungKhuyenMai
        {
            private const string BaseEndpoint = "~/" + AreaName + "/su-dung-khuyen-mai";
            public const string GetSuDungKhuyenMai = BaseEndpoint + "/get-single" + "/{MaKM}-{MaTiec}";
            public const string GetAllSuDungKhuyenMai = BaseEndpoint + "/get-all";
            public const string AddSuDungKhuyenMai = BaseEndpoint + "/add";
            public const string UpdateSuDungKhuyenMai = BaseEndpoint + "/update" + "/{MaKM}-{MaTiec}";
            public const string DeleteSuDungKhuyenMai = BaseEndpoint + "/delete" + "/{MaKM}-{MaTiec}";
            public const string CountSuDungKhuyenMai = BaseEndpoint + "/count-sudungkhuyenmai" + "/{MaKM}-{MaTiec}";
        }
        public static class NguoiDung
        {
            private const string BaseEndpoint = "~/" + AreaName + "/nguoi-dung";
            public const string GetNguoiDung= BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllNguoiDung = BaseEndpoint + "/get-all";
            public const string AddNguoiDung = BaseEndpoint + "/add";
            public const string UpdateNguoiDung = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteNguoiDung = BaseEndpoint + "/delete" + "/{keyId}";
            public const string Login = BaseEndpoint + "/login";
        }

        public static class Token
        {
            private const string BaseEndpoint = "~/" + AreaName + "/token";
            public const string RenewToken = BaseEndpoint + "/renew-token";
        }

        public class ChiTietDichVu
        {
            private const string BaseEndpoint = "~/" + AreaName + "/chi-tiet-dich-vu";
            public const string GetChiTietDichVu = BaseEndpoint + "/get-single" + "/{MaDV}-{MaTiec}";
            public const string GetAllChiTietDichVu = BaseEndpoint + "/get-all";
            public const string AddChiTietDichVu = BaseEndpoint + "/add";
            public const string UpdateChiTietDichVu = BaseEndpoint + "/update" + "/{MaDV}-{MaTiec}";
            public const string DeleteChiTietDichVu = BaseEndpoint + "/delete" + "/{MaDV}-{MaTiec}";
            public const string CountChiTietDichVu = BaseEndpoint + "/count-chitietdichvu" + "/{MaDV}-{MaTiec}";
        }
        public class ChiTietMenu
        {
            private const string BaseEndpoint = "~/" + AreaName + "/chi-tiet-menu";
            public const string GetChiTietMenu = BaseEndpoint + "/get-single" + "/{MaMenu}-{MaTiec}";
            public const string GetAllChiTietMenu = BaseEndpoint + "/get-all";
            public const string AddChiTietMenu = BaseEndpoint + "/add";
            public const string UpdateChiTietMenu = BaseEndpoint + "/update" + "/{MaMenu}-{MaTiec}";
            public const string DeleteChiTietMenu = BaseEndpoint + "/delete" + "/{MaMenu}-{MaTiec}";
            public const string CountChiTietMenu = BaseEndpoint + "/count-chitietmenu" + "/{MaMenu}-{MaTiec}";
        }
        public class ChiTietNuocUong
        {
            private const string BaseEndpoint = "~/" + AreaName + "/chi-tiet-nuoc-uong";
            public const string GetChiTietNuocUong = BaseEndpoint + "/get-single" + "/{MaNuoc}-{MaTiec}";
            public const string GetAllChiTietNuocUong = BaseEndpoint + "/get-all";
            public const string AddChiTietNuocUong = BaseEndpoint + "/add";
            public const string UpdateChiTietNuocUong = BaseEndpoint + "/update" + "/{MaNuoc}-{MaTiec}";
            public const string DeleteChiTietNuocUong = BaseEndpoint + "/delete" + "/{MaNuoc}-{MaTiec}";
            public const string CountChiTietNuocUong = BaseEndpoint + "/count-chitietnuocuong" + "/{MaNuoc}-{MaTiec}";
        }
    }
}