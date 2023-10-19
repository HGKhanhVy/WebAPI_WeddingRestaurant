using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Contract.Service;
using WeddingRestaurant.Core.Constants;
using WeddingRestaurant.Core.Exceptions;
using WeddingRestaurant.Core.Models.DatTiec;
using WeddingRestaurant.Core.Models;
using static WeddingRestaurant.Core.Constants.WebApiEndpoint;
using WeddingRestaurant.Core.Models.ChiTietDichVu;

namespace WeddingRestaurant.WebApi.Controllers
{
    [ApiController]
    public class ChiTietDichVuController : ControllerBase
    {
        private readonly IChiTietDichVuService _iChiTietDichVuService;

        public ChiTietDichVuController(IChiTietDichVuService iChiTietDichVuService)
        {
            _iChiTietDichVuService = iChiTietDichVuService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.ChiTietDichVu.GetAllChiTietDichVu)]
        public IActionResult GetAll()
        {
            var result = _iChiTietDichVuService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<ChiTietDichVuEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.ChiTietDichVu.GetChiTietDichVu)]
        public IActionResult GetChiTietDichVuById(string keyId, string id_Tiec)
        {
            var data = _iChiTietDichVuService.GetByKeyIdAsync(keyId, id_Tiec);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsChiTietDichVu.CHITIETDICHVU_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ChiTietDichVuEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.ChiTietDichVu.AddChiTietDichVu)]
        [Authorize]
        public async Task<IActionResult> CreateChiTietDichVu(ChiTietDichVuModel model)
        {
            try
            {
                var result = await _iChiTietDichVuService.CreateAsync(model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status201Created,
                    code: ResponseCodeConstants.SUCCESS,
                    data: result));
            }
            catch (Exception e)
            {
                dynamic result;
                if (e is CoreException error)
                {
                    result = new BaseResponseModel<string>(
                        statusCode: error.StatusCode,
                        code: error.Code,
                        message: error.Message);
                    return BadRequest(result);
                }
                result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status500InternalServerError,
                    code: ResponseCodeConstants.FAILED,
                    message: e.Message);
                return BadRequest(result);
            }
        }

        [HttpPut]
        [Route(WebApiEndpoint.ChiTietDichVu.UpdateChiTietDichVu)]
        [Authorize]
        public async Task<IActionResult> UpdateChiTietDichVu(string keyId, string id_Tiec, ChiTietDichVuModel model)
        {
            try
            {
                await _iChiTietDichVuService.UpdateAsync(keyId, id_Tiec, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsChiTietDichVu.UPDATE_CHITIETDICHVU_SUCCESS));
            }
            catch (Exception e)
            {
                dynamic result;
                if (e is CoreException error)
                {
                    result = new BaseResponseModel<string>(
                        statusCode: error.StatusCode,
                        code: error.Code,
                        message: error.Message);
                    return BadRequest(result);
                }
                result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status500InternalServerError,
                    code: ResponseCodeConstants.FAILED,
                    message: e.Message);
                return BadRequest(result);
            }

        }

        [HttpDelete]
        [Route(WebApiEndpoint.ChiTietDichVu.DeleteChiTietDichVu)]
        [Authorize]
        public async Task<IActionResult> DeleteChiTietDichVu(string keyId, string id_Tiec)
        {
            try
            {
                await _iChiTietDichVuService.DeleteAsync(keyId, id_Tiec, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsChiTietDichVu.DELETE_CHITIETDICHVU_SUCCESS));
            }
            catch (Exception e)
            {
                dynamic result;
                if (e is CoreException error)
                {
                    result = new BaseResponseModel<string>(
                        statusCode: error.StatusCode,
                        code: error.Code,
                        message: error.Message);
                    return BadRequest(result);
                }
                result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status500InternalServerError,
                    code: ResponseCodeConstants.FAILED,
                    message: e.Message);
                return BadRequest(result);
            }
        }

        [HttpGet]
        [Route(WebApiEndpoint.ChiTietDichVu.CountChiTietDichVu)]
        public async Task<IActionResult> CountChiTietDichVu()
        {
            try
            {
                var result = await _iChiTietDichVuService.CountAsync();
                return Ok(new BaseResponseModel<int>(
                    statusCode: StatusCodes.Status201Created,
                    code: ResponseCodeConstants.SUCCESS,
                    data: result));
            }
            catch (Exception e)
            {
                dynamic result;
                if (e is CoreException error)
                {
                    result = new BaseResponseModel<string>(
                        statusCode: error.StatusCode,
                        code: error.Code,
                        message: error.Message);
                    return BadRequest(result);
                }
                result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status500InternalServerError,
                    code: ResponseCodeConstants.FAILED,
                    message: e.Message);
                return BadRequest(result);
            }
        }
    }
}
