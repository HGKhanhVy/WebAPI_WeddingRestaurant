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
using WeddingRestaurant.Core.Models.ChiTietDichVu;
using WeddingRestaurant.Core.Models.ChiTietMenu;
using WeddingRestaurant.Core.Models.Login;
using WeddingRestaurant.Core.Models.ChiTietNuocUong;

namespace WeddingRestaurant.Service
{
    [ScopedDependency(ServiceType = typeof(IChiTietNuocUongService))]
    public class ChiTietNuocUongService : Base.Service, IChiTietNuocUongService
    {

        private readonly IChiTietNuocUongRepository _ctncRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public ChiTietNuocUongService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _ctncRepository = serviceProvider.GetRequiredService<IChiTietNuocUongRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<int> CountAsync()
        {
            var entities = _ctncRepository.Get(_ => _.DeletedTime == null).ToList();
            int count = 0;
            foreach (var entity in entities)
                count++;
            return Task.FromResult(count);
        }

        public Task<string> CreateAsync(ChiTietNuocUongModel model, CancellationToken cancellationToken = default)
        {
            if (_ctncRepository.Get(_ => _.MaNuoc == model.MaNuoc && _.MaTiec == model.MaTiec && _.DeletedTime == null).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.MaNuoc);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsChiTietNuocUong.CHITIETNUOCUONG_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<ChiTietNuocUongEntity>(model);
            _ctncRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.MaTiec + " - " + entity.MaNuoc);
        }

        public Task DeleteAsync(string id, string id_Tiec, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _ctncRepository.GetTracking(x => x.MaNuoc == id && x.MaTiec == id_Tiec && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsChiTietNuocUong.CHITIETNUOCUONG_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _ctncRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<ChiTietNuocUongEntity> GetAllAsync()
        {
            var entities = _ctncRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<ChiTietNuocUongEntity>)entities;
        }

        public ChiTietNuocUongEntity GetByKeyIdAsync(string id, string id_Tiec)
        {
            var entity = _ctncRepository.GetSingle(_ => _.MaNuoc == id && _.MaTiec == id_Tiec && _.DeletedTime == null);
            return entity;
        }

        public Task UpdateAsync(string Id, string id_Tiec, ChiTietNuocUongModel model, CancellationToken cancellationToken = default)
        {
            var entity = _ctncRepository.GetTracking(x => x.MaNuoc == Id && x.MaTiec == id_Tiec && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsChiTietNuocUong.CHITIETNUOCUONG_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.MaNuoc != Id && model.MaTiec != id_Tiec)
            {
                var isDuplicate = _ctncRepository.GetTracking(x => x.MaNuoc == model.MaNuoc && x.MaTiec == model.MaTiec && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsChiTietNuocUong.CHITIETNUOCUONG_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _ctncRepository.Update(entity);
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
