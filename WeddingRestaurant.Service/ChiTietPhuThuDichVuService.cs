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
using WeddingRestaurant.Core.Models.ChiTietPhuThuDichVu;

namespace WeddingRestaurant.Service
{
    [ScopedDependency(ServiceType = typeof(IChiTietPhuThuDichVuService))]
    public class ChiTietPhuThuDichVuService : Base.Service, IChiTietPhuThuDichVuService
    {

        private readonly IChiTietPhuThuDichVuRepository _ctphuthudvRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public ChiTietPhuThuDichVuService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _ctphuthudvRepository = serviceProvider.GetRequiredService<IChiTietPhuThuDichVuRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<int> CountAsync()
        {
            var entities = _ctphuthudvRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            int count = 0;
            foreach (var entity in entities)
                count++;
            return Task.FromResult(count);
        }

        public Task<string> CreateAsync(ChiTietPhuThuDichVuModel model, CancellationToken cancellationToken = default)
        {
            if (_ctphuthudvRepository.Get(_ => _.MaPhuThu.Equals(model.MaPhuThu) && _.MaDichVuTinhPhi.Equals(model.MaDichVuTinhPhi) && !_.TrangThai.Equals("Da xoa")).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.MaPhuThu + " - " + model.MaDichVuTinhPhi);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsChiTietPhuThuDichVu.CHITIETPHUTHUDV_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<ChiTietPhuThuDichVuEntity>(model);
            entity.MaPhuThu = model.MaPhuThu;
            entity.MaDichVuTinhPhi = model.MaDichVuTinhPhi;
            _ctphuthudvRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.MaPhuThu + " - " + entity.MaDichVuTinhPhi);
        }

        public Task DeleteAsync(string id_PhuThu, string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _ctphuthudvRepository.GetTracking(x => x.MaDichVuTinhPhi.Equals(id) && x.MaPhuThu.Equals(id_PhuThu) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id + " - " + id_PhuThu);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsChiTietPhuThuDichVu.CHITIETPHUTHUDV_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _ctphuthudvRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<ChiTietPhuThuDichVuEntity> GetAllAsync()
        {
            var entities = _ctphuthudvRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            return (ICollection<ChiTietPhuThuDichVuEntity>)entities;
        }

        public ChiTietPhuThuDichVuEntity GetByKeyIdAsync(string id_PhuThu, string id)
        {
            var entity = _ctphuthudvRepository.GetSingle(_ => _.MaDichVuTinhPhi.Equals(id) && _.MaPhuThu.Equals(id_PhuThu) && !_.TrangThai.Equals("Da xoa"));
            return entity;
        }

        public Task UpdateAsync(string id_PhuThu, string Id, ChiTietPhuThuDichVuModel model, CancellationToken cancellationToken = default)
        {
            var entity = _ctphuthudvRepository.GetTracking(x => x.MaDichVuTinhPhi.Equals(Id) && x.MaPhuThu.Equals(id_PhuThu) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id + " - " + id_PhuThu);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsChiTietPhuThuDichVu.CHITIETPHUTHUDV_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.MaDichVuTinhPhi != Id && model.MaPhuThu != id_PhuThu)
            {
                var isDuplicate = _ctphuthudvRepository.GetTracking(x => x.MaDichVuTinhPhi.Equals(model.MaDichVuTinhPhi) && x.MaPhuThu.Equals(model.MaPhuThu) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsChiTietPhuThuDichVu.CHITIETPHUTHUDV_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _ctphuthudvRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<ChiTietPhuThuDichVuEntity> GetAllByKey1Async(string id)
        {
            var entities = _ctphuthudvRepository.Get(_ => _.MaPhuThu.Equals(id)).ToList();
            return (ICollection<ChiTietPhuThuDichVuEntity>)entities;
        }

        public ICollection<ChiTietPhuThuDichVuEntity> GetAllByKey2Async(string id)
        {
            var entities = _ctphuthudvRepository.Get(_ => _.MaDichVuTinhPhi.Equals(id)).ToList();
            return (ICollection<ChiTietPhuThuDichVuEntity>)entities;
        }

        // KHÔNG SỬ DỤNG
        public NguoiDungEntity GetByUserNameAsync(RefreshTokenEntity model)
        {
            throw new NotImplementedException();
        }
    }
}
