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
using WeddingRestaurant.Core.Models.HoaDon;
using WeddingRestaurant.Core.Models.Login;

namespace WeddingRestaurant.Service
{
    [ScopedDependency(ServiceType = typeof(IHoaDonService))]
    public class HoaDonService : Base.Service, IHoaDonService
    {

        private readonly IHoaDonRepository _hdRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public HoaDonService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _hdRepository = serviceProvider.GetRequiredService<IHoaDonRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(HoaDonModel model, CancellationToken cancellationToken = default)
        {
            if (_hdRepository.Get(_ => _.MaHoaDon.Equals(model.MaHoaDon) && !_.TrangThai.Equals("Da xoa")).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.MaHoaDon);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsHoaDon.HOADON_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<HoaDonEntity>(model);
            entity.MaHoaDon = model.MaHoaDon;
            _hdRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.MaHoaDon);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _hdRepository.GetTracking(x => x.MaHoaDon.Equals(id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsHoaDon.HOADON_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _hdRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<HoaDonEntity> GetAllAsync()
        {
            var entities = _hdRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            return (ICollection<HoaDonEntity>)entities;
        }

        public HoaDonEntity GetByKeyIdAsync(string id)
        {
            var entity = _hdRepository.GetSingle(_ => _.MaHoaDon.Equals(id) && !_.TrangThai.Equals("Da xoa"));
            return entity;
        }

        public Task UpdateAsync(string Id, HoaDonModel model, CancellationToken cancellationToken = default)
        {
            var entity = _hdRepository.GetTracking(x => x.MaHoaDon.Equals(Id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsHoaDon.HOADON_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.MaHoaDon != Id)
            {
                var isDuplicate = _hdRepository.GetTracking(x => x.MaHoaDon.Equals(model.MaHoaDon) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsHoaDon.HOADON_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _hdRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            var entities = _hdRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
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

        HoaDonEntity IGetable<HoaDonEntity, string>.GetByLoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public HoaDonEntity GetBySDTAsync(string sdt)
        {
            throw new NotImplementedException();
        }
    }
}
