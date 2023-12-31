﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WeddingRestaurant.Core.Constants.WebApiEndpoint;

namespace WeddingRestaurant.Contract.Repository.Models
{
    [Table("DichVuUuDai")]
    public class DichVuUuDaiEntity : Entity
    {
        public string MaDichVuUuDai { get; set; }
        public string TenDichVu { get; set; }
        public int DieuKienBanToiThieu { get; set; }
        public int DieuKienBanToiDa { get; set; }
        public string? MoTa { get; set; }
        public string? HinhAnh { get; set; }

        // Khóa ngoại bảng DichVu
        public string MaDichVu { get; set; }
        public virtual DichVuEntity DichVus { get; set; }

        public virtual ICollection<ChiTietDichVuUuDaiEntity>? ChiTietDichVuUuDais { get; set; }

    }
}
