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
using WeddingRestaurant.Core.Models.ChiTietPhuThuMonAn;

namespace WeddingRestaurant.Service
{
    [ScopedDependency(ServiceType = typeof(IChiTietPhuThuMonAnService))]
    public class ChiTietPhuThuMonAnService : Base.Service, IChiTietPhuThuMonAnService
    {

        private readonly IChiTietPhuThuMonAnRepository _ctphuthumaRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public ChiTietPhuThuMonAnService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _ctphuthumaRepository = serviceProvider.GetRequiredService<IChiTietPhuThuMonAnRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<int> CountAsync()
        {
            var entities = _ctphuthumaRepository.Get(_ => _.TrangThai == null).ToList();
            int count = 0;
            foreach (var entity in entities)
                count++;
            return Task.FromResult(count);
        }

        public Task<string> CreateAsync(ChiTietPhuThuMonAnModel model, CancellationToken cancellationToken = default)
        {
            if (_ctphuthumaRepository.Get(_ => _.MaPhuThu.Equals(model.MaPhuThu) && _.MaMonAn.Equals(model.MaMonAn) && _.TrangThai == null).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.MaPhuThu + " - " + model.MaMonAn);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsChiTietPhuThuMonAn.CHITIETPHUTHUMA_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<ChiTietPhuThuMonAnEntity>(model);
            entity.MaPhuThu = model.MaPhuThu;
            entity.MaMonAn = model.MaMonAn;
            _ctphuthumaRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.MaPhuThu + " - " + entity.MaMonAn);
        }

        public Task DeleteAsync(string id, string id_MonAn, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _ctphuthumaRepository.GetTracking(x => x.MaPhuThu.Equals(id) && x.MaMonAn.Equals(id_MonAn) && x.TrangThai == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id + " - " + id_MonAn);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsChiTietPhuThuMonAn.CHITIETPHUTHUMA_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _ctphuthumaRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<ChiTietPhuThuMonAnEntity> GetAllAsync()
        {
            var entities = _ctphuthumaRepository.Get(_ => _.TrangThai == null).ToList();
            return (ICollection<ChiTietPhuThuMonAnEntity>)entities;
        }

        public ChiTietPhuThuMonAnEntity GetByKeyIdAsync(string id_PhuThu, string id)
        {
            var entity = _ctphuthumaRepository.GetSingle(_ => _.MaMonAn.Equals(id) && _.MaPhuThu.Equals(id_PhuThu) && _.TrangThai == null);
            return entity;
        }

        public Task UpdateAsync(string id_PhuThu, string Id, ChiTietPhuThuMonAnModel model, CancellationToken cancellationToken = default)
        {
            var entity = _ctphuthumaRepository.GetTracking(x => x.MaMonAn.Equals(Id) && x.MaPhuThu.Equals(id_PhuThu) && x.TrangThai == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id + " - " + id_PhuThu);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsChiTietPhuThuMonAn.CHITIETPHUTHUMA_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.MaMonAn != Id && model.MaPhuThu != id_PhuThu)
            {
                var isDuplicate = _ctphuthumaRepository.GetTracking(x => x.MaMonAn.Equals(model.MaMonAn) && x.MaPhuThu.Equals(model.MaPhuThu) && x.TrangThai == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsChiTietPhuThuMonAn.CHITIETPHUTHUMA_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _ctphuthumaRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<ChiTietPhuThuMonAnEntity> GetAllByKey1Async(string id)
        {
            var entities = _ctphuthumaRepository.Get(_ => _.MaPhuThu.Equals(id)).ToList();
            return (ICollection<ChiTietPhuThuMonAnEntity>)entities;
        }

        public ICollection<ChiTietPhuThuMonAnEntity> GetAllByKey2Async(string id)
        {
            var entities = _ctphuthumaRepository.Get(_ => _.MaMonAn.Equals(id)).ToList();
            return (ICollection<ChiTietPhuThuMonAnEntity>)entities;
        }

        // KHÔNG SỬ DỤNG
        public NguoiDungEntity GetByUserNameAsync(RefreshTokenEntity model)
        {
            throw new NotImplementedException();
        }
    }
}
