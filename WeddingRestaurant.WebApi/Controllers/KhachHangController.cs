using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Contract.Service;
using WeddingRestaurant.Core.Constants;
using WeddingRestaurant.Core.Exceptions;
using WeddingRestaurant.Core.Models.DatTiec;
using WeddingRestaurant.Core.Models;
using WeddingRestaurant.Core.Models.KhachHang;

namespace WeddingRestaurant.WebApi.Controllers
{
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private readonly IKhachHangService _iKhachHangService;

        public KhachHangController(IKhachHangService iKhachHangService)
        {
            _iKhachHangService = iKhachHangService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.KhachHang.GetAllKhachHang)]
        public IActionResult GetAll()
        {
            var result = _iKhachHangService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<KhachHangEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.KhachHang.GetKhachHang)]
        public IActionResult GetKhachHangBySDT(string sdt)
        {
            var data = _iKhachHangService.GetBySDTAsync(sdt);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsKhachHang.KHACHHANG_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<KhachHangEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.KhachHang.AddKhachHang)]
        public async Task<IActionResult> CreateKhachHang(KhachHangModel model)
        {
            try
            {
                var result = await _iKhachHangService.CreateAsync(model);
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
        [Route(WebApiEndpoint.KhachHang.UpdateKhachHang)]
        [Authorize]
        public async Task<IActionResult> UpdateKhachHang(string keyId, KhachHangModel model)
        {
            try
            {
                await _iKhachHangService.UpdateAsync(keyId, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsKhachHang.UPDATE_KHACHHANG_SUCCESS));
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
        [Route(WebApiEndpoint.KhachHang.DeleteKhachHang)]
        [Authorize]
        public async Task<IActionResult> DeleteKhachHang(string keyId)
        {
            try
            {
                await _iKhachHangService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsKhachHang.DELETE_KHACHHANG_SUCCESS));
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
        [Route(WebApiEndpoint.KhachHang.CountKhachHang)]
        public async Task<IActionResult> CountKhachHang()
        {
            try
            {
                var result = await _iKhachHangService.CountAsync();
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
