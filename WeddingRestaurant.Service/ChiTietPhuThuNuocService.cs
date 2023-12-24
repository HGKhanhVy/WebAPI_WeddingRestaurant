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
using WeddingRestaurant.Core.Models.ChiTietPhuThuNuoc;
using static WeddingRestaurant.Core.Constants.WebApiEndpoint;

namespace WeddingRestaurant.Service
{
    [ScopedDependency(ServiceType = typeof(IChiTietPhuThuNuocService))]
    public class ChiTietPhuThuNuocService : Base.Service, IChiTietPhuThuNuocService
    {

        private readonly IChiTietPhuThuNuocRepository _ctphuthuncRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public ChiTietPhuThuNuocService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _ctphuthuncRepository = serviceProvider.GetRequiredService<IChiTietPhuThuNuocRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<int> CountAsync()
        {
            var entities = _ctphuthuncRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            int count = 0;
            foreach (var entity in entities)
                count++;
            return Task.FromResult(count);
        }

        public Task<string> CreateAsync(ChiTietPhuThuNuocModel model, CancellationToken cancellationToken = default)
        {
            if (_ctphuthuncRepository.Get(_ => _.MaPhuThu.Equals(model.MaPhuThu) && _.MaNuoc.Equals(model.MaNuoc) && !_.TrangThai.Equals("Da xoa")).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.MaPhuThu + " - " + model.MaNuoc);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsChiTietPhuThuNuoc.CHITIETPHUTHUNUOC_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<ChiTietPhuThuNuocEntity>(model);
            entity.MaPhuThu = model.MaPhuThu;
            entity.MaNuoc = model.MaNuoc;
            _ctphuthuncRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.MaPhuThu + " - " + entity.MaNuoc);
        }

        public Task DeleteAsync(string id, string id_Nuoc, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _ctphuthuncRepository.GetTracking(x => x.MaPhuThu.Equals(id) && x.MaNuoc.Equals(id_Nuoc) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id + " - " + id_Nuoc);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsChiTietPhuThuNuoc.CHITIETPHUTHUNUOC_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _ctphuthuncRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<ChiTietPhuThuNuocEntity> GetAllAsync()
        {
            var entities = _ctphuthuncRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            return (ICollection<ChiTietPhuThuNuocEntity>)entities;
        }

        public ChiTietPhuThuNuocEntity GetByKeyIdAsync(string id_PhuThu, string id)
        {
            var entity = _ctphuthuncRepository.GetSingle(_ => _.MaNuoc.Equals(id) && _.MaPhuThu.Equals(id_PhuThu) && !_.TrangThai.Equals("Da xoa"));
            return entity;
        }

        public Task UpdateAsync(string id_PhuThu, string Id, ChiTietPhuThuNuocModel model, CancellationToken cancellationToken = default)
        {
            var entity = _ctphuthuncRepository.GetTracking(x => x.MaNuoc.Equals(Id) && x.MaPhuThu.Equals(id_PhuThu) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id + " - " + id_PhuThu);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsChiTietPhuThuNuoc.CHITIETPHUTHUNUOC_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.MaNuoc != Id && model.MaPhuThu != id_PhuThu)
            {
                var isDuplicate = _ctphuthuncRepository.GetTracking(x => x.MaNuoc.Equals(model.MaNuoc) && x.MaPhuThu.Equals(model.MaPhuThu) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsChiTietPhuThuNuoc.CHITIETPHUTHUNUOC_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _ctphuthuncRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<ChiTietPhuThuNuocEntity> GetAllByKey1Async(string id)
        {
            var entities = _ctphuthuncRepository.Get(_ => _.MaPhuThu.Equals(id)).ToList();
            return (ICollection<ChiTietPhuThuNuocEntity>)entities;
        }

        public ICollection<ChiTietPhuThuNuocEntity> GetAllByKey2Async(string id)
        {
            var entities = _ctphuthuncRepository.Get(_ => _.MaNuoc.Equals(id)).ToList();
            return (ICollection<ChiTietPhuThuNuocEntity>)entities;
        }

        // KHÔNG SỬ DỤNG
        public NguoiDungEntity GetByUserNameAsync(RefreshTokenEntity model)
        {
            throw new NotImplementedException();
        }
    }
}
