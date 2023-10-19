namespace WeddingRestaurant.Contract.Service.Base
{
    public interface IDeleteable<in TKey, in T2Key>
    {
        Task DeleteAsync(TKey id, T2Key isPhysical, CancellationToken cancellationToken = default);
    }
}
