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

namespace WeddingRestaurant.Service
{
    [ScopedDependency(ServiceType = typeof(ILichSanhTiecService))]
    public class LichSanhTiecService : Base.Service, ILichSanhTiecService
    {
        private readonly ILichSanhTiecRepository _lichRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public LichSanhTiecService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _lichRepository = serviceProvider.GetRequiredService<ILichSanhTiecRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public async Task<string> CreateAsync(LichSanhTiecModel model, CancellationToken cancellationToken = default)
        {
            if (_lichRepository.Get(_ => _.MaTiec == model.MaTiec && _.MaSanh == model.MaSanh && _.DeletedTime == null).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.MaTiec);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsLichSanhTiec.LICHSANHTIEC_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<LichSanhTiecEntity>(model);
            _lichRepository.Add(entity);
            UnitOfWork.SaveChange();
            return entity.MaTiec + " - " + entity.MaSanh;
        }

        public Task DeleteAsync(string id, string id_Tiec, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _lichRepository.GetTracking(x => x.MaSanh == id && x.MaTiec == id_Tiec && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsLichSanhTiec.LICHSANHTIEC_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _lichRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<LichSanhTiecEntity> GetAllAsync()
        {
            var entities = _lichRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<LichSanhTiecEntity>)entities;
        }

        public LichSanhTiecEntity GetByKeyIdAsync(string id, string id_Tiec)
        {
            var entity = _lichRepository.GetSingle(_ => _.MaSanh == id && _.MaTiec == id_Tiec && _.DeletedTime == null);
            return entity;
        }

        public Task UpdateAsync(string Id, string id_Tiec, LichSanhTiecModel model, CancellationToken cancellationToken = default)
        {
            var entity = _lichRepository.GetTracking(x => x.MaSanh == Id && x.MaTiec == id_Tiec && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsLichSanhTiec.LICHSANHTIEC_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.MaSanh != Id && model.MaTiec != id_Tiec)
            {
                var isDuplicate = _lichRepository.GetTracking(x => x.MaSanh == model.MaSanh && x.MaTiec == model.MaTiec && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsLichSanhTiec.LICHSANHTIEC_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _lichRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            var entities = _lichRepository.Get(_ => _.DeletedTime == null).ToList();
            int count = 0;
            foreach (var entity in entities)
                count++;
            return Task.FromResult(count);
        }
        public ICollection<LichSanhTiecEntity> GetAllLichSanhByIDAsync(string id)
        {
            var entities = _lichRepository.Get(_ => _.MaSanh == id && _.DeletedTime == null).ToList();
            return (ICollection<LichSanhTiecEntity>)entities;
        }
        public ICollection<LichSanhTiecEntity> GetAllLichSanhByNTCAsync(string ntc)
        {
            if (DateTimeOffset.TryParse(ntc, out DateTimeOffset dateTimeOffset))
            {
                var entities = _lichRepository.Get(_ => _.NgayToChuc.Date == dateTimeOffset.Date && _.DeletedTime == null).ToList();
                return (ICollection<LichSanhTiecEntity>)entities;
            }
            return new List<LichSanhTiecEntity>();
        }
        public List<LichSanhTiecEntity> SortOrderByAsyn()
        {
            var entities = _lichRepository.Get(_ => _.DeletedTime == null)
                                          .OrderBy(entity => entity.NgayToChuc) 
                                          .ToList();
            
            return entities;
        }
        public List<LichSanhTiecEntity> SortOrderByDescendingAsyn()
        {
            var entities = _lichRepository.Get(_ => _.DeletedTime == null)
                                          .OrderByDescending(entity => entity.NgayToChuc)
                                          .ToList();

            return entities;
        }

        // KHÔNG SỬ DỤNG
        public NguoiDungEntity GetByUserNameAsync(RefreshTokenEntity model)
        {
            throw new NotImplementedException();
        }
    }
}
