using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Contract.Repository.Models
{
    [Table("NhanVienTrongTiec")]
    public class NhanVienTrongTiecEntity : Entity
    {
        // Khóa ngoại bảng DatTiec
        public string MaTiec { get; set; }
        public virtual DatTiecEntity DatTiecs { get; set; }

        // Khóa ngoại bảng NhanVien
        public string MaNhanVien { get; set; }
        public virtual NhanVienEntity NhanViens { get; set; }
    }
}
