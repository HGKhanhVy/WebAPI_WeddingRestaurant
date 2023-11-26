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
using WeddingRestaurant.Core.Models.ChiTietDichVuUuDai;

namespace WeddingRestaurant.Service
{
    [ScopedDependency(ServiceType = typeof(IChiTietDichVuUuDaiService))]
    public class ChiTietDichVuUuDaiService : Base.Service, IChiTietDichVuUuDaiService
    {

        private readonly IChiTietDichVuUuDaiRepository _ctdvudRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public ChiTietDichVuUuDaiService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _ctdvudRepository = serviceProvider.GetRequiredService<IChiTietDichVuUuDaiRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<int> CountAsync()
        {
            var entities = _ctdvudRepository.Get(_ => _.TrangThai == null).ToList();
            int count = 0;
            foreach (var entity in entities)
                count++;
            return Task.FromResult(count);
        }

        public Task<string> CreateAsync(ChiTietDichVuUuDaiModel model, CancellationToken cancellationToken = default)
        {
            if (_ctdvudRepository.Get(_ => _.MaTiec.Equals(model.MaTiec) && _.MaDichVuUuDai.Equals(model.MaDichVuUuDai) && _.TrangThai == null).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.MaTiec + " - " + model.MaDichVuUuDai);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsChiTietDichVuUuDai.CHITIETDICHVUUUDAI_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<ChiTietDichVuUuDaiEntity>(model);
            entity.MaTiec = model.MaTiec;
            entity.MaDichVuUuDai = model.MaDichVuUuDai;
            _ctdvudRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.MaTiec + " - " + entity.MaDichVuUuDai);
        }

        public Task DeleteAsync(string id_Tiec, string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _ctdvudRepository.GetTracking(x => x.MaDichVuUuDai.Equals(id) && x.MaTiec.Equals(id_Tiec) && x.TrangThai == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id + " - " + id_Tiec);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsChiTietDichVuUuDai.CHITIETDICHVUUUDAI_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _ctdvudRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<ChiTietDichVuUuDaiEntity> GetAllAsync()
        {
            var entities = _ctdvudRepository.Get(_ => _.TrangThai == null).ToList();
            return (ICollection<ChiTietDichVuUuDaiEntity>)entities;
        }

        public ChiTietDichVuUuDaiEntity GetByKeyIdAsync(string id_Tiec, string id)
        {
            var entity = _ctdvudRepository.GetSingle(_ => _.MaDichVuUuDai.Equals(id) && _.MaTiec.Equals(id_Tiec) && _.TrangThai == null);
            return entity;
        }

        public Task UpdateAsync(string id_Tiec, string Id, ChiTietDichVuUuDaiModel model, CancellationToken cancellationToken = default)
        {
            var entity = _ctdvudRepository.GetTracking(x => x.MaDichVuUuDai.Equals(Id) && x.MaTiec.Equals(id_Tiec) && x.TrangThai == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id + " - " + id_Tiec);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsChiTietDichVuUuDai.CHITIETDICHVUUUDAI_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.MaDichVuUuDai != Id && model.MaTiec != id_Tiec)
            {
                var isDuplicate = _ctdvudRepository.GetTracking(x => x.MaDichVuUuDai.Equals(model.MaDichVuUuDai) && x.MaTiec.Equals(model.MaTiec) && x.TrangThai == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsChiTietDichVuUuDai.CHITIETDICHVUUUDAI_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _ctdvudRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<ChiTietDichVuUuDaiEntity> GetAllByKey1Async(string id)
        {
            var entities = _ctdvudRepository.Get(_ => _.MaTiec.Equals(id)).ToList();
            return (ICollection<ChiTietDichVuUuDaiEntity>)entities;
        }

        public ICollection<ChiTietDichVuUuDaiEntity> GetAllByKey2Async(string id)
        {
            var entities = _ctdvudRepository.Get(_ => _.MaDichVuUuDai.Equals(id)).ToList();
            return (ICollection<ChiTietDichVuUuDaiEntity>)entities;
        }

        // KHÔNG SỬ DỤNG
        public NguoiDungEntity GetByUserNameAsync(RefreshTokenEntity model)
        {
            throw new NotImplementedException();
        }
    }
}
