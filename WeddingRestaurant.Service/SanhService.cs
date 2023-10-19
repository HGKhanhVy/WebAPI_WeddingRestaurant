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
using WeddingRestaurant.Core.Models.LichSanhTiec;
using WeddingRestaurant.Core.Models.Login;
using WeddingRestaurant.Core.Models.Sanh;

namespace WeddingRestaurant.Service
{
    [ScopedDependency(ServiceType = typeof(ISanhService))]
    public class SanhService : Base.Service, ISanhService
    {

        private readonly ISanhRepository _sanhRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public SanhService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _sanhRepository = serviceProvider.GetRequiredService<ISanhRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(SanhModel model, CancellationToken cancellationToken = default)
        {
            if (_sanhRepository.Get(_ => _.MaSanh == model.MaSanh && _.DeletedTime == null).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.MaSanh);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsSanh.SANH_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<SanhEntity>(model);
            _sanhRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.MaSanh);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _sanhRepository.GetTracking(x => x.MaSanh == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsSanh.SANH_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _sanhRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<SanhEntity> GetAllAsync()
        {
            var entities = _sanhRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<SanhEntity>)entities;
        }

        public SanhEntity GetByKeyIdAsync(string id)
        {
            var entity = _sanhRepository.GetSingle(_ => _.MaSanh == id && _.DeletedTime == null);
            return entity;
        }

        public Task UpdateAsync(string Id, SanhModel model, CancellationToken cancellationToken = default)
        {
            var entity = _sanhRepository.GetTracking(x => x.MaSanh == Id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsSanh.SANH_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.MaSanh != Id)
            {
                var isDuplicate = _sanhRepository.GetTracking(x => x.MaSanh == model.MaSanh && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsSanh.SANH_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _sanhRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            var entities = _sanhRepository.Get(_ => _.DeletedTime == null).ToList();
            int count = 0;
            foreach (var entity in entities)
                count++;
            return Task.FromResult(count);
        }

        public string PrintSucChuaAsync(string id)
        {
            string sucChua = "";
            var entity = _sanhRepository.GetSingle(_ => _.MaSanh == id && _.DeletedTime == null);
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsSanh.SANH_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            } 
            else
            {
                sucChua = "Sức chứa tối thiểu: " + entity.SucChucToiThieu.ToString() + " - Sức chứa tối đa: " + entity.SucChucToiDa.ToString();
            }
            return sucChua;
        }

        // KHÔNG DÙNG
        public NguoiDungEntity GetByUserNameAsync(RefreshTokenEntity model)
        {
            throw new NotImplementedException();
        }

        SanhEntity IGetable<SanhEntity, string>.GetByLoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public SanhEntity GetBySDTAsync(string sdt)
        {
            throw new NotImplementedException();
        }
    }
}
