using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Contract.Service;
using WeddingRestaurant.Core.Constants;
using WeddingRestaurant.Core.Exceptions;
using WeddingRestaurant.Core.Models.DatTiec;
using WeddingRestaurant.Core.Models;
using WeddingRestaurant.Core.Models.LoaiNuoc;
using WeddingRestaurant.Service;

namespace WeddingRestaurant.WebApi.Controllers
{
    [ApiController]
    public class LoaiNuocController : ControllerBase
    {
        private readonly ILoaiNuocService _iLoaiNuocService;

        public LoaiNuocController(ILoaiNuocService iLoaiNuocService)
        {
            _iLoaiNuocService = iLoaiNuocService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.LoaiNuoc.GetAllLoaiNuoc)]
        public IActionResult GetAll()
        {
            var result = _iLoaiNuocService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<LoaiNuocEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.LoaiNuoc.GetLoaiNuoc)]
        public IActionResult GetLoaiNuocById([FromRoute] string MaLoaiNuoc)
        {
            var data = _iLoaiNuocService.GetByKeyIdAsync(MaLoaiNuoc);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsLoaiNuoc.LOAINUOC_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<LoaiNuocEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.LoaiNuoc.AddLoaiNuoc)]
        public async Task<IActionResult> CreateLoaiNuoc(LoaiNuocModel model)
        {
            try
            {
                var result = await _iLoaiNuocService.CreateAsync(model);
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
        [Route(WebApiEndpoint.LoaiNuoc.UpdateLoaiNuoc)]
        public async Task<IActionResult> UpdateLoaiNuoc([FromRoute] string MaLoaiNuoc, LoaiNuocModel model)
        {
            try
            {
                await _iLoaiNuocService.UpdateAsync(MaLoaiNuoc, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsLoaiNuoc.UPDATE_LOAINUOC_SUCCESS));
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
        [Route(WebApiEndpoint.LoaiNuoc.DeleteLoaiNuoc)]
        public async Task<IActionResult> DeleteLoaiNuoc([FromRoute] string MaLoaiNuoc)
        {
            try
            {
                await _iLoaiNuocService.DeleteAsync(MaLoaiNuoc, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsLoaiNuoc.DELETE_LOAINUOC_SUCCESS));
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
        [Route(WebApiEndpoint.LoaiNuoc.CountLoaiNuoc)]
        public async Task<IActionResult> CountLoaiNuoc()
        {
            try
            {
                var result = await _iLoaiNuocService.CountAsync();
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
