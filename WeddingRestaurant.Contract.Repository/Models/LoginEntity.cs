using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Contract.Repository.Models
{
    [Table("Login")]
    public class LoginEntity : Entity
    {
        [Key]
        public string userName { get; set; }
        public string password { get; set; }
    }
}
