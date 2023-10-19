using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.Login;

namespace WeddingRestaurant.Contract.Service.Base
{
    public interface IGetable<T, in TKey> where T : class, new()
    {
        ICollection<T> GetAllAsync();
        T GetByKeyIdAsync(TKey keyId);
        T GetBySDTAsync(string sdt);
        T GetByLoginAsync(LoginModel model);
        NguoiDungEntity GetByUserNameAsync(RefreshTokenEntity model);
    }
}
