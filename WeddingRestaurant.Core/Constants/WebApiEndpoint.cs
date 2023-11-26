namespace WeddingRestaurant.Core.Constants
{
    public static class WebApiEndpoint
    {
        public const string AreaName = "api";

        public static class ChiTietDichVuTinhPhi
        {
            private const string BaseEndpoint = "~/" + AreaName + "/chi-tiet-dv-tinh-phi";
            public const string GetChiTietDichVuTinhPhi = BaseEndpoint + "/get-single" + "/{MaTiec}-{MaDichVuTinhPhi}";
            public const string GetAllChiTietDichVuTinhPhi = BaseEndpoint + "/get-all";
            public const string AddChiTietDichVuTinhPhi = BaseEndpoint + "/add";
            public const string UpdateChiTietDichVuTinhPhi = BaseEndpoint + "/update" + "/{MaTiec}-{MaDichVuTinhPhi}";
            public const string DeleteChiTietDichVuTinhPhi = BaseEndpoint + "/delete" + "/{MaTiec}-{MaDichVuTinhPhi}";
            public const string PrintAllChiTietDichVuTinhPhiForTiec = BaseEndpoint + "/print-ctdvtinhphi-tiec" + "/{MaTiec}";
            public const string PrintAllChiTietDichVuTinhPhiForDVTP = BaseEndpoint + "/print-ctdvtinhphi-dvtinhphi" + "/{MaDichVuTinhPhi}";
            public const string CountChiTietDichVuTinhPhi = BaseEndpoint + "/count-chi-tiet-dv-tinh-phi";
        }

        public static class ChiTietDichVuUuDai
        {
            private const string BaseEndpoint = "~/" + AreaName + "/chi-tiet-dv-uu-dai";
            public const string GetChiTietDichVuUuDai = BaseEndpoint + "/get-single" + "/{MaTiec}-{MaDichVuUuDai}";
            public const string GetAllChiTietDichVuUuDai = BaseEndpoint + "/get-all";
            public const string AddChiTietDichVuUuDai = BaseEndpoint + "/add";
            public const string UpdateChiTietDichVuUuDai = BaseEndpoint + "/update" + "/{MaTiec}-{MaDichVuUuDai}";
            public const string DeleteChiTietDichVuUuDai = BaseEndpoint + "/delete" + "/{MaTiec}-{MaDichVuUuDai}";
            public const string PrintAllChiTietDichVuUuDaiForTiec = BaseEndpoint + "/print-ctdvuudai-tiec" + "/{MaTiec}";
            public const string PrintAllChiTietDichVuUuDaiForDVUD = BaseEndpoint + "/print-ctdvuudai-dvuudai" + "/{MaDichVuUuDai}";
            public const string CountChiTietDichVuUuDai = BaseEndpoint + "/count-chi-tiet-dv-uu-dai";
        }

        public class ChiTietMenu
        {
            private const string BaseEndpoint = "~/" + AreaName + "/chi-tiet-menu";
            public const string GetChiTietMenu = BaseEndpoint + "/get-single" + "/{MaMenu}-{MaTiec}";
            public const string GetAllChiTietMenu = BaseEndpoint + "/get-all";
            public const string AddChiTietMenu = BaseEndpoint + "/add";
            public const string UpdateChiTietMenu = BaseEndpoint + "/update" + "/{MaMenu}-{MaTiec}";
            public const string DeleteChiTietMenu = BaseEndpoint + "/delete" + "/{MaMenu}-{MaTiec}";
            public const string PrintAllChiTietMenuForTiec = BaseEndpoint + "/print-ctmenu-tiec" + "/{MaTiec}";
            public const string PrintAllChiTietMenuForMenu = BaseEndpoint + "/print-ctmenu-menu" + "/{MaMenu}";
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
            public const string PrintAllChiTietNuocForTiec = BaseEndpoint + "/print-ctnuoc-tiec" + "/{MaTiec}";
            public const string PrintAllChiTietNuocForNuoc = BaseEndpoint + "/print-ctnuoc-nuoc" + "/{MaNuoc}";
            public const string CountChiTietNuocUong = BaseEndpoint + "/count-chitietnuocuong" + "/{MaNuoc}-{MaTiec}";
        }

        public class ChiTietPhuThuDichVu
        {
            private const string BaseEndpoint = "~/" + AreaName + "/chi-tiet-phu-thu-dich-vu";
            public const string GetChiTietPhuThuDichVu = BaseEndpoint + "/get-single" + "/{MaPhuThu}-{MaDichVuTinhPhi}";
            public const string GetAllChiTietPhuThuDichVu = BaseEndpoint + "/get-all";
            public const string AddChiTietPhuThuDichVu = BaseEndpoint + "/add";
            public const string UpdateChiTietPhuThuDichVu = BaseEndpoint + "/update" + "/{MaPhuThu}-{MaDichVuTinhPhi}";
            public const string DeleteChiTietPhuThuDichVu = BaseEndpoint + "/delete" + "/{MaPhuThu}-{MaDichVuTinhPhi}";
            public const string PrintAllChiTietPhuThuDichVuForPhuThu = BaseEndpoint + "/print-ctphuthudv-phuthu" + "/{MaPhuThu}";
            public const string PrintAllChiTietPhuThuDichVuForDVTP = BaseEndpoint + "/print-ctphuthudv-dichvutinhphi" + "/{MaDichVuTinhPhi}";
            public const string CountChiTietPhuThuDichVu = BaseEndpoint + "/count-chitietphuthudv" + "/{MaPhuThu}-{MaDichVuTinhPhi}";
        }

        public class ChiTietPhuThuMonAn
        {
            private const string BaseEndpoint = "~/" + AreaName + "/chi-tiet-phu-thu-mon-an";
            public const string GetChiTietPhuThuMonAn = BaseEndpoint + "/get-single" + "/{MaPhuThu}-{MaMonAn}";
            public const string GetAllChiTietPhuThuMonAn = BaseEndpoint + "/get-all";
            public const string AddChiTietPhuThuMonAn = BaseEndpoint + "/add";
            public const string UpdateChiTietPhuThuMonAn = BaseEndpoint + "/update" + "/{MaPhuThu}-{MaMonAn}";
            public const string DeleteChiTietPhuThuMonAn = BaseEndpoint + "/delete" + "/{MaPhuThu}-{MaMonAn}";
            public const string PrintAllChiTietPhuThuMonAnForPhuThu = BaseEndpoint + "/print-ctphuthuma-phuthu" + "/{MaPhuThu}";
            public const string PrintAllChiTietPhuThuMonAnForMonAn = BaseEndpoint + "/print-ctphuthuma-monan" + "/{MaMonAn}";
            public const string CountChiTietPhuThuMonAn = BaseEndpoint + "/count-chitietnuocuong" + "/{MaPhuThu}-{MaMonAn}";
        }

        public class ChiTietPhuThuNuoc
        {
            private const string BaseEndpoint = "~/" + AreaName + "/chi-tiet-phu-thu-nuoc";
            public const string GetChiTietPhuThuNuoc = BaseEndpoint + "/get-single" + "/{MaPhuThu}-{MaNuoc}";
            public const string GetAllChiTietPhuThuNuoc = BaseEndpoint + "/get-all";
            public const string AddChiTietPhuThuNuoc = BaseEndpoint + "/add";
            public const string UpdateChiTietPhuThuNuoc = BaseEndpoint + "/update" + "/{MaPhuThu}-{MaNuoc}";
            public const string DeleteChiTietPhuThuNuoc = BaseEndpoint + "/delete" + "/{MaPhuThu}-{MaNuoc}";
            public const string PrintAllChiTietPhuThuNuocForPhuThu = BaseEndpoint + "/print-ctphuthunuoc-phuthu" + "/{MaPhuThu}";
            public const string PrintAllChiTietPhuThuNuocForNuoc = BaseEndpoint + "/print-ctphuthunuoc-nuoc" + "/{MaNuoc}";
            public const string CountChiTietPhuThuNuoc = BaseEndpoint + "/count-chitietphuthunuoc" + "/{MaPhuThu}-{MaNuoc}";
        }

        public static class DatTiec
        {
            private const string BaseEndpoint = "~/" + AreaName + "/dat-tiec";
            public const string GetDatTiec = BaseEndpoint + "/get-single" + "/{MaTiec}";
            public const string GetAllDatTiec = BaseEndpoint + "/get-all";
            public const string AddDatTiec = BaseEndpoint + "/add";
            public const string UpdateDatTiec = BaseEndpoint + "/update" + "/{MaTiec}";
            public const string DeleteDatTiec = BaseEndpoint + "/delete" + "/{MaTiec}";
            public const string CountDatTiec = BaseEndpoint + "/count-tiec";
            public const string SortByNgayToChuc = BaseEndpoint + "/sap-xep-ngay-to-chuc";
            public const string SortByDescendingNgayToChuc = BaseEndpoint + "/sap-xep-ngay-to-chuc-giam-dan";
            public const string UpdateStatus = BaseEndpoint + "/update-status";
        }

        public static class DichVu
        {
            private const string BaseEndpoint = "~/" + AreaName + "/dich-vu";
            public const string GetDichVu = BaseEndpoint + "/get-single" + "/{MaDichVu}";
            public const string GetAllDichVu = BaseEndpoint + "/get-all";
            public const string AddDichVu = BaseEndpoint + "/add";
            public const string UpdateDichVu = BaseEndpoint + "/update" + "/{MaDichVu}";
            public const string DeleteDichVu = BaseEndpoint + "/delete" + "/{MaDichVu}";
            public const string CountDichVu = BaseEndpoint + "/count-dichvu" + "/{MaDichVu}";
        }

        public static class DichVuTinhPhi
        {
            private const string BaseEndpoint = "~/" + AreaName + "/dich-vu-tinh-phi";
            public const string GetDichVuTinhPhi = BaseEndpoint + "/get-single" + "/{MaDichVuTinhPhi}";
            public const string GetAllDichVuTinhPhi = BaseEndpoint + "/get-all";
            public const string AddDichVuTinhPhi = BaseEndpoint + "/add";
            public const string UpdateDichVuTinhPhi = BaseEndpoint + "/update" + "/{MaDichVuTinhPhi}";
            public const string DeleteDichVuTinhPhi = BaseEndpoint + "/delete" + "/{MaDichVuTinhPhi}";
            public const string CountDichVuTinhPhi = BaseEndpoint + "/count-dichvu-tinhphi" + "/{MaDichVuTinhPhi}";
        }

        public static class DichVuUuDai
        {
            private const string BaseEndpoint = "~/" + AreaName + "/dich-vu-uu-dai";
            public const string GetDichVuUuDai = BaseEndpoint + "/get-single" + "/{MaDichVuUuDai}";
            public const string GetAllDichVuUuDai = BaseEndpoint + "/get-all";
            public const string AddDichVuUuDai = BaseEndpoint + "/add";
            public const string UpdateDichVuUuDai = BaseEndpoint + "/update" + "/{MaDichVuUuDai}";
            public const string DeleteDichVuUuDai = BaseEndpoint + "/delete" + "/{MaDichVuUuDai}";
            public const string CountDichVuUuDai = BaseEndpoint + "/count-dichvu-uudai" + "/{MaDichVuUuDai}";
        }

        public static class HoaDon
        {
            private const string BaseEndpoint = "~/" + AreaName + "/hoa-don";
            public const string GetHoaDon = BaseEndpoint + "/get-single" + "/{MaHoaDon}";
            public const string GetAllHoaDon = BaseEndpoint + "/get-all";
            public const string AddHoaDon = BaseEndpoint + "/add";
            public const string UpdateHoaDon = BaseEndpoint + "/update" + "/{MaHoaDon}";
            public const string DeleteHoaDon = BaseEndpoint + "/delete" + "/{MaHoaDon}";
            public const string CountHoaDon = BaseEndpoint + "/count-hoadon" + "/{MaHoaDon}";
        }

        public static class KhachHang
        {
            private const string BaseEndpoint = "~/" + AreaName + "/khach-hang";
            public const string GetKhachHang = BaseEndpoint + "/get-single" + "/{MaKhachHang}";
            public const string GetKhachHangBySDT = BaseEndpoint + "/get-single" + "/{SDT}";
            public const string GetAllKhachHang = BaseEndpoint + "/get-all";
            public const string AddKhachHang = BaseEndpoint + "/add";
            public const string UpdateKhachHang = BaseEndpoint + "/update" + "/{MaKhachHang}";
            public const string DeleteKhachHang = BaseEndpoint + "/delete" + "/{MaKhachHang}";
            public const string CountKhachHang = BaseEndpoint + "/count-kh" + "/{MaKhachHang}";
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

        public static class LoaiDichVu
        {
            private const string BaseEndpoint = "~/" + AreaName + "/loai-dich-vu";
            public const string GetLoaiDichVu = BaseEndpoint + "/get-single" + "/{MaLoaiDichVu}";
            public const string GetAllLoaiDichVu = BaseEndpoint + "/get-all";
            public const string AddLoaiDichVu = BaseEndpoint + "/add";
            public const string UpdateLoaiDichVu = BaseEndpoint + "/update" + "/{MaLoaiDichVu}";
            public const string DeleteLoaiDichVu = BaseEndpoint + "/delete" + "/{MaLoaiDichVu}";
            public const string CountLoaiDichVu = BaseEndpoint + "/count-loaidv" + "/{MaLoaiDichVu}";
        }

        public static class LoaiMonAn
        {
            private const string BaseEndpoint = "~/" + AreaName + "/loai-mon-an";
            public const string GetLoaiMonAn = BaseEndpoint + "/get-single" + "/{MaLoaiMonAn}";
            public const string GetAllLoaiMonAn = BaseEndpoint + "/get-all";
            public const string AddLoaiMonAn = BaseEndpoint + "/add";
            public const string UpdateLoaiMonAn = BaseEndpoint + "/update" + "/{MaLoaiMonAn}";
            public const string DeleteLoaiMonAn = BaseEndpoint + "/delete" + "/{MaLoaiMonAn}";
            public const string CountLoaiMonAn = BaseEndpoint + "/count-loaimonan" + "/{MaLoaiMonAn}";
        }

        public static class LoaiNuoc
        {
            private const string BaseEndpoint = "~/" + AreaName + "/loai-nuoc";
            public const string GetLoaiNuoc = BaseEndpoint + "/get-single" + "/{MaLoaiNuoc}";
            public const string GetAllLoaiNuoc = BaseEndpoint + "/get-all";
            public const string AddLoaiNuoc = BaseEndpoint + "/add";
            public const string UpdateLoaiNuoc = BaseEndpoint + "/update" + "/{MaLoaiNuoc}";
            public const string DeleteLoaiNuoc = BaseEndpoint + "/delete" + "/{MaLoaiNuoc}";
            public const string CountLoaiNuoc = BaseEndpoint + "/count-loainuoc" + "/{MaLoaiNuoc}";
        }

        public static class Menu
        {
            private const string BaseEndpoint = "~/" + AreaName + "/menu";
            public const string GetMenu = BaseEndpoint + "/get-single" + "/{MaMenu}";
            public const string GetAllMenu = BaseEndpoint + "/get-all";
            public const string AddMenu = BaseEndpoint + "/add";
            public const string UpdateMenu = BaseEndpoint + "/update" + "/{MaMenu}";
            public const string DeleteMenu = BaseEndpoint + "/delete" + "/{MaMenu}";
            public const string CountMenu = BaseEndpoint + "/count-menu" + "/{MaMenu}";
        }

        public static class MonAn
        {
            private const string BaseEndpoint = "~/" + AreaName + "/mon-an";
            public const string GetMonAn = BaseEndpoint + "/get-single" + "/{MaMonAn}";
            public const string GetAllMonAn = BaseEndpoint + "/get-all";
            public const string AddMonAn = BaseEndpoint + "/add";
            public const string UpdateMonAn = BaseEndpoint + "/update" + "/{MaMonAn}";
            public const string DeleteMonAn = BaseEndpoint + "/delete" + "/{MaMonAn}";
            public const string CountMonAn = BaseEndpoint + "/count-monan" + "/{MaMonAn}";
        }

        public static class MonAnTrongMenu
        {
            private const string BaseEndpoint = "~/" + AreaName + "/mon-an-trong-menu";
            public const string GetMonAnTrongMenu = BaseEndpoint + "/get-single" + "/{MaMenu}-{MaMonAn}";
            public const string GetAllMonAnTrongMenu = BaseEndpoint + "/get-all";
            public const string AddMonAnTrongMenu = BaseEndpoint + "/add";
            public const string UpdateMonAnTrongMenu = BaseEndpoint + "/update" + "/{MaMenu}-{MaMonAn}";
            public const string DeleteMonAnTrongMenu = BaseEndpoint + "/delete" + "/{MaMenu}-{MaMonAn}";
            public const string PrintAllMonAnTrongMenuForMonAn = BaseEndpoint + "/print-monantrongmenu-monan" + "/{MaMonAn}";
            public const string PrintAllMonAnTrongMenuForMenu = BaseEndpoint + "/print-monantrongmenu-menu" + "/{MaMenu}";
            public const string CountMonAnTrongMenu = BaseEndpoint + "/count-monantrongmenu" + "/{MaMenu}-{MaMonAn}";
        }

        public static class Nuoc
        {
            private const string BaseEndpoint = "~/" + AreaName + "/nuoc-uong";
            public const string GetNuoc = BaseEndpoint + "/get-single" + "/{MaNuoc}";
            public const string GetAllNuoc = BaseEndpoint + "/get-all";
            public const string AddNuoc = BaseEndpoint + "/add";
            public const string UpdateNuoc = BaseEndpoint + "/update" + "/{MaNuoc}";
            public const string DeleteNuoc = BaseEndpoint + "/delete" + "/{MaNuoc}";
            public const string CountNuoc = BaseEndpoint + "/count-nuoc" + "/{MaNuoc}";
        }

        public static class NguoiDung
        {
            private const string BaseEndpoint = "~/" + AreaName + "/nguoi-dung";
            public const string GetNguoiDung = BaseEndpoint + "/get-single" + "/{userName}";
            public const string GetAllNguoiDung = BaseEndpoint + "/get-all";
            public const string AddNguoiDung = BaseEndpoint + "/add";
            public const string UpdateNguoiDung = BaseEndpoint + "/update" + "/{userName}";
            public const string DeleteNguoiDung = BaseEndpoint + "/delete" + "/{userName}";
            public const string Login = BaseEndpoint + "/login";
        }

        public static class NhanVien
        {
            private const string BaseEndpoint = "~/" + AreaName + "/nhan-vien";
            public const string GetNhanVien = BaseEndpoint + "/get-single" + "/{MaNhanVien}";
            public const string GetAllNhanVien = BaseEndpoint + "/get-all";
            public const string AddNhanVien = BaseEndpoint + "/add";
            public const string UpdateNhanVien = BaseEndpoint + "/update" + "/{MaNhanVien}";
            public const string DeleteNhanVien = BaseEndpoint + "/delete" + "/{MaNhanVien}";
            public const string CountNhanVien = BaseEndpoint + "/count-nhan-vien" + "/{MaNhanVien}";
        }

        public static class NhanVienTrongTiec
        {
            private const string BaseEndpoint = "~/" + AreaName + "/nhan-vien-trong-tiec";
            public const string GetNhanVienTrongTiec = BaseEndpoint + "/get-single" + "/{MaTiec}-{MaNhanVien}";
            public const string GetAllNhanVienTrongTiec = BaseEndpoint + "/get-all";
            public const string AddNhanVienTrongTiec = BaseEndpoint + "/add";
            public const string UpdateNhanVienTrongTiec = BaseEndpoint + "/update" + "/{MaTiec}-{MaNhanVien}";
            public const string DeleteNhanVienTrongTiec = BaseEndpoint + "/delete" + "/{MaTiec}-{MaNhanVien}";
            public const string PrintAllNhanVienTrongTiecForTiec = BaseEndpoint + "/print-nvtrongtiec-tiec" + "/{MaTiec}";
            public const string PrintAllNhanVienTrongTiecForNhanVien = BaseEndpoint + "/print-nvtrongtiec-nhanvien" + "/{MaNhanVien}";
            public const string CountNhanVienTrongTiec = BaseEndpoint + "/count-nhanvien-trongtiec" + "/{MaTiec}-{MaNhanVien}";
        }

        public static class PhuThu
        {
            private const string BaseEndpoint = "~/" + AreaName + "/phu-thu";
            public const string GetPhuThu = BaseEndpoint + "/get-single" + "/{MaPhuThu}";
            public const string GetAllPhuThu = BaseEndpoint + "/get-all";
            public const string AddPhuThu = BaseEndpoint + "/add";
            public const string UpdatePhuThu = BaseEndpoint + "/update" + "/{MaPhuThu}";
            public const string DeletePhuThu = BaseEndpoint + "/delete" + "/{MaPhuThu}";
            public const string CountPhuThu = BaseEndpoint + "/count-phu-thu" + "/{MaPhuThu}";
        }

        public static class Sanh
        {
            private const string BaseEndpoint = "~/" + AreaName + "/sanh";
            public const string GetSanh = BaseEndpoint + "/get-single" + "/{MaSanh}";
            public const string GetAllSanh = BaseEndpoint + "/get-all";
            public const string AddSanh = BaseEndpoint + "/add";
            public const string UpdateSanh = BaseEndpoint + "/update" + "/{MaSanh}";
            public const string DeleteSanh = BaseEndpoint + "/delete" + "/{MaSanh}";
            public const string CountSanh = BaseEndpoint + "/count-sanh" + "/{MaSanh}";
            public const string PrintSucChua = BaseEndpoint + "/print-succhua" + "/{MaSanh}";
        }

        public static class Token
        {
            private const string BaseEndpoint = "~/" + AreaName + "/token";
            public const string RenewToken = BaseEndpoint + "/renew-token";
        }
    }
}