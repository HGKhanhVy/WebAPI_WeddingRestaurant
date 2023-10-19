using Invedia.DI.Attributes;
using Microsoft.Extensions.DependencyInjection;
using WeddingRestaurant.Contract.Repository.Infrastructure;
using WeddingRestaurant.Contract.Service;

namespace WeddingRestaurant.Service
{
    [ScopedDependency(ServiceType = typeof(IBootstrapperService))]
    public class BootstrapperService : Base.Service, IBootstrapperService
    {
        private readonly IBootstrapper _bootstrapper;

        public BootstrapperService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _bootstrapper = serviceProvider.GetRequiredService<IBootstrapper>();
        }

        public async Task InitialAsync(CancellationToken cancellationToken = default)
        {
            await _bootstrapper.InitialAsync(cancellationToken);
        }
    }
}
