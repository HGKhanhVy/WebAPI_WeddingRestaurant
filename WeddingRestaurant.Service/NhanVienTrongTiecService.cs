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
using WeddingRestaurant.Core.Models.NhanVienTrongTiec;

namespace WeddingRestaurant.Service
{
    [ScopedDependency(ServiceType = typeof(INhanVienTrongTiecService))]
    public class NhanVienTrongTiecService : Base.Service, INhanVienTrongTiecService
    {

        private readonly INhanVienTrongTiecRepository _nvRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public NhanVienTrongTiecService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _nvRepository = serviceProvider.GetRequiredService<INhanVienTrongTiecRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(NhanVienTrongTiecModel model, CancellationToken cancellationToken = default)
        {
            if (_nvRepository.Get(_ => _.MaTiec.Equals(model.MaTiec) && _.MaNhanVien.Equals(model.MaNhanVien) && !_.TrangThai.Equals("Da nghi")).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.MaTiec + " - " + model.MaNhanVien);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsNhanVienTrongTiec.NHANVIENTRONGTIEC_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<NhanVienTrongTiecEntity>(model);
            entity.MaTiec = model.MaTiec;
            entity.MaNhanVien = model.MaNhanVien;
            _nvRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.MaTiec + " - " + entity.MaNhanVien);
        }

        public Task DeleteAsync(string id, string id_NhanVien, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _nvRepository.GetTracking(x => x.MaTiec.Equals(id) && x.MaNhanVien.Equals(id_NhanVien) && !x.TrangThai.Equals("Da nghi")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id + " - " + id_NhanVien);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsNhanVienTrongTiec.NHANVIENTRONGTIEC_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _nvRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da nghi";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<NhanVienTrongTiecEntity> GetAllAsync()
        {
            var entities = _nvRepository.Get(_ => !_.TrangThai.Equals("Da nghi")).ToList();
            return (ICollection<NhanVienTrongTiecEntity>)entities;
        }

        public NhanVienTrongTiecEntity GetByKeyIdAsync(string id, string id_NhanVien)
        {
            var entity = _nvRepository.GetSingle(_ => _.MaTiec.Equals(id) && _.MaNhanVien.Equals(id_NhanVien) && !_.TrangThai.Equals("Da nghi"));
            return entity;
        }

        public Task UpdateAsync(string Id, string id_NhanVien, NhanVienTrongTiecModel model, CancellationToken cancellationToken = default)
        {
            var entity = _nvRepository.GetTracking(x => x.MaTiec.Equals(Id) && x.MaNhanVien.Equals(id_NhanVien) && !x.TrangThai.Equals("Da nghi")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id + " - " + id_NhanVien);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsNhanVienTrongTiec.NHANVIENTRONGTIEC_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.MaTiec != Id && model.MaNhanVien != id_NhanVien)
            {
                var isDuplicate = _nvRepository.GetTracking(x => x.MaTiec.Equals(model.MaTiec) && x.MaNhanVien.Equals(model.MaNhanVien) && !x.TrangThai.Equals("Da nghi")).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsNhanVienTrongTiec.NHANVIENTRONGTIEC_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _nvRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            var entities = _nvRepository.Get(_ => !_.TrangThai.Equals("Da nghi")).ToList();
            int count = 0;
            foreach (var entity in entities)
                count++;
            return Task.FromResult(count);
        }

        public ICollection<NhanVienTrongTiecEntity> GetAllByKey1Async(string id)
        {
            var entities = _nvRepository.Get(_ => _.MaTiec.Equals(id)).ToList();
            return (ICollection<NhanVienTrongTiecEntity>)entities;
        }

        public ICollection<NhanVienTrongTiecEntity> GetAllByKey2Async(string id)
        {
            var entities = _nvRepository.Get(_ => _.MaNhanVien.Equals(id)).ToList();
            return (ICollection<NhanVienTrongTiecEntity>)entities;
        }

        // KHÔNG SỬ DỤNG
        public NguoiDungEntity GetByUserNameAsync(RefreshTokenEntity model)
        {
            throw new NotImplementedException();
        }
    }
}
