using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Contract.Service;
using WeddingRestaurant.Core.Constants;
using WeddingRestaurant.Core.Exceptions;
using WeddingRestaurant.Core.Models.DatTiec;
using WeddingRestaurant.Core.Models;
using WeddingRestaurant.Core.Models.Sanh;

namespace WeddingRestaurant.WebApi.Controllers
{
    [ApiController]
    public class SanhController : ControllerBase
    {
        private readonly ISanhService _iSanhService;

        public SanhController(ISanhService iSanhService)
        {
            _iSanhService = iSanhService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.Sanh.GetAllSanh)]
        public IActionResult GetAll()
        {
            var result = _iSanhService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<SanhEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.Sanh.GetSanh)]
        public IActionResult GetSanhById(string keyId)
        {
            var data = _iSanhService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsSanh.SANH_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<SanhEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.Sanh.AddSanh)]
        public async Task<IActionResult> CreateSanh(SanhModel model)
        {
            try
            {
                var result = await _iSanhService.CreateAsync(model);
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
        [Route(WebApiEndpoint.Sanh.UpdateSanh)]
        [Authorize]
        public async Task<IActionResult> UpdateSanh(string keyId, SanhModel model)
        {
            try
            {
                await _iSanhService.UpdateAsync(keyId, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsSanh.UPDATE_SANH_SUCCESS));
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
        [Route(WebApiEndpoint.Sanh.DeleteSanh)]
        [Authorize]
        public async Task<IActionResult> DeleteSanh(string keyId)
        {
            try
            {
                await _iSanhService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsSanh.DELETE_SANH_SUCCESS));
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
        [Route(WebApiEndpoint.Sanh.CountSanh)]
        public async Task<IActionResult> CountSanh()
        {
            try
            {
                var result = await _iSanhService.CountAsync();
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
        [Route(WebApiEndpoint.Sanh.PrintSucChua)]
        public IActionResult GetSucChuaById(string keyId)
        {
            var data = _iSanhService.PrintSucChuaAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsSanh.SANH_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<string?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }
    }
}
