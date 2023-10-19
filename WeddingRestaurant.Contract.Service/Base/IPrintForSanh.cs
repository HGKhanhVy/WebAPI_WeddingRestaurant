using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Core.Models.LichSanhTiec;

namespace WeddingRestaurant.Contract.Service.Base
{
    public interface IPrintForSanh<in T, TKey> where T : class, new()
    {
        string PrintSucChuaAsync(TKey id);
    }
}
