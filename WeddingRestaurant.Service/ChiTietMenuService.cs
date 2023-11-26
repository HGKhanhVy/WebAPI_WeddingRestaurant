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
            var entities = _ctmenuRepository.Get(_ => _.TrangThai == null).ToList();
            int count = 0;
            foreach (var entity in entities)
                count++;
            return Task.FromResult(count);
        }

        public Task<string> CreateAsync(ChiTietMenuModel model, CancellationToken cancellationToken = default)
        {
            if (_ctmenuRepository.Get(_ => _.MaMenu.Equals(model.MaMenu) && _.MaTiec.Equals(model.MaTiec) && _.TrangThai == null).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.MaMenu + " - " + model.MaTiec);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsChiTietMenu.CHITIETMENU_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<ChiTietMenuEntity>(model);
            entity.MaTiec = model.MaTiec;
            entity.MaMenu = model.MaMenu;
            _ctmenuRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.MaTiec + " - " + entity.MaMenu);
        }

        public Task DeleteAsync(string id, string id_Tiec, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _ctmenuRepository.GetTracking(x => x.MaMenu.Equals(id) && x.MaTiec.Equals(id_Tiec) && x.TrangThai == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id + " - " + id_Tiec);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsChiTietMenu.CHITIETMENU_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _ctmenuRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<ChiTietMenuEntity> GetAllAsync()
        {
            var entities = _ctmenuRepository.Get(_ => _.TrangThai == null).ToList();
            return (ICollection<ChiTietMenuEntity>)entities;
        }

        public ChiTietMenuEntity GetByKeyIdAsync(string id, string id_Tiec)
        {
            var entity = _ctmenuRepository.GetSingle(_ => _.MaMenu.Equals(id) && _.MaTiec.Equals(id_Tiec) && _.TrangThai == null);
            return entity;
        }

        public Task UpdateAsync(string Id, string id_Tiec, ChiTietMenuModel model, CancellationToken cancellationToken = default)
        {
            var entity = _ctmenuRepository.GetTracking(x => x.MaMenu.Equals(Id) && x.MaTiec.Equals(id_Tiec) && x.TrangThai == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id + " - " + id_Tiec);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsChiTietMenu.CHITIETMENU_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.MaMenu != Id && model.MaTiec != id_Tiec)
            {
                var isDuplicate = _ctmenuRepository.GetTracking(x => x.MaMenu.Equals(model.MaMenu) && x.MaTiec.Equals(model.MaTiec) && x.TrangThai == null).FirstOrDefault();
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

        public ICollection<ChiTietMenuEntity> GetAllByKey1Async(string id)
        {
            var entities = _ctmenuRepository.Get(_ => _.MaTiec.Equals(id)).ToList();
            return (ICollection<ChiTietMenuEntity>)entities;
        }

        public ICollection<ChiTietMenuEntity> GetAllByKey2Async(string id)
        {
            var entities = _ctmenuRepository.Get(_ => _.MaMenu.Equals(id)).ToList();
            return (ICollection<ChiTietMenuEntity>)entities;
        }

        // KHÔNG SỬ DỤNG
        public NguoiDungEntity GetByUserNameAsync(RefreshTokenEntity model)
        {
            throw new NotImplementedException();
        }
    }
}
