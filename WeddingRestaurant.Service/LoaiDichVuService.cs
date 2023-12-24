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
using WeddingRestaurant.Core.Models.LoaiDichVu;
using WeddingRestaurant.Core.Models.Login;

namespace WeddingRestaurant.Service
{
    [ScopedDependency(ServiceType = typeof(ILoaiDichVuService))]
    public class LoaiDichVuService : Base.Service, ILoaiDichVuService
    {

        private readonly ILoaiDichVuRepository _loaidvRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public LoaiDichVuService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _loaidvRepository = serviceProvider.GetRequiredService<ILoaiDichVuRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(LoaiDichVuModel model, CancellationToken cancellationToken = default)
        {
            if (_loaidvRepository.Get(_ => _.MaLoaiDichVu.Equals(model.MaLoaiDichVu) && !_.TrangThai.Equals("Da xoa")).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.MaLoaiDichVu);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsLoaiDichVu.LOAIDICHVU_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<LoaiDichVuEntity>(model);
            entity.MaLoaiDichVu = model.MaLoaiDichVu;
            _loaidvRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.MaLoaiDichVu);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _loaidvRepository.GetTracking(x => x.MaLoaiDichVu.Equals(id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsLoaiDichVu.LOAIDICHVU_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _loaidvRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<LoaiDichVuEntity> GetAllAsync()
        {
            var entities = _loaidvRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            return (ICollection<LoaiDichVuEntity>)entities;
        }

        public Task UpdateAsync(string Id, LoaiDichVuModel model, CancellationToken cancellationToken = default)
        {
            var entity = _loaidvRepository.GetTracking(x => x.MaLoaiDichVu.Equals(Id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsLoaiDichVu.LOAIDICHVU_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.MaLoaiDichVu != Id)
            {
                var isDuplicate = _loaidvRepository.GetTracking(x => x.MaLoaiDichVu.Equals(model.MaLoaiDichVu) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsLoaiDichVu.LOAIDICHVU_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _loaidvRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            var entities = _loaidvRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
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

        LoaiDichVuEntity IGetable<LoaiDichVuEntity, string>.GetByLoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public LoaiDichVuEntity GetByKeyIdAsync(string keyId)
        {
            throw new NotImplementedException();
        }
        public LoaiDichVuEntity GetBySDTAsync(string sdt)
        {
            throw new NotImplementedException();
        }
    }
}
