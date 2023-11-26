using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Contract.Service;
using WeddingRestaurant.Core.Constants;
using WeddingRestaurant.Core.Exceptions;
using WeddingRestaurant.Core.Models.NhanVienTrongTiec;
using WeddingRestaurant.Core.Models;

namespace WeddingRestaurant.WebApi.Controllers
{
    [ApiController]
    public class NhanVienTrongTiecController : ControllerBase
    {
        private readonly INhanVienTrongTiecService _iNhanVienTrongTiecService;

        public NhanVienTrongTiecController(INhanVienTrongTiecService iNhanVienTrongTiecService)
        {
            _iNhanVienTrongTiecService = iNhanVienTrongTiecService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.NhanVienTrongTiec.GetAllNhanVienTrongTiec)]
        public IActionResult GetAll()
        {
            var result = _iNhanVienTrongTiecService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<NhanVienTrongTiecEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.NhanVienTrongTiec.GetNhanVienTrongTiec)]
        public IActionResult GetNhanVienTrongTiecById([FromRoute] string MaTiec, [FromRoute] string MaNhanVien)
        {
            var data = _iNhanVienTrongTiecService.GetByKeyIdAsync(MaTiec, MaNhanVien);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsNhanVienTrongTiec.NHANVIENTRONGTIEC_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<NhanVienTrongTiecEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.NhanVienTrongTiec.AddNhanVienTrongTiec)]
        public async Task<IActionResult> CreateNhanVienTrongTiec(NhanVienTrongTiecModel model)
        {
            try
            {
                var result = await _iNhanVienTrongTiecService.CreateAsync(model);
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
        [Route(WebApiEndpoint.NhanVienTrongTiec.UpdateNhanVienTrongTiec)]
        public async Task<IActionResult> UpdateNhanVienTrongTiec([FromRoute] string MaTiec, [FromRoute] string MaNhanVien, NhanVienTrongTiecModel model)
        {
            try
            {
                await _iNhanVienTrongTiecService.UpdateAsync(MaTiec, MaNhanVien, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsNhanVienTrongTiec.UPDATE_NHANVIENTRONGTIEC_SUCCESS));
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
        [Route(WebApiEndpoint.NhanVienTrongTiec.DeleteNhanVienTrongTiec)]
        public async Task<IActionResult> DeleteNhanVienTrongTiec([FromRoute] string MaTiec, [FromRoute] string MaNhanVien)
        {
            try
            {
                await _iNhanVienTrongTiecService.DeleteAsync(MaTiec, MaNhanVien, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsNhanVienTrongTiec.DELETE_NHANVIENTRONGTIEC_SUCCESS));
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
        [Route(WebApiEndpoint.NhanVienTrongTiec.CountNhanVienTrongTiec)]
        public async Task<IActionResult> CountNhanVienTrongTiec()
        {
            try
            {
                var result = await _iNhanVienTrongTiecService.CountAsync();
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

        [HttpGet]
        [Route(WebApiEndpoint.NhanVienTrongTiec.PrintAllNhanVienTrongTiecForTiec)]
        public IActionResult GetNhanVienTrongTiecByIdTiec([FromRoute] string MaTiec)
        {
            var data = _iNhanVienTrongTiecService.GetAllByKey1Async(MaTiec);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsNhanVienTrongTiec.NHANVIENTRONGTIEC_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ICollection<NhanVienTrongTiecEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpGet]
        [Route(WebApiEndpoint.NhanVienTrongTiec.PrintAllNhanVienTrongTiecForNhanVien)]
        public IActionResult GetNhanVienTrongTiecByIdNhanVien([FromRoute] string MaNhanVien)
        {
            var data = _iNhanVienTrongTiecService.GetAllByKey2Async(MaNhanVien);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsNhanVienTrongTiec.NHANVIENTRONGTIEC_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ICollection<NhanVienTrongTiecEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: data));
        }
    }
}
