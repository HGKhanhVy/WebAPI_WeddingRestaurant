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
using WeddingRestaurant.Core.Models.Login;
using WeddingRestaurant.Core.Models.MonAnTrongMenu;

namespace WeddingRestaurant.Service
{
    [ScopedDependency(ServiceType = typeof(IMonAnTrongMenuService))]
    public class MonAnTrongMenuService : Base.Service, IMonAnTrongMenuService
    {

        private readonly IMonAnTrongMenuRepository _monMenuRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public MonAnTrongMenuService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _monMenuRepository = serviceProvider.GetRequiredService<IMonAnTrongMenuRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(MonAnTrongMenuModel model, CancellationToken cancellationToken = default)
        {
            if (_monMenuRepository.Get(_ => _.MaMonAn.Equals(model.MaMonAn) && _.MaMenu.Equals(model.MaMenu) && _.TrangThai == null).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.MaMonAn + " - " + model.MaMenu);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsMonAnTrongMenu.MONANTRONGMENU_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<MonAnTrongMenuEntity>(model);
            entity.MaMonAn = model.MaMonAn;
            entity.MaMenu = model.MaMenu;
            _monMenuRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.MaMenu + " - " + entity.MaMonAn);
        }

        public Task DeleteAsync(string id_Menu, string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _monMenuRepository.GetTracking(x => x.MaMonAn.Equals(id) && x.MaMenu.Equals(id_Menu) && x.TrangThai == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id + " - " + id_Menu);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsMonAnTrongMenu.MONANTRONGMENU_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _monMenuRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<MonAnTrongMenuEntity> GetAllAsync()
        {
            var entities = _monMenuRepository.Get(_ => _.TrangThai == null).ToList();
            return (ICollection<MonAnTrongMenuEntity>)entities;
        }

        public MonAnTrongMenuEntity GetByKeyIdAsync(string id_Menu, string id)
        {
            var entity = _monMenuRepository.GetSingle(_ => _.MaMonAn.Equals(id) && _.MaMenu.Equals(id_Menu) && _.TrangThai == null);
            return entity;
        }

        public Task UpdateAsync(string Id, string id_Menu, MonAnTrongMenuModel model, CancellationToken cancellationToken = default)
        {
            var entity = _monMenuRepository.GetTracking(x => x.MaMonAn.Equals(Id) && x.MaMenu.Equals(Id) && x.TrangThai == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id + " - " + id_Menu);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsMonAnTrongMenu.MONANTRONGMENU_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.MaMonAn != Id && model.MaMenu != id_Menu)
            {
                var isDuplicate = _monMenuRepository.GetTracking(x => x.MaMonAn.Equals(model.MaMonAn) && x.MaMenu.Equals(model.MaMenu) && x.TrangThai == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsMonAnTrongMenu.MONANTRONGMENU_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _monMenuRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            var entities = _monMenuRepository.Get(_ => _.TrangThai == null).ToList();
            int count = 0;
            foreach (var entity in entities)
                count++;
            return Task.FromResult(count);
        }

        public ICollection<MonAnTrongMenuEntity> GetAllByKey1Async(string id)
        {
            var entities = _monMenuRepository.Get(_ => _.MaMenu.Equals(id)).ToList();
            return (ICollection<MonAnTrongMenuEntity>)entities;
        }

        public ICollection<MonAnTrongMenuEntity> GetAllByKey2Async(string id)
        {
            var entities = _monMenuRepository.Get(_ => _.MaMonAn.Equals(id)).ToList();
            return (ICollection<MonAnTrongMenuEntity>)entities;
        }

        // KHÔNG SỬ DỤNG
        public NguoiDungEntity GetByUserNameAsync(RefreshTokenEntity model)
        {
            throw new NotImplementedException();
        }
    }
}
