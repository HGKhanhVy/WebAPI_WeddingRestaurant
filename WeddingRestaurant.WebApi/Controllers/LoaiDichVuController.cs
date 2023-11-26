using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Contract.Service;
using WeddingRestaurant.Core.Constants;
using WeddingRestaurant.Core.Exceptions;
using WeddingRestaurant.Core.Models.LoaiDichVu;
using WeddingRestaurant.Core.Models;

namespace WeddingRestaurant.WebApi.Controllers
{
    [ApiController]
    public class LoaiDichVuController : ControllerBase
    {
        private readonly ILoaiDichVuService _iLoaiDichVuService;

        public LoaiDichVuController(ILoaiDichVuService iLoaiDichVuService)
        {
            _iLoaiDichVuService = iLoaiDichVuService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.LoaiDichVu.GetAllLoaiDichVu)]
        public IActionResult GetAll()
        {
            var result = _iLoaiDichVuService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<LoaiDichVuEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.LoaiDichVu.GetLoaiDichVu)]
        public IActionResult GetLoaiDichVuByID([FromRoute] string MaLoaiDichVu)
        {
            var data = _iLoaiDichVuService.GetByKeyIdAsync(MaLoaiDichVu);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsLoaiDichVu.LOAIDICHVU_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<LoaiDichVuEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.LoaiDichVu.AddLoaiDichVu)]
        public async Task<IActionResult> CreateLoaiDichVu(LoaiDichVuModel model)
        {
            try
            {
                var result = await _iLoaiDichVuService.CreateAsync(model);
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
        [Route(WebApiEndpoint.LoaiDichVu.UpdateLoaiDichVu)]
        public async Task<IActionResult> UpdateLoaiDichVu([FromRoute] string MaLoaiDichVu, LoaiDichVuModel model)
        {
            try
            {
                await _iLoaiDichVuService.UpdateAsync(MaLoaiDichVu, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsLoaiDichVu.UPDATE_LOAIDICHVU_SUCCESS));
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
        [Route(WebApiEndpoint.LoaiDichVu.DeleteLoaiDichVu)]
        public async Task<IActionResult> DeleteLoaiDichVu([FromRoute] string MaLoaiDichVu)
        {
            try
            {
                await _iLoaiDichVuService.DeleteAsync(MaLoaiDichVu, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsLoaiDichVu.DELETE_LOAIDICHVU_SUCCESS));
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
        [Route(WebApiEndpoint.LoaiDichVu.CountLoaiDichVu)]
        public async Task<IActionResult> CountLoaiDichVu()
        {
            try
            {
                var result = await _iLoaiDichVuService.CountAsync();
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
