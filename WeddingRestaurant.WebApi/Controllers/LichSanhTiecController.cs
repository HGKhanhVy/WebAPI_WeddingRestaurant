using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Contract.Service;
using WeddingRestaurant.Core.Constants;
using WeddingRestaurant.Core.Exceptions;
using WeddingRestaurant.Core.Models.LichSanhTiec;
using WeddingRestaurant.Core.Models;
using static WeddingRestaurant.Core.Constants.WebApiEndpoint;

namespace WeddingRestaurant.WebApi.Controllers
{
    [ApiController]
    public class LichSanhTiecController : ControllerBase
    {
        private readonly ILichSanhTiecService _iLichSanhTiecService;

        public LichSanhTiecController(ILichSanhTiecService iLichSanhTiecService)
        {
            _iLichSanhTiecService = iLichSanhTiecService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.LichSanhTiec.GetAllLichSanhTiec)]
        public IActionResult GetAll()
        {
            var result = _iLichSanhTiecService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<LichSanhTiecEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.LichSanhTiec.GetLichSanhTiec)]
        public IActionResult GetLichSanhTiecById(string keyId, string id_Tiec)
        {
            var data = _iLichSanhTiecService.GetByKeyIdAsync(keyId, id_Tiec);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsLichSanhTiec.LICHSANHTIEC_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<LichSanhTiecEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.LichSanhTiec.AddLichSanhTiec)]
        public async Task<IActionResult> CreateLichSanhTiec(LichSanhTiecModel model)
        {
            try
            {
                var result = await _iLichSanhTiecService.CreateAsync(model);
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
        [Route(WebApiEndpoint.LichSanhTiec.UpdateLichSanhTiec)]
        [Authorize]
        public async Task<IActionResult> UpdateLichSanhTiec(string keyId, string id_Tiec, LichSanhTiecModel model)
        {
            try
            {
                await _iLichSanhTiecService.UpdateAsync(keyId, id_Tiec, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsLichSanhTiec.UPDATE_LICHSANHTIEC_SUCCESS));
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
        [Route(WebApiEndpoint.LichSanhTiec.DeleteLichSanhTiec)]
        [Authorize]
        public async Task<IActionResult> DeleteLichSanhTiec(string keyId, string id_Tiec)
        {
            try
            {
                await _iLichSanhTiecService.DeleteAsync(keyId, id_Tiec, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsLichSanhTiec.DELETE_LICHSANHTIEC_SUCCESS));
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
        [Route(WebApiEndpoint.LichSanhTiec.CountLichSanhTiec)]
        public async Task<IActionResult> CountLichSanhTiec()
        {
            try
            {
                var result = await _iLichSanhTiecService.CountAsync();
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
        [Route(WebApiEndpoint.LichSanhTiec.PrintAllLichForSanh)]
        public IActionResult GetAllLichForSanh([FromRoute] string MaSanh)
        {
            var result = _iLichSanhTiecService.GetAllLichSanhByIDAsync(MaSanh);
            return Ok(new BaseResponseModel<ICollection<LichSanhTiecEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.LichSanhTiec.PrintAllLichForNgayToChuc)]
        public IActionResult GetAllLichForNgayToChuc([FromRoute] string NgayToChuc)
        {
            var result = _iLichSanhTiecService.GetAllLichSanhByNTCAsync(NgayToChuc);
            return Ok(new BaseResponseModel<ICollection<LichSanhTiecEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }


        [HttpGet]
        [Route(WebApiEndpoint.LichSanhTiec.SortByNgayToChuc)]
        public IActionResult SortOrderByNTCAsyn()
        {
            var result = _iLichSanhTiecService.SortOrderByAsyn();
            return Ok(new BaseResponseModel<List<LichSanhTiecEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }
        [HttpGet]
        [Route(WebApiEndpoint.LichSanhTiec.SortByDescendingNgayToChuc)]
        public IActionResult SortByDescendingNTCAsyn()
        {
            var result = _iLichSanhTiecService.SortOrderByDescendingAsyn();
            return Ok(new BaseResponseModel<List<LichSanhTiecEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }
    }
}
