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
using WeddingRestaurant.Contract.Service.Base;
using WeddingRestaurant.Contract.Service;
using WeddingRestaurant.Core.Constants;
using WeddingRestaurant.Core.Exceptions;
using WeddingRestaurant.Core.Models.Login;
using WeddingRestaurant.Core.Models.NhanVien;

namespace WeddingRestaurant.Service
{
    [ScopedDependency(ServiceType = typeof(INhanVienService))]
    public class NhanVienService : Base.Service, INhanVienService
    {

        private readonly INhanVienRepository _nvRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public NhanVienService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _nvRepository = serviceProvider.GetRequiredService<INhanVienRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(NhanVienModel model, CancellationToken cancellationToken = default)
        {
            if (_nvRepository.Get(_ => _.MaNhanVien.Equals(model.MaNhanVien) && !_.TrangThai.Equals("Da nghi viec")).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.MaNhanVien);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsNhanVien.NHANVIEN_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<NhanVienEntity>(model);
            entity.MaNhanVien = model.MaNhanVien;
            _nvRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.MaNhanVien);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _nvRepository.GetTracking(x => x.MaNhanVien.Equals(id) && !x.TrangThai.Equals("Da nghi viec")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsNhanVien.NHANVIEN_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _nvRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.NgayNghiViec = DateTime.Now.ToString();
            entity.TrangThai = "Da nghi viec";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<NhanVienEntity> GetAllAsync()
        {
            var entities = _nvRepository.Get(_ => !_.TrangThai.Equals("Da nghi viec")).ToList();
            return (ICollection<NhanVienEntity>)entities;
        }

        public NhanVienEntity GetByKeyIdAsync(string id)
        {
            var entity = _nvRepository.GetSingle(_ => _.MaNhanVien.Equals(id) && !_.TrangThai.Equals("Da nghi viec"));
            return entity;
        }

        public Task UpdateAsync(string Id, NhanVienModel model, CancellationToken cancellationToken = default)
        {
            var entity = _nvRepository.GetTracking(x => x.MaNhanVien.Equals(Id) && !x.TrangThai.Equals("Da nghi viec")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsNhanVien.NHANVIEN_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.MaNhanVien != Id)
            {
                var isDuplicate = _nvRepository.GetTracking(x => x.MaNhanVien.Equals(model.MaNhanVien) && !x.TrangThai.Equals("Da nghi viec")).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsNhanVien.NHANVIEN_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _nvRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            var entities = _nvRepository.Get(_ => !_.TrangThai.Equals("Da nghi viec")).ToList();
            int count = 0;
            foreach (var entity in entities)
                count++;
            return Task.FromResult(count);
        }

        public NhanVienEntity NhanVienLogin(string gmail, string mk)
        {
            var entity = _nvRepository.GetSingle(_ => _.Gmail.Equals(gmail) && _.MatKhau.Equals(mk) && !_.TrangThai.Equals("Da nghi viec"));
            return entity;
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

        NhanVienEntity IGetable<NhanVienEntity, string>.GetByLoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public NhanVienEntity GetBySDTAsync(string sdt)
        {
            throw new NotImplementedException();
        }
    }
}
