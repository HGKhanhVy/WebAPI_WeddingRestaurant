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
using WeddingRestaurant.Core.Models.KhuyenMai;
using WeddingRestaurant.Core.Models.Login;

namespace WeddingRestaurant.Service
{
    [ScopedDependency(ServiceType = typeof(IKhuyenMaiService))]
    public class KhuyenMaiService : Base.Service, IKhuyenMaiService
    {

        private readonly IKhuyenMaiRepository _kmRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public KhuyenMaiService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _kmRepository = serviceProvider.GetRequiredService<IKhuyenMaiRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(KhuyenMaiModel model, CancellationToken cancellationToken = default)
        {
            if (_kmRepository.Get(_ => _.MaKM == model.MaKM && _.DeletedTime == null).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.MaKM);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsKhuyenMai.KHUYENMAI_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<KhuyenMaiEntity>(model);
            _kmRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.MaKM);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _kmRepository.GetTracking(x => x.MaKM == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsKhuyenMai.KHUYENMAI_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _kmRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<KhuyenMaiEntity> GetAllAsync()
        {
            var entities = _kmRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<KhuyenMaiEntity>)entities;
        }

        public KhuyenMaiEntity GetByKeyIdAsync(string id)
        {
            var entity = _kmRepository.GetSingle(_ => _.MaKM == id && _.DeletedTime == null);
            return entity;
        }

        public Task UpdateAsync(string Id, KhuyenMaiModel model, CancellationToken cancellationToken = default)
        {
            var entity = _kmRepository.GetTracking(x => x.MaKM == Id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsKhuyenMai.KHUYENMAI_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.MaKM != Id)
            {
                var isDuplicate = _kmRepository.GetTracking(x => x.MaKM == model.MaKM && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsKhuyenMai.KHUYENMAI_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _kmRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            var entities = _kmRepository.Get(_ => _.DeletedTime == null).ToList();
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

        KhuyenMaiEntity IGetable<KhuyenMaiEntity, string>.GetByLoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public KhuyenMaiEntity GetBySDTAsync(string sdt)
        {
            throw new NotImplementedException();
        }
    }
}
