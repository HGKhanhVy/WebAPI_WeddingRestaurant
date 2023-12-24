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
using WeddingRestaurant.Core.Models.LoaiNuoc;
using WeddingRestaurant.Core.Models.Login;

namespace WeddingRestaurant.Service
{
    [ScopedDependency(ServiceType = typeof(ILoaiNuocService))]
    public class LoaiNuocService : Base.Service, ILoaiNuocService
    {

        private readonly ILoaiNuocRepository _loaiNuocRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public LoaiNuocService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _loaiNuocRepository = serviceProvider.GetRequiredService<ILoaiNuocRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(LoaiNuocModel model, CancellationToken cancellationToken = default)
        {
            if (_loaiNuocRepository.Get(_ => _.MaLoaiNuoc.Equals(model.MaLoaiNuoc) && !_.TrangThai.Equals("Da xoa")).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.MaLoaiNuoc);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsLoaiNuoc.LOAINUOC_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<LoaiNuocEntity>(model);
            entity.MaLoaiNuoc = model.MaLoaiNuoc;
            _loaiNuocRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.MaLoaiNuoc);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _loaiNuocRepository.GetTracking(x => x.MaLoaiNuoc.Equals(id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsLoaiNuoc.LOAINUOC_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _loaiNuocRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<LoaiNuocEntity> GetAllAsync()
        {
            var entities = _loaiNuocRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            return (ICollection<LoaiNuocEntity>)entities;
        }

        public LoaiNuocEntity GetByKeyIdAsync(string id)
        {
            var entity = _loaiNuocRepository.GetSingle(_ => _.MaLoaiNuoc.Equals(id) && !_.TrangThai.Equals("Da xoa"));
            return entity;
        }

        public Task UpdateAsync(string Id, LoaiNuocModel model, CancellationToken cancellationToken = default)
        {
            var entity = _loaiNuocRepository.GetTracking(x => x.MaLoaiNuoc.Equals(Id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsLoaiNuoc.LOAINUOC_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.MaLoaiNuoc != Id)
            {
                var isDuplicate = _loaiNuocRepository.Get(x => x.MaLoaiNuoc == model.MaLoaiNuoc && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsLoaiNuoc.LOAINUOC_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _loaiNuocRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            var entities = _loaiNuocRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
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
        public LoaiNuocEntity GetBySDTAsync(string sdt)
        {
            throw new NotImplementedException();
        }

        LoaiNuocEntity IGetable<LoaiNuocEntity, string>.GetByLoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }
    }
}
