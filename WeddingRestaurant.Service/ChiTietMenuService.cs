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
using WeddingRestaurant.Core.Models.ChiTietDichVu;
using WeddingRestaurant.Core.Models.ChiTietMenu;
using WeddingRestaurant.Core.Models.Login;

namespace WeddingRestaurant.Service
{
    [ScopedDependency(ServiceType = typeof(IChiTietMenuService))]
    public class ChiTietMenuService : Base.Service, IChiTietMenuService
    {

        private readonly IChiTietMenuRepository _ctmenuRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public ChiTietMenuService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _ctmenuRepository = serviceProvider.GetRequiredService<IChiTietMenuRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<int> CountAsync()
        {
            var entities = _ctmenuRepository.Get(_ => _.DeletedTime == null).ToList();
            int count = 0;
            foreach (var entity in entities)
                count++;
            return Task.FromResult(count);
        }

        public Task<string> CreateAsync(ChiTietMenuModel model, CancellationToken cancellationToken = default)
        {
            if (_ctmenuRepository.Get(_ => _.MaMenu == model.MaMenu && _.MaTiec == model.MaTiec && _.DeletedTime == null).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.MaMenu);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsChiTietMenu.CHITIETMENU_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<ChiTietMenuEntity>(model);
            _ctmenuRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.MaTiec + " - " + entity.MaMenu);
        }

        public Task DeleteAsync(string id, string id_Tiec, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _ctmenuRepository.GetTracking(x => x.MaMenu == id && x.MaTiec == id_Tiec && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsChiTietMenu.CHITIETMENU_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _ctmenuRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<ChiTietMenuEntity> GetAllAsync()
        {
            var entities = _ctmenuRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<ChiTietMenuEntity>)entities;
        }

        public ChiTietMenuEntity GetByKeyIdAsync(string id, string id_Tiec)
        {
            var entity = _ctmenuRepository.GetSingle(_ => _.MaMenu == id && _.MaTiec == id_Tiec && _.DeletedTime == null);
            return entity;
        }

        public Task UpdateAsync(string Id, string id_Tiec, ChiTietMenuModel model, CancellationToken cancellationToken = default)
        {
            var entity = _ctmenuRepository.GetTracking(x => x.MaMenu == Id && x.MaTiec == id_Tiec && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsChiTietDichVu.CHITIETDICHVU_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.MaMenu != Id && model.MaTiec != id_Tiec)
            {
                var isDuplicate = _ctmenuRepository.GetTracking(x => x.MaMenu == model.MaMenu && x.MaTiec == model.MaTiec && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsChiTietMenu.CHITIETMENU_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _ctmenuRepository.Update(entity);
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
