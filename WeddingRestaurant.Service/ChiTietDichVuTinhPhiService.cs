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
using WeddingRestaurant.Core.Models.ChiTietDichVuTinhPhi;

namespace WeddingRestaurant.Service
{
    [ScopedDependency(ServiceType = typeof(IChiTietDichVuTinhPhiService))]
    public class ChiTietDichVuTinhPhiService : Base.Service, IChiTietDichVuTinhPhiService
    {

        private readonly IChiTietDichVuTinhPhiRepository _ctdvtpRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public ChiTietDichVuTinhPhiService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _ctdvtpRepository = serviceProvider.GetRequiredService<IChiTietDichVuTinhPhiRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<int> CountAsync()
        {
            var entities = _ctdvtpRepository.Get(_ => _.TrangThai == null).ToList();
            int count = 0;
            foreach (var entity in entities)
                count++;
            return Task.FromResult(count);
        }

        public Task<string> CreateAsync(ChiTietDichVuTinhPhiModel model, CancellationToken cancellationToken = default)
        {
            if (_ctdvtpRepository.Get(_ => _.MaTiec.Equals(model.MaTiec) && _.MaDichVuTinhPhi.Equals(model.MaDichVuTinhPhi) && _.TrangThai == null).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.MaTiec + " - " + model.MaDichVuTinhPhi);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsChiTietDichVuTinhPhi.CHITIETDICHVUTINHPHI_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<ChiTietDichVuTinhPhiEntity>(model);
            entity.MaTiec = model.MaTiec;
            entity.MaDichVuTinhPhi = model.MaDichVuTinhPhi;
            _ctdvtpRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.MaTiec + " - " + entity.MaDichVuTinhPhi);
        }

        public Task DeleteAsync(string id_Tiec, string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _ctdvtpRepository.GetTracking(x => x.MaDichVuTinhPhi.Equals(id) && x.MaTiec.Equals(id_Tiec) && x.TrangThai == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id + " - " + id_Tiec);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsChiTietDichVuTinhPhi.CHITIETDICHVUTINHPHI_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _ctdvtpRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<ChiTietDichVuTinhPhiEntity> GetAllAsync()
        {
            var entities = _ctdvtpRepository.Get(_ => _.TrangThai == null).ToList();
            return (ICollection<ChiTietDichVuTinhPhiEntity>)entities;
        }

        public ChiTietDichVuTinhPhiEntity GetByKeyIdAsync(string id_Tiec, string id)
        {
            var entity = _ctdvtpRepository.GetSingle(_ => _.MaDichVuTinhPhi.Equals(id) && _.MaTiec.Equals(id_Tiec) && _.TrangThai == null);
            return entity;
        }

        public Task UpdateAsync(string id_Tiec, string Id, ChiTietDichVuTinhPhiModel model, CancellationToken cancellationToken = default)
        {
            var entity = _ctdvtpRepository.GetTracking(x => x.MaDichVuTinhPhi.Equals(Id) && x.MaTiec.Equals(id_Tiec) && x.TrangThai == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id + " - " + id_Tiec);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsChiTietDichVuTinhPhi.CHITIETDICHVUTINHPHI_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.MaDichVuTinhPhi != Id && model.MaTiec != id_Tiec)
            {
                var isDuplicate = _ctdvtpRepository.GetTracking(x => x.MaDichVuTinhPhi.Equals(model.MaDichVuTinhPhi) && x.MaTiec.Equals(model.MaTiec) && x.TrangThai == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsChiTietDichVuTinhPhi.CHITIETDICHVUTINHPHI_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _ctdvtpRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<ChiTietDichVuTinhPhiEntity> GetAllByKey1Async(string id)
        {
            var entities = _ctdvtpRepository.Get(_ => _.MaTiec.Equals(id)).ToList();
            return (ICollection<ChiTietDichVuTinhPhiEntity>)entities;
        }

        public ICollection<ChiTietDichVuTinhPhiEntity> GetAllByKey2Async(string id)
        {
            var entities = _ctdvtpRepository.Get(_ => _.MaDichVuTinhPhi.Equals(id)).ToList();
            return (ICollection<ChiTietDichVuTinhPhiEntity>)entities;
        }

        // KHÔNG SỬ DỤNG
        public NguoiDungEntity GetByUserNameAsync(RefreshTokenEntity model)
        {
            throw new NotImplementedException();
        }
    }
}
