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
using WeddingRestaurant.Core.Models.Nuoc;

namespace WeddingRestaurant.Service
{
    [ScopedDependency(ServiceType = typeof(INuocService))]
    public class NuocService : Base.Service, INuocService
    {

        private readonly INuocRepository _nuocRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public NuocService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _nuocRepository = serviceProvider.GetRequiredService<INuocRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(NuocModel model, CancellationToken cancellationToken = default)
        {
            if (_nuocRepository.Get(_ => _.MaNuoc.Equals(model.MaNuoc) && !_.TrangThai.Equals("Da xoa")).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.MaNuoc);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsNuoc.NUOC_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<NuocEntity>(model);
            entity.MaNuoc = model.MaNuoc;
            _nuocRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.MaNuoc);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _nuocRepository.GetTracking(x => x.MaNuoc.Equals(id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsNuoc.NUOC_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _nuocRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<NuocEntity> GetAllAsync()
        {
            var entities = _nuocRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            return (ICollection<NuocEntity>)entities;
        }

        public NuocEntity GetByKeyIdAsync(string id)
        {
            var entity = _nuocRepository.GetSingle(_ => _.MaNuoc.Equals(id) && !_.TrangThai.Equals("Da xoa"));
            return entity;
        }

        public Task UpdateAsync(string Id, NuocModel model, CancellationToken cancellationToken = default)
        {
            var entity = _nuocRepository.GetTracking(x => x.MaNuoc.Equals(Id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsNuoc.NUOC_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.MaNuoc != Id)
            {
                var isDuplicate = _nuocRepository.GetTracking(x => x.MaNuoc.Equals(model.MaNuoc) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsNuoc.NUOC_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _nuocRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            var entities = _nuocRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            int count = 0;
            foreach (var entity in entities)
                count++;
            return Task.FromResult(count);
        }

        public Task<int> CountByKeyIdAsync(int keyId)
        {
            throw new NotImplementedException();
        }

        public DatTiecEntity GetByLoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public NguoiDungEntity GetByUserNameAsync(RefreshTokenEntity model)
        {
            throw new NotImplementedException();
        }

        NuocEntity IGetable<NuocEntity, string>.GetByLoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public NuocEntity GetBySDTAsync(string sdt)
        {
            throw new NotImplementedException();
        }
    }
}
