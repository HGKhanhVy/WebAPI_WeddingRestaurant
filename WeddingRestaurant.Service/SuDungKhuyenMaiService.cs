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
using WeddingRestaurant.Core.Models.SuDungKhuyenMai;

namespace WeddingRestaurant.Service
{
    [ScopedDependency(ServiceType = typeof(ISuDungKhuyenMaiService))]
    public class SuDungKhuyenMaiService : Base.Service, ISuDungKhuyenMaiService
    {

        private readonly ISuDungKhuyenMaiRepository _sdKMRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public SuDungKhuyenMaiService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _sdKMRepository = serviceProvider.GetRequiredService<ISuDungKhuyenMaiRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(SuDungKhuyenMaiModel model, CancellationToken cancellationToken = default)
        {
            if (_sdKMRepository.Get(_ => _.MaTiec == model.MaTiec && _.MaKM == model.MaKM && _.DeletedTime == null).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.MaTiec);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsSuDungKhuyenMai.SUDUNGKHUYENMAI_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<SuDungKhuyenMaiEntity>(model);
            _sdKMRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.MaTiec + " - " + entity.MaKM);
        }

        public Task DeleteAsync(string id, string id_Tiec, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _sdKMRepository.GetTracking(x => x.MaKM == id && x.MaTiec == id_Tiec && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsSuDungKhuyenMai.SUDUNGKHUYENMAI_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _sdKMRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<SuDungKhuyenMaiEntity> GetAllAsync()
        {
            var entities = _sdKMRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<SuDungKhuyenMaiEntity>)entities;
        }
        public SuDungKhuyenMaiEntity GetByKeyIdAsync(string id)
        {
            var entity = _sdKMRepository.GetSingle(_ => _.MaTiec == id && _.DeletedTime == null);
            return entity;
        }
        public SuDungKhuyenMaiEntity GetByKeyIdAsync(string id, string id_Tiec)
        {
            var entity = _sdKMRepository.GetSingle(_ => _.MaKM == id && _.MaTiec == id_Tiec && _.DeletedTime == null);
            return entity;
        }

        public Task UpdateAsync(string Id, string id_Tiec, SuDungKhuyenMaiModel model, CancellationToken cancellationToken = default)
        {
            var entity = _sdKMRepository.GetTracking(x => x.MaKM == Id && x.MaTiec == id_Tiec && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsSuDungKhuyenMai.SUDUNGKHUYENMAI_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.MaKM != Id && model.MaTiec != Id)
            {
                var isDuplicate = _sdKMRepository.GetTracking(x => x.MaKM == model.MaKM && x.MaTiec == model.MaTiec && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsSuDungKhuyenMai.SUDUNGKHUYENMAI_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _sdKMRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            var entities = _sdKMRepository.Get(_ => _.DeletedTime == null).ToList();
            int count = 0;
            foreach (var entity in entities)
                count++;
            return Task.FromResult(count);
        }

        // KHÔNG SỬ DỤNG
        public NguoiDungEntity GetByUserNameAsync(RefreshTokenEntity model)
        {
            throw new NotImplementedException();
        }
    }
}
