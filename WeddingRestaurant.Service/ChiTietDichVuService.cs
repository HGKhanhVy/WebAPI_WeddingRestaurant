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
using WeddingRestaurant.Core.Constants;
using WeddingRestaurant.Core.Exceptions;
using WeddingRestaurant.Core.Models.ChiTietDichVu;
using WeddingRestaurant.Core.Models.Login;

namespace WeddingRestaurant.Service
{
    [ScopedDependency(ServiceType = typeof(IChiTietDichVuService))]
    public class ChiTietDichVuService : Base.Service, IChiTietDichVuService
    {

        private readonly IChiTietDichVuRepository _ctdvRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public ChiTietDichVuService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _ctdvRepository = serviceProvider.GetRequiredService<IChiTietDichVuRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<int> CountAsync()
        {
            var entities = _ctdvRepository.Get(_ => _.DeletedTime == null).ToList();
            int count = 0;
            foreach (var entity in entities)
                count++;
            return Task.FromResult(count);
        }

        public Task<string> CreateAsync(ChiTietDichVuModel model, CancellationToken cancellationToken = default)
        {
            if (_ctdvRepository.Get(_ => _.MaDichVu == model.MaDichVu && _.MaTiec == model.MaTiec && _.DeletedTime == null).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.MaDichVu);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsChiTietDichVu.CHITIETDICHVU_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<ChiTietDichVuEntity>(model);
            _ctdvRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.MaTiec + " - " + entity.MaDichVu);
        }

        public Task DeleteAsync(string id, string id_Tiec, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _ctdvRepository.GetTracking(x => x.MaDichVu == id && x.MaTiec == id_Tiec && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsChiTietDichVu.CHITIETDICHVU_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _ctdvRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<ChiTietDichVuEntity> GetAllAsync()
        {
            var entities = _ctdvRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<ChiTietDichVuEntity>)entities;
        }

        public ChiTietDichVuEntity GetByKeyIdAsync(string id, string id_Tiec)
        {
            var entity = _ctdvRepository.GetSingle(_ => _.MaDichVu == id && _.MaTiec == id_Tiec && _.DeletedTime == null);
            return entity;
        }

        public Task UpdateAsync(string Id, string id_Tiec, ChiTietDichVuModel model, CancellationToken cancellationToken = default)
        {
            var entity = _ctdvRepository.GetTracking(x => x.MaDichVu == Id && x.MaTiec == id_Tiec && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsChiTietDichVu.CHITIETDICHVU_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.MaDichVu != Id && model.MaTiec != id_Tiec)
            {
                var isDuplicate = _ctdvRepository.GetTracking(x => x.MaDichVu == model.MaDichVu && x.MaTiec == model.MaTiec && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsChiTietDichVu.CHITIETDICHVU_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _ctdvRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        // KHÔNG SỬ DỤNG
        public NguoiDungEntity GetByUserNameAsync(RefreshTokenEntity model)
        {
            throw new NotImplementedException();
        }
    }
}
