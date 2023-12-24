using AutoMapper;
using Invedia.DI.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Interface;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Contract.Service;
using WeddingRestaurant.Contract.Service.Base;
using WeddingRestaurant.Core.Constants;
using WeddingRestaurant.Core.Exceptions;
using WeddingRestaurant.Core.Models.DatTiec;
using WeddingRestaurant.Core.Models.Login;
using WeddingRestaurant.Core.Models.MonAn;

namespace WeddingRestaurant.Service
{
    [ScopedDependency(ServiceType = typeof(IMonAnService))]
    public class MonAnService : Base.Service, IMonAnService
    {

        private readonly IMonAnRepository _monAnRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public MonAnService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _monAnRepository = serviceProvider.GetRequiredService<IMonAnRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(MonAnModel model, CancellationToken cancellationToken = default)
        {
            if (_monAnRepository.Get(_ => _.MaMonAn.Equals(model.MaMonAn) && !_.TrangThai.Equals("Da xoa")).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.MaMonAn);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsMonAn.MONAN_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<MonAnEntity>(model);
            entity.MaMonAn = model.MaMonAn;
            _monAnRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.MaMonAn);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _monAnRepository.GetTracking(x => x.MaMonAn.Equals(id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsMonAn.MONAN_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _monAnRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<MonAnEntity> GetAllAsync()
        {
            var entities = _monAnRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            return (ICollection<MonAnEntity>)entities;
        }

        public MonAnEntity GetByKeyIdAsync(string id)
        {
            var entity = _monAnRepository.GetSingle(_ => _.MaMonAn.Equals(id) && !_.TrangThai.Equals("Da xoa"));
            return entity;
        }

        public Task UpdateAsync(string Id, MonAnModel model, CancellationToken cancellationToken = default)
        {
            var entity = _monAnRepository.GetTracking(x => x.MaMonAn.Equals(Id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsMonAn.MONAN_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.MaMonAn != Id)
            {
                var isDuplicate = _monAnRepository.GetTracking(x => x.MaMonAn.Equals(model.MaMonAn) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsMonAn.MONAN_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _monAnRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            var entities = _monAnRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            int count = 0;
            foreach (var entity in entities)
                count++;
            return Task.FromResult(count);
        }

        public Task<int> CountByKeyIdAsync(int keyId)
        {
            throw new NotImplementedException();
        }

        public DatTiecEntity GetByLoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public NguoiDungEntity GetByUserNameAsync(RefreshTokenEntity model)
        {
            throw new NotImplementedException();
        }

        MonAnEntity IGetable<MonAnEntity, string>.GetByLoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public MonAnEntity GetBySDTAsync(string sdt)
        {
            throw new NotImplementedException();
        }
    }
}
