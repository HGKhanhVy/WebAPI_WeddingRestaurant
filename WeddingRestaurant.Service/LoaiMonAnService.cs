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
using WeddingRestaurant.Core.Models.LoaiMonAn;
using WeddingRestaurant.Core.Models.Login;

namespace WeddingRestaurant.Service
{
    [ScopedDependency(ServiceType = typeof(ILoaiMonAnService))]
    public class LoaiMonAnService : Base.Service, ILoaiMonAnService
    {

        private readonly ILoaiMonAnRepository _loaiMARepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public LoaiMonAnService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _loaiMARepository = serviceProvider.GetRequiredService<ILoaiMonAnRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(LoaiMonAnModel model, CancellationToken cancellationToken = default)
        {
            if (_loaiMARepository.Get(_ => _.MaLoaiMon == model.MaLoaiMon && _.DeletedTime == null).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.MaLoaiMon);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsLoaiMonAn.LOAIMONAN_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<LoaiMonAnEntity>(model);
            _loaiMARepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.MaLoaiMon);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _loaiMARepository.GetTracking(x => x.MaLoaiMon == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsLoaiMonAn.LOAIMONAN_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _loaiMARepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<LoaiMonAnEntity> GetAllAsync()
        {
            var entities = _loaiMARepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<LoaiMonAnEntity>)entities;
        }

        public LoaiMonAnEntity GetByKeyIdAsync(string id)
        {
            var entity = _loaiMARepository.GetSingle(_ => _.MaLoaiMon == id && _.DeletedTime == null);
            return entity;
        }

        public Task UpdateAsync(string Id, LoaiMonAnModel model, CancellationToken cancellationToken = default)
        {
            var entity = _loaiMARepository.GetTracking(x => x.MaLoaiMon == Id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsLoaiMonAn.LOAIMONAN_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.MaLoaiMon != Id)
            {
                var isDuplicate = _loaiMARepository.GetTracking(x => x.MaLoaiMon == model.MaLoaiMon && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsLoaiMonAn.LOAIMONAN_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _loaiMARepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            var entities = _loaiMARepository.Get(_ => _.DeletedTime == null).ToList();
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

        LoaiMonAnEntity IGetable<LoaiMonAnEntity, string>.GetByLoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public LoaiMonAnEntity GetBySDTAsync(string sdt)
        {
            throw new NotImplementedException();
        }
    }
}
