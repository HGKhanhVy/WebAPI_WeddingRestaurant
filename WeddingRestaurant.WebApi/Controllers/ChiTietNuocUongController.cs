using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Contract.Service;
using WeddingRestaurant.Core.Constants;
using WeddingRestaurant.Core.Exceptions;
using WeddingRestaurant.Core.Models.ChiTietNuocUong;
using WeddingRestaurant.Core.Models;

namespace WeddingRestaurant.WebApi.Controllers
{
    [ApiController]
    public class ChiTietNuocUongController : ControllerBase
    {
        private readonly IChiTietNuocUongService _iChiTietNuocUongService;

        public ChiTietNuocUongController(IChiTietNuocUongService iChiTietNuocUongService)
        {
            _iChiTietNuocUongService = iChiTietNuocUongService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.ChiTietNuocUong.GetAllChiTietNuocUong)]
        public IActionResult GetAll()
        {
            var result = _iChiTietNuocUongService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<ChiTietNuocUongEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.ChiTietNuocUong.GetChiTietNuocUong)]
        public IActionResult GetChiTietNuocUongById(string keyId, string id_Tiec)
        {
            var data = _iChiTietNuocUongService.GetByKeyIdAsync(keyId, id_Tiec);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsChiTietNuocUong.CHITIETNUOCUONG_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ChiTietNuocUongEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.ChiTietNuocUong.AddChiTietNuocUong)]
        [Authorize]
        public async Task<IActionResult> CreateChiTietNuocUong(ChiTietNuocUongModel model)
        {
            try
            {
                var result = await _iChiTietNuocUongService.CreateAsync(model);
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
        [Route(WebApiEndpoint.ChiTietNuocUong.UpdateChiTietNuocUong)]
        [Authorize]
        public async Task<IActionResult> UpdateChiTietNuocUong(string keyId, string id_Tiec, ChiTietNuocUongModel model)
        {
            try
            {
                await _iChiTietNuocUongService.UpdateAsync(keyId, id_Tiec, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsChiTietNuocUong.UPDATE_CHITIETNUOCUONG_SUCCESS));
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
        [Route(WebApiEndpoint.ChiTietNuocUong.DeleteChiTietNuocUong)]
        [Authorize]
        public async Task<IActionResult> DeleteChiTietNuocUong(string keyId, string id_Tiec)
        {
            try
            {
                await _iChiTietNuocUongService.DeleteAsync(keyId, id_Tiec, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsChiTietNuocUong.DELETE_CHITIETNUOCUONG_SUCCESS));
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
        [Route(WebApiEndpoint.ChiTietNuocUong.CountChiTietNuocUong)]
        public async Task<IActionResult> CountChiTietNuocUong()
        {
            try
            {
                var result = await _iChiTietNuocUongService.CountAsync();
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
