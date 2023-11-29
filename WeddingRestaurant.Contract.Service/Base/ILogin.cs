using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Contract.Service.Base
{
    public interface ILogin<T, in TKey, in T2Key> where T : class, new()
    {
        T KhachHangLogin(TKey sdt, T2Key mk);
    }
}
