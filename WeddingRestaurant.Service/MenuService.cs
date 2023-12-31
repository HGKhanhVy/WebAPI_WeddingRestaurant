﻿using AutoMapper;
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
using WeddingRestaurant.Core.Models.Menu;

namespace WeddingRestaurant.Service
{
    [ScopedDependency(ServiceType = typeof(IMenuService))]
    public class MenuService : Base.Service, IMenuService
    {

        private readonly IMenuRepository _menuRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public MenuService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _menuRepository = serviceProvider.GetRequiredService<IMenuRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(MenuModel model, CancellationToken cancellationToken = default)
        {
            if (_menuRepository.Get(_ => _.MaMenu.Equals(model.MaMenu) && !_.TrangThai.Equals("Da xoa")).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.MaMenu);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsMenu.MENU_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<MenuEntity>(model);
            entity.MaMenu = model.MaMenu;
            _menuRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.MaMenu);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _menuRepository.GetTracking(x => x.MaMenu.Equals(id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsMenu.MENU_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _menuRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<MenuEntity> GetAllAsync()
        {
            var entities = _menuRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            return (ICollection<MenuEntity>)entities;
        }

        public MenuEntity GetByKeyIdAsync(string id)
        {
            var entity = _menuRepository.GetSingle(_ => _.MaMenu.Equals(id) && !_.TrangThai.Equals("Da xoa"));
            return entity;
        }

        public Task UpdateAsync(string Id, MenuModel model, CancellationToken cancellationToken = default)
        {
            var entity = _menuRepository.GetTracking(x => x.MaMenu.Equals(Id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsMenu.MENU_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.MaMenu != Id)
            {
                var isDuplicate = _menuRepository.GetTracking(x => x.MaMenu.Equals(model.MaMenu) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsMenu.MENU_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _menuRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            var entities = _menuRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            int count = 0;
            foreach (var entity in entities)
                count++;
            return Task.FromResult(count);
        }
        public MenuEntity GetByLoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public NguoiDungEntity GetByUserNameAsync(RefreshTokenEntity model)
        {
            throw new NotImplementedException();
        }

        public MenuEntity GetBySDTAsync(string sdt)
        {
            throw new NotImplementedException();
        }
    }
}
