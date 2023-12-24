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
using WeddingRestaurant.Core.Models.DichVuUuDai;
using WeddingRestaurant.Core.Models.Login;

namespace WeddingRestaurant.Service
{
    [ScopedDependency(ServiceType = typeof(IDichVuUuDaiService))]
    public class DichVuUuDaiService : Base.Service, IDichVuUuDaiService
    {

        private readonly IDichVuUuDaiRepository _dvRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public DichVuUuDaiService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _dvRepository = serviceProvider.GetRequiredService<IDichVuUuDaiRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(DichVuUuDaiModel model, CancellationToken cancellationToken = default)
        {
            if (_dvRepository.Get(_ => _.MaDichVuUuDai.Equals(model.MaDichVuUuDai) && !_.TrangThai.Equals("Da xoa")).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.MaDichVuUuDai);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsDichVuUuDai.DICHVUUUDAI_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<DichVuUuDaiEntity>(model);
            entity.MaDichVuUuDai = model.MaDichVuUuDai;
            _dvRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.MaDichVuUuDai);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _dvRepository.GetTracking(x => x.MaDichVuUuDai.Equals(id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsDichVuUuDai.DICHVUUUDAI_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _dvRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<DichVuUuDaiEntity> GetAllAsync()
        {
            var entities = _dvRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            return (ICollection<DichVuUuDaiEntity>)entities;
        }

        public DichVuUuDaiEntity GetByKeyIdAsync(string id)
        {
            var entity = _dvRepository.GetSingle(_ => _.MaDichVuUuDai.Equals(id) && !_.TrangThai.Equals("Da xoa"));
            return entity;
        }

        public Task UpdateAsync(string Id, DichVuUuDaiModel model, CancellationToken cancellationToken = default)
        {
            var entity = _dvRepository.GetTracking(x => x.MaDichVuUuDai.Equals(Id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsDichVuUuDai.DICHVUUUDAI_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.MaDichVuUuDai != Id)
            {
                var isDuplicate = _dvRepository.GetTracking(x => x.MaDichVuUuDai.Equals(model.MaDichVuUuDai) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsDichVuUuDai.DICHVUUUDAI_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _dvRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            var entities = _dvRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
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

        DichVuUuDaiEntity IGetable<DichVuUuDaiEntity, string>.GetByLoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public DichVuUuDaiEntity GetBySDTAsync(string sdt)
        {
            throw new NotImplementedException();
        }
    }
}
