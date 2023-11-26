using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Contract.Service;
using WeddingRestaurant.Core.Constants;
using WeddingRestaurant.Core.Exceptions;
using WeddingRestaurant.Core.Models.DichVuUuDai;
using WeddingRestaurant.Core.Models;

namespace WeddingRestaurant.WebApi.Controllers
{
    [ApiController]
    public class DichVuUuDaiController : ControllerBase
    {
        private readonly IDichVuUuDaiService _iDichVuUuDaiService;

        public DichVuUuDaiController(IDichVuUuDaiService iDichVuUuDaiService)
        {
            _iDichVuUuDaiService = iDichVuUuDaiService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.DichVuUuDai.GetAllDichVuUuDai)]
        public IActionResult GetAll()
        {
            var result = _iDichVuUuDaiService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<DichVuUuDaiEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.DichVuUuDai.GetDichVuUuDai)]
        public IActionResult GetDichVuUuDaiById([FromRoute] string MaDichVuUuDai)
        {
            var data = _iDichVuUuDaiService.GetByKeyIdAsync(MaDichVuUuDai);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsDichVuUuDai.DICHVUUUDAI_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<DichVuUuDaiEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.DichVuUuDai.AddDichVuUuDai)]
        [Authorize]
        public async Task<IActionResult> CreateDichVuUuDai(DichVuUuDaiModel model)
        {
            try
            {
                var result = await _iDichVuUuDaiService.CreateAsync(model);
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
        [Route(WebApiEndpoint.DichVuUuDai.UpdateDichVuUuDai)]
        [Authorize]
        public async Task<IActionResult> UpdateDichVuUuDai([FromRoute] string MaDichVuUuDai, DichVuUuDaiModel model)
        {
            try
            {
                await _iDichVuUuDaiService.UpdateAsync(MaDichVuUuDai, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsDichVuUuDai.UPDATE_DICHVUUUDAI_SUCCESS));
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
        [Route(WebApiEndpoint.DichVuUuDai.DeleteDichVuUuDai)]
        [Authorize]
        public async Task<IActionResult> DeleteDichVuUuDai([FromRoute] string MaDichVuUuDai)
        {
            try
            {
                await _iDichVuUuDaiService.DeleteAsync(MaDichVuUuDai, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsDichVuUuDai.DELETE_DICHVUUUDAI_SUCCESS));
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
        [Route(WebApiEndpoint.DichVuUuDai.CountDichVuUuDai)]
        public async Task<IActionResult> CountDichVuUuDai()
        {
            try
            {
                var result = await _iDichVuUuDaiService.CountAsync();
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
