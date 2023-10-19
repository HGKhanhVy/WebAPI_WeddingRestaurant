using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Contract.Repository.Models
{ 
    [Table("AccessToken")]
    public class AccessTokenEntity : Entity
    {
        [ForeignKey("Token")]
        public string Token { get; set; }
        public virtual TokenEntity? StrToken { get; set; }

        [ForeignKey("NguoiDung")]
        public string userName { get; set; }
        public virtual NguoiDungEntity? NguoiDung { get; set; }
        public bool IsUsed { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime ExpireAt { get; set; }
    }
}
