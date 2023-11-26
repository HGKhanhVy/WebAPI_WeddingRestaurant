using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Contract.Repository.Models
{
    [Table("Token")]
    public class TokenEntity : Entity
    {
        [Key]
        public string IDToken { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public virtual ICollection<RefreshTokenEntity>? RefreshTokens { get; set; }
    }
}
