using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WeddingRestaurant.Core.Constants.WebApiEndpoint;

namespace WeddingRestaurant.Contract.Repository.Models
{
    [Table("DichVu")]
    public class DichVuEntity : Entity
    {
        public string MaDichVu { get; set; }    
        public string TenDichVu { get; set; }
        public string HinhAnh { get; set; }
        public string? MoTa { get; set; }

        // Khóa ngoại bảng LoaiDichVu
        public string MaLoaiDichVu { get; set; }
        public virtual LoaiDichVuEntity LoaiDichVus { get; set; }
        public string DieuKienApDung { get; set; }
        public double GiaTronGoi { get; set; }
        public double GiaGiam30 { get; set; }
        public double GiaLe { get; set; }

        public virtual ICollection<DichVuTinhPhiEntity>? DichVuTinhPhis { get; set; }
        public virtual ICollection<DichVuUuDaiEntity>? DichVuUuDais { get; set; }
        
    }
}
