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
using WeddingRestaurant.Core.Models.DichVu;
using WeddingRestaurant.Core.Models.Login;

namespace WeddingRestaurant.Service
{
    [ScopedDependency(ServiceType = typeof(IDichVuService))]
    public class DichVuService : Base.Service, IDichVuService
    {

        private readonly IDichVuRepository _dvRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public DichVuService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _dvRepository = serviceProvider.GetRequiredService<IDichVuRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(DichVuModel model, CancellationToken cancellationToken = default)
        {
            if (_dvRepository.Get(_ => _.MaDichVu == model.MaDichVu && _.DeletedTime == null).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.MaDichVu);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsDichVu.DICHVU_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<DichVuEntity>(model);
            _dvRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.MaDichVu);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _dvRepository.GetTracking(x => x.MaDichVu == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsDichVu.DICHVU_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _dvRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<DichVuEntity> GetAllAsync()
        {
            var entities = _dvRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<DichVuEntity>)entities;
        }

        public DichVuEntity GetByKeyIdAsync(string id)
        {
            var entity = _dvRepository.GetSingle(_ => _.MaDichVu == id && _.DeletedTime == null);
            return entity;
        }

        public Task UpdateAsync(string Id, DichVuModel model, CancellationToken cancellationToken = default)
        {
            var entity = _dvRepository.GetTracking(x => x.MaDichVu == Id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsDichVu.DICHVU_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.MaDichVu != Id)
            {
                var isDuplicate = _dvRepository.GetTracking(x => x.MaDichVu == model.MaDichVu && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsDichVu.DICHVU_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _dvRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            var entities = _dvRepository.Get(_ => _.DeletedTime == null).ToList();
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

        DichVuEntity IGetable<DichVuEntity, string>.GetByLoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public DichVuEntity GetBySDTAsync(string sdt)
        {
            throw new NotImplementedException();
        }
    }
}
