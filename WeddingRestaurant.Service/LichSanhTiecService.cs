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
            if (_lichRepository.Get(_ => _.MaTiec.Equals(model.MaTiec) && _.MaSanh.Equals(model.MaSanh) && _.TrangThai == null).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.MaTiec + " - " + model.MaSanh);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsLichSanhTiec.LICHSANHTIEC_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<LichSanhTiecEntity>(model);
            entity.MaTiec = model.MaTiec;
            entity.MaSanh = model.MaSanh;
            _lichRepository.Add(entity);
            UnitOfWork.SaveChange();
            return entity.MaTiec + " - " + entity.MaSanh;
        }

        public Task DeleteAsync(string id, string id_Tiec, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _lichRepository.GetTracking(x => x.MaSanh.Equals(id) && x.MaTiec.Equals(id_Tiec) && x.TrangThai == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id + " - " + id_Tiec);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsLichSanhTiec.LICHSANHTIEC_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _lichRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da huy";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<LichSanhTiecEntity> GetAllAsync()
        {
            var entities = _lichRepository.Get(_ => _.TrangThai == null).ToList();
            return (ICollection<LichSanhTiecEntity>)entities;
        }

        public LichSanhTiecEntity GetByKeyIdAsync(string id, string id_Tiec)
        {
            var entity = _lichRepository.GetSingle(_ => _.MaSanh.Equals(id) && _.MaTiec.Equals(id_Tiec) && _.TrangThai == null);
            return entity;
        }

        public Task UpdateAsync(string Id, string id_Tiec, LichSanhTiecModel model, CancellationToken cancellationToken = default)
        {
            var entity = _lichRepository.GetTracking(x => x.MaSanh.Equals(Id) && x.MaTiec.Equals(id_Tiec) && x.TrangThai == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id + " - " + id_Tiec);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsLichSanhTiec.LICHSANHTIEC_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.MaSanh != Id && model.MaTiec != id_Tiec)
            {
                var isDuplicate = _lichRepository.GetTracking(x => x.MaSanh.Equals(model.MaSanh) && x.MaTiec.Equals(model.MaTiec) && x.TrangThai == null).FirstOrDefault();
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
            var entities = _lichRepository.Get(_ => _.TrangThai == null).ToList();
            int count = 0;
            foreach (var entity in entities)
                count++;
            return Task.FromResult(count);
        }
        public ICollection<LichSanhTiecEntity> GetAllLichSanhByIDAsync(string id)
        {
            var entities = _lichRepository.Get(_ => _.MaSanh.Equals(id) && _.TrangThai == null).ToList();
            return (ICollection<LichSanhTiecEntity>)entities;
        }
        public ICollection<LichSanhTiecEntity> GetAllLichSanhByNTCAsync(string ntc)
        {
            if (DateTime.TryParse(ntc, out DateTime dateTime))
            {
                var entities = _lichRepository.Get(_ => _.NgayDienRa.Day == dateTime.Day && _.TrangThai == null).ToList();
                return (ICollection<LichSanhTiecEntity>)entities;
            }
            return new List<LichSanhTiecEntity>();
        }
        public List<LichSanhTiecEntity> SortOrderByAsyn()
        {
            var entities = _lichRepository.Get(_ => _.TrangThai == null)
                                          .OrderBy(entity => entity.NgayDienRa) 
                                          .ToList();
            
            return entities;
        }
        public List<LichSanhTiecEntity> SortOrderByDescendingAsyn()
        {
            var entities = _lichRepository.Get(_ => _.TrangThai == null)
                                          .OrderByDescending(entity => entity.NgayDienRa)
                                          .ToList();

            return entities;
        }

        public ICollection<LichSanhTiecEntity> GetAllByKey1Async(string id)
        {
            var entities = _lichRepository.Get(_ => _.MaTiec.Equals(id)).ToList();
            return (ICollection<LichSanhTiecEntity>)entities;
        }

        public ICollection<LichSanhTiecEntity> GetAllByKey2Async(string id)
        {
            var entities = _lichRepository.Get(_ => _.MaSanh.Equals(id)).ToList();
            return (ICollection<LichSanhTiecEntity>)entities;
        }

        // KHÔNG SỬ DỤNG
        public NguoiDungEntity GetByUserNameAsync(RefreshTokenEntity model)
        {
            throw new NotImplementedException();
        }
    }
}
