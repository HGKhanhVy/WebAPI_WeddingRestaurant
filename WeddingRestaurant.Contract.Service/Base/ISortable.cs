using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.Login;

namespace WeddingRestaurant.Contract.Service.Base
{
    public interface ISortable<T> where T : class
    {
        List<T> SortOrderByAsyn();
        List<T> SortOrderByDescendingAsyn();
    }
}
