using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Contract.Service;
using WeddingRestaurant.Core.Constants;
using WeddingRestaurant.Core.Exceptions;
using WeddingRestaurant.Core.Models.NhanVien;
using WeddingRestaurant.Core.Models;
using static WeddingRestaurant.Core.Constants.WebApiEndpoint;

namespace WeddingRestaurant.WebApi.Controllers
{
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        private readonly INhanVienService _iNhanVienService;

        public NhanVienController(INhanVienService iNhanVienService)
        {
            _iNhanVienService = iNhanVienService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.NhanVien.GetAllNhanVien)]
        public IActionResult GetAll()
        {
            var result = _iNhanVienService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<NhanVienEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.NhanVien.GetNhanVien)]
        public IActionResult GetNhanVienById([FromRoute] string MaNhanVien)
        {
            var data = _iNhanVienService.GetByKeyIdAsync(MaNhanVien);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsNhanVien.NHANVIEN_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<NhanVienEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.NhanVien.AddNhanVien)]
        public async Task<IActionResult> CreateNhanVien(NhanVienModel model)
        {
            try
            {
                var result = await _iNhanVienService.CreateAsync(model);
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
        [Route(WebApiEndpoint.NhanVien.UpdateNhanVien)]
        public async Task<IActionResult> UpdateNhanVien([FromRoute] string MaNhanVien, NhanVienModel model)
        {
            try
            {
                await _iNhanVienService.UpdateAsync(MaNhanVien, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsNhanVien.UPDATE_NHANVIEN_SUCCESS));
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
        [Route(WebApiEndpoint.NhanVien.DeleteNhanVien)]
        public async Task<IActionResult> DeleteNhanVien([FromRoute] string MaNhanVien)
        {
            try
            {
                await _iNhanVienService.DeleteAsync(MaNhanVien, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsNhanVien.DELETE_NHANVIEN_SUCCESS));
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
        [Route(WebApiEndpoint.NhanVien.CountNhanVien)]
        public async Task<IActionResult> CountNhanVien()
        {
            try
            {
                var result = await _iNhanVienService.CountAsync();
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
