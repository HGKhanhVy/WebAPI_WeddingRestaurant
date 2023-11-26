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
using WeddingRestaurant.Core.Models.Login;
using WeddingRestaurant.Core.Models.PhuThu;

namespace WeddingRestaurant.Service
{
    [ScopedDependency(ServiceType = typeof(IPhuThuService))]
    public class PhuThuService : Base.Service, IPhuThuService
    {

        private readonly IPhuThuRepository _phuthuRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public PhuThuService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _phuthuRepository = serviceProvider.GetRequiredService<IPhuThuRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(PhuThuModel model, CancellationToken cancellationToken = default)
        {
            if (_phuthuRepository.Get(_ => _.MaPhuThu.Equals(model.MaPhuThu) && _.TrangThai == null).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.MaPhuThu);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsPhuThu.PHUTHU_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<PhuThuEntity>(model);
            entity.MaPhuThu = model.MaPhuThu;
            _phuthuRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.MaPhuThu);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _phuthuRepository.GetTracking(x => x.MaPhuThu.Equals(id) && x.TrangThai == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsPhuThu.PHUTHU_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _phuthuRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<PhuThuEntity> GetAllAsync()
        {
            var entities = _phuthuRepository.Get(_ => _.TrangThai == null).ToList();
            return (ICollection<PhuThuEntity>)entities;
        }

        public PhuThuEntity GetByKeyIdAsync(string id)
        {
            var entity = _phuthuRepository.GetSingle(_ => _.MaPhuThu.Equals(id) && _.TrangThai == null);
            return entity;
        }

        public Task UpdateAsync(string Id, PhuThuModel model, CancellationToken cancellationToken = default)
        {
            var entity = _phuthuRepository.GetTracking(x => x.MaPhuThu.Equals(Id) && x.TrangThai == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsPhuThu.PHUTHU_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.MaPhuThu != Id)
            {
                var isDuplicate = _phuthuRepository.GetTracking(x => x.MaPhuThu.Equals(model.MaPhuThu) && x.TrangThai == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsPhuThu.PHUTHU_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _phuthuRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            var entities = _phuthuRepository.Get(_ => _.TrangThai == null).ToList();
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

        PhuThuEntity IGetable<PhuThuEntity, string>.GetByLoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public PhuThuEntity GetBySDTAsync(string sdt)
        {
            throw new NotImplementedException();
        }
    }
}
