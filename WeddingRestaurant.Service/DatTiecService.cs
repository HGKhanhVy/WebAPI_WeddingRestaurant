using AngleSharp.Dom;
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
using WeddingRestaurant.Core.Constants;
using WeddingRestaurant.Core.Exceptions;
using WeddingRestaurant.Core.Models.DatTiec;
using WeddingRestaurant.Core.Models.LoaiDichVu;
using WeddingRestaurant.Core.Models.Login;

namespace WeddingRestaurant.Service
{
    [ScopedDependency(ServiceType = typeof(IDatTiecService))]
    public class DatTiecService : Base.Service, IDatTiecService
    {

        private readonly IDatTiecRepository _datTiecRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public DatTiecService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _datTiecRepository = serviceProvider.GetRequiredService<IDatTiecRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(DatTiecModel model, CancellationToken cancellationToken = default)
        {
            if (_datTiecRepository.Get(_ => _.MaTiec.Equals(model.MaTiec) && _.TrangThai == null).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.MaTiec);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsLoaiDichVu.LOAIDICHVU_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<DatTiecEntity>(model);
            entity.MaTiec = model.MaTiec;
            _datTiecRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.MaTiec);
        }


        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _datTiecRepository.GetTracking(x => x.MaTiec.Equals(id) && !x.TrangThai.Equals("Đã hủy")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsDatTiec.TIEC_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _datTiecRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Đã hủy";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<DatTiecEntity> GetAllAsync()
        {
            var entities = _datTiecRepository.Get(_ => !_.TrangThai.Equals("Đã hủy")).ToList();
            return (ICollection<DatTiecEntity>)entities;
        }

        public DatTiecEntity GetByKeyIdAsync(string id)
        {
            var entity = _datTiecRepository.GetSingle(_ => _.MaTiec.Equals(id) && !_.TrangThai.Equals("Đã hủy"));
            return entity;
        }

        public Task UpdateAsync(string Id, DatTiecModel model, CancellationToken cancellationToken = default)
        {
            var entity = _datTiecRepository.GetTracking(x => x.MaTiec.Equals(Id) && !x.TrangThai.Equals("Đã hủy")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsDatTiec.TIEC_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.MaTiec != Id)
            {
                var isDuplicate = _datTiecRepository.GetTracking(x => x.MaTiec.Equals(model.MaTiec) && !x.TrangThai.Equals("Đã hủy")).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsDatTiec.TIEC_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _datTiecRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            var entities = _datTiecRepository.Get(_ => !_.TrangThai.Equals("Đã hủy")).ToList();
            int count = 0;
            foreach (var entity in entities)
                count++;
            return Task.FromResult(count);
        }
        public List<DatTiecEntity> SortOrderByAsyn()
        {
            var entities = _datTiecRepository.Get(_ => !_.TrangThai.Equals("Đã hủy"))
                                          .OrderBy(entity => entity.NgayToChuc)
                                          .ToList();

            return entities;
        }
        public List<DatTiecEntity> SortOrderByDescendingAsyn()
        {
            var entities = _datTiecRepository.Get(_ => !_.TrangThai.Equals("Đã hủy"))
                                          .OrderByDescending(entity => entity.NgayToChuc)
                                          .ToList();

            return entities;
        }

        public async Task UpdateStatusAsync()
        {
            throw new NotImplementedException();
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

        public DatTiecEntity GetBySDTAsync(string sdt)
        {
            throw new NotImplementedException();
        }
    }
}
