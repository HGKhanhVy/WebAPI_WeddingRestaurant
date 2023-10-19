using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;

namespace WeddingRestaurant.Contract.Service.Base
{
    public interface IPrintForLichSanhTiec<T, in TKey, in T2Key> where T : class, new()
    {
        ICollection<T> GetAllLichSanhByIDAsync(TKey id);
        ICollection<T> GetAllLichSanhByNTCAsync(string ntc);
    }
}
