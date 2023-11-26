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
using WeddingRestaurant.Core.Models.KhachHang;
using WeddingRestaurant.Core.Models.Login;

namespace WeddingRestaurant.Service
{
    [ScopedDependency(ServiceType = typeof(IKhachHangService))]
    public class KhachHangService : Base.Service, IKhachHangService
    {

        private readonly IKhachHangRepository _khRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public KhachHangService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _khRepository = serviceProvider.GetRequiredService<IKhachHangRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(KhachHangModel model, CancellationToken cancellationToken = default)
        {
            if (_khRepository.Get(_ => _.MaKhachHang.Equals(model.MaKhachHang) && _.TrangThai == null).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.MaKhachHang);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsKhachHang.KHACHHANG_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<KhachHangEntity>(model);
            entity.MaKhachHang = model.MaKhachHang;
            _khRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.MaKhachHang);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _khRepository.GetTracking(x => x.MaKhachHang.Equals(id) && x.TrangThai == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsKhachHang.KHACHHANG_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _khRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";s
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<KhachHangEntity> GetAllAsync()
        {
            var entities = _khRepository.Get(_ => _.TrangThai == null).ToList();
            return (ICollection<KhachHangEntity>)entities;
        }

        public KhachHangEntity GetBySDTAsync(string sdt)
        {
            var entity = _khRepository.GetSingle(_ => _.SoDienThoai.Equals(sdt) && _.TrangThai == null);
            return entity;
        }

        public Task UpdateAsync(string Id, KhachHangModel model, CancellationToken cancellationToken = default)
        {
            var entity = _khRepository.GetTracking(x => x.MaKhachHang.Equals(Id) && x.TrangThai == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsKhachHang.KHACHHANG_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.MaKhachHang != Id)
            {
                var isDuplicate = _khRepository.GetTracking(x => x.MaKhachHang.Equals(model.MaKhachHang) && x.TrangThai == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsKhachHang.KHACHHANG_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _khRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            var entities = _khRepository.Get(_ => _.TrangThai == null).ToList();
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

        KhachHangEntity IGetable<KhachHangEntity, string>.GetByLoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public KhachHangEntity GetByKeyIdAsync(string keyId)
        {
            throw new NotImplementedException();
        }
    }
}
