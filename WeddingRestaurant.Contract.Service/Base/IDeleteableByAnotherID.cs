using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Contract.Service.Base
{
    internal interface IDeleteableByAnotherID
    {
    }
    public interface IDeleteableByAnotherID<in TKey, in T2Key>
    {
        Task DeleteByAnotherIDAsync(TKey id, T2Key isPhysical, CancellationToken cancellationToken = default);
    }
}
