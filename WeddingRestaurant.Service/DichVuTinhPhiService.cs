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
using WeddingRestaurant.Core.Models.DichVuTinhPhi;
using WeddingRestaurant.Core.Models.Login;

namespace WeddingRestaurant.Service
{
    [ScopedDependency(ServiceType = typeof(IDichVuTinhPhiService))]
    public class DichVuTinhPhiService : Base.Service, IDichVuTinhPhiService
    {

        private readonly IDichVuTinhPhiRepository _dvRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public DichVuTinhPhiService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _dvRepository = serviceProvider.GetRequiredService<IDichVuTinhPhiRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(DichVuTinhPhiModel model, CancellationToken cancellationToken = default)
        {
            if (_dvRepository.Get(_ => _.MaDichVuTinhPhi.Equals(model.MaDichVuTinhPhi) && _.TrangThai == null).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.MaDichVuTinhPhi);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsDichVuTinhPhi.DICHVUTINHPHI_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<DichVuTinhPhiEntity>(model);
            entity.MaDichVuTinhPhi = model.MaDichVuTinhPhi;
            _dvRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.MaDichVuTinhPhi);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _dvRepository.GetTracking(x => x.MaDichVuTinhPhi.Equals(id) && x.TrangThai == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsDichVuTinhPhi.DICHVUTINHPHI_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _dvRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<DichVuTinhPhiEntity> GetAllAsync()
        {
            var entities = _dvRepository.Get(_ => _.TrangThai == null).ToList();
            return (ICollection<DichVuTinhPhiEntity>)entities;
        }

        public DichVuTinhPhiEntity GetByKeyIdAsync(string id)
        {
            var entity = _dvRepository.GetSingle(_ => _.MaDichVuTinhPhi.Equals(id) && _.TrangThai == null);
            return entity;
        }

        public Task UpdateAsync(string Id, DichVuTinhPhiModel model, CancellationToken cancellationToken = default)
        {
            var entity = _dvRepository.GetTracking(x => x.MaDichVuTinhPhi.Equals(Id) && x.TrangThai == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsDichVuTinhPhi.DICHVUTINHPHI_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.MaDichVuTinhPhi != Id)
            {
                var isDuplicate = _dvRepository.GetTracking(x => x.MaDichVuTinhPhi.Equals(model.MaDichVuTinhPhi) && x.TrangThai == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsDichVuTinhPhi.DICHVUTINHPHI_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _dvRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            var entities = _dvRepository.Get(_ => _.TrangThai == null).ToList();
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

        DichVuTinhPhiEntity IGetable<DichVuTinhPhiEntity, string>.GetByLoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public DichVuTinhPhiEntity GetBySDTAsync(string sdt)
        {
            throw new NotImplementedException();
        }
    }
}
