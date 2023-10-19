using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WeddingRestaurant.Contract.Repository.Models
{
    [Table("NguoiDung")]
    public class NguoiDungEntity : Entity
    {
        [Key]
        public string userName { get; set; }
        public string password { get; set; }
        public string quyen { get; set; }
        public string hoTen { get; set; }
        public string sdt { get; set; }
        public string email { get; set; }
    }
}
