using Microsoft.AspNetCore.Mvc;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Contract.Service;
using WeddingRestaurant.Core.Constants;
using WeddingRestaurant.Core.Exceptions;
using WeddingRestaurant.Core.Models;
using WeddingRestaurant.Core.Models.DatTiec;
using Microsoft.AspNetCore.Authorization;
using WeddingRestaurant.Service;


namespace WeddingRestaurant.WebApi.Controllers
{
    [ApiController]
    public class DatTiecController : ControllerBase
    {
        private readonly IDatTiecService _iDatTiecService;

        public DatTiecController(IDatTiecService iDatTiecService)
        {
            _iDatTiecService = iDatTiecService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.DatTiec.GetAllDatTiec)]
        public IActionResult GetAll()
        {
            var result = _iDatTiecService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<DatTiecEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.DatTiec.GetDatTiec)]
        public IActionResult GetDatTiecById(string keyId)
        {
            var data = _iDatTiecService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsDatTiec.TIEC_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<DatTiecEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.DatTiec.AddDatTiec)]
        public async Task<IActionResult> CreateDatTiec(DatTiecModel model)
        {
            try
            {
                var result = await _iDatTiecService.CreateAsync(model);
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
        [Route(WebApiEndpoint.DatTiec.UpdateDatTiec)]
        [Authorize]
        public async Task<IActionResult> UpdateDatTiec(string keyId, DatTiecModel model)
        {
            try
            {
                await _iDatTiecService.UpdateAsync(keyId, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsDatTiec.UPDATE_TIEC_SUCCESS));
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
        [Route(WebApiEndpoint.DatTiec.DeleteDatTiec)]
        [Authorize]
        public async Task<IActionResult> DeleteDatTiec(string keyId)
        {
            try
            {
                await _iDatTiecService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsDatTiec.DELETE_TIEC_SUCCESS));
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
        [Route(WebApiEndpoint.DatTiec.CountDatTiec)]
        public async Task<IActionResult> CountTiec()
        {
            try
            {
                var result = await _iDatTiecService.CountAsync();
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
        [Route(WebApiEndpoint.DatTiec.SortByNgayToChuc)]
        public IActionResult SortOrderByNTCAsyn()
        {
            var result = _iDatTiecService.SortOrderByAsyn();
            return Ok(new BaseResponseModel<List<DatTiecEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }
        [HttpGet]
        [Route(WebApiEndpoint.DatTiec.SortByDescendingNgayToChuc)]
        public IActionResult SortByDescendingNTCAsyn()
        {
            var result = _iDatTiecService.SortOrderByDescendingAsyn();
            return Ok(new BaseResponseModel<List<DatTiecEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpPut]
        [Route(WebApiEndpoint.DatTiec.UpdateStatus)]
        public async Task<IActionResult> UpdateSatus()
        {
            try
            {
                await _iDatTiecService.UpdateStatusAsync();
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsDatTiec.UPDATE_TIEC_SUCCESS));
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
