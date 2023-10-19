using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Contract.Repository.Models
{
    [Table("SuDungKhuyenMai")]
    public class SuDungKhuyenMaiEntity : Entity
    {
        [ForeignKey("DatTiec")]
        public string MaTiec { get; set; }
        public virtual DatTiecEntity? DatTiecs { get; set; }

        [ForeignKey("KhuyenMai")]
        public string MaKM { get; set; }
        public virtual KhuyenMaiEntity? KhuyenMais { get; set; }

    }
}
