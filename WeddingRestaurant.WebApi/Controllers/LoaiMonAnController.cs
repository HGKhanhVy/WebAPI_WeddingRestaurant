using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Contract.Service;
using WeddingRestaurant.Core.Constants;
using WeddingRestaurant.Core.Exceptions;
using WeddingRestaurant.Core.Models.DatTiec;
using WeddingRestaurant.Core.Models;
using WeddingRestaurant.Core.Models.LoaiMonAn;

namespace WeddingRestaurant.WebApi.Controllers
{
    [ApiController]
    public class LoaiMonAnController : ControllerBase
    {
        private readonly ILoaiMonAnService _iLoaiMonAnService;

        public LoaiMonAnController(ILoaiMonAnService iLoaiMonAnService)
        {
            _iLoaiMonAnService = iLoaiMonAnService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.LoaiMonAn.GetAllLoaiMonAn)]
        public IActionResult GetAll()
        {
            var result = _iLoaiMonAnService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<LoaiMonAnEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.LoaiMonAn.GetLoaiMonAn)]
        public IActionResult GetLoaiMonAnById([FromRoute] string MaLoaiMonAn)
        {
            var data = _iLoaiMonAnService.GetByKeyIdAsync(MaLoaiMonAn);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsLoaiMonAn.LOAIMONAN_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<LoaiMonAnEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.LoaiMonAn.AddLoaiMonAn)]
        public async Task<IActionResult> CreateLoaiMonAn(LoaiMonAnModel model)
        {
            try
            {
                var result = await _iLoaiMonAnService.CreateAsync(model);
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
        [Route(WebApiEndpoint.LoaiMonAn.UpdateLoaiMonAn)]
        public async Task<IActionResult> UpdateLoaiMonAn([FromRoute] string MaLoaiMonAn, LoaiMonAnModel model)
        {
            try
            {
                await _iLoaiMonAnService.UpdateAsync(MaLoaiMonAn, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsLoaiMonAn.UPDATE_LOAIMONAN_SUCCESS));
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
        [Route(WebApiEndpoint.LoaiMonAn.DeleteLoaiMonAn)]
        public async Task<IActionResult> DeleteLoaiMonAn([FromRoute] string MaLoaiMonAn)
        {
            try
            {
                await _iLoaiMonAnService.DeleteAsync(MaLoaiMonAn, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsLoaiMonAn.DELETE_LOAIMONAN_SUCCESS));
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
        [Route(WebApiEndpoint.LoaiMonAn.CountLoaiMonAn)]
        public async Task<IActionResult> CountLoaiMonAn()
        {
            try
            {
                var result = await _iLoaiMonAnService.CountAsync();
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
