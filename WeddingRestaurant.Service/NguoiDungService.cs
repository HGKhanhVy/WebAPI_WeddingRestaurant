
using AutoMapper;
using Invedia.DI.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using WeddingRestaurant.Contract.Repository.Interface;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Contract.Service;
using WeddingRestaurant.Core.Constants;
using WeddingRestaurant.Core.Exceptions;
using WeddingRestaurant.Core.Models.NguoiDung;
using Microsoft.AspNetCore.Mvc;
using WeddingRestaurant.Core.Models.Login;
using Azure.Core;
using static WeddingRestaurant.Core.Constants.WebApiEndpoint;
using WeddingRestaurant.Core.Models.Token;

namespace WeddingRestaurant.Service
{
    [ScopedDependency(ServiceType = typeof(INguoiDungService))]
    public class NguoiDungService : Base.Service, INguoiDungService
    {

        private readonly INguoiDungRepository _nguoiDungRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public NguoiDungService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _nguoiDungRepository = serviceProvider.GetRequiredService<INguoiDungRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(NguoiDungModel model, CancellationToken cancellationToken = default)
        {
            if (_nguoiDungRepository.Get(x => x.userName == model.UserName &&
                x.DeletedTime == null
                ).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.UserName);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsNguoiDung.NGUOIDUNG_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<NguoiDungEntity>(model);
            //Set tai khoan dang nhap
            entity.Id = model.UserName;
            _nguoiDungRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.userName);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _nguoiDungRepository.GetTracking(x => x.userName == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsNguoiDung.NGUOIDUNG_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _nguoiDungRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<NguoiDungEntity> GetAllAsync()
        {
            var entities = _nguoiDungRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<NguoiDungEntity>)entities;
        }

        public NguoiDungEntity GetByKeyIdAsync(string id)
        {
            var entity = _nguoiDungRepository.GetSingle(_ => _.userName == id && _.DeletedTime == null);
            return entity;
        }

        public Task UpdateAsync(string Id, NguoiDungModel model, CancellationToken cancellationToken = default)
        {
            var entity = _nguoiDungRepository.GetTracking(x => x.userName == Id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsNguoiDung.NGUOIDUNG_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.UserName != Id)
            {
                var isDuplicate = _nguoiDungRepository.GetTracking(x => x.userName == model.UserName && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsNguoiDung.NGUOIDUNG_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _nguoiDungRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            var entities = _nguoiDungRepository.Get(_ => _.DeletedTime == null).ToList();
            int count = 0;
            foreach (var entity in entities)
                count++;
            return Task.FromResult(count);
        }

        public Task<int> CountByKeyIdAsync(int keyId)
        {
            throw new NotImplementedException();
        }

        public NguoiDungEntity GetByLoginAsync(LoginModel model)
        {
            var entity = _nguoiDungRepository.GetTracking(x => x.userName == model.UserName && x.password == model.Password).FirstOrDefault();
            if (entity == null)
            {
                return null;
            }
            return entity;
        }

        public NguoiDungEntity GetByUserNameAsync(RefreshTokenEntity model)
        {
            var entity = _nguoiDungRepository.GetTracking(x => x.userName == model.userName).SingleOrDefault();
            if (entity == null)
            {
                return null;
            }
            return entity;
        }

        public NguoiDungEntity GetBySDTAsync(string sdt)
        {
            throw new NotImplementedException();
        }
    }
}
