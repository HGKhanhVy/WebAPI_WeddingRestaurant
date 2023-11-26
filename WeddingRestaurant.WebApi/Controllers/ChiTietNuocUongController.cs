using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Contract.Service;
using WeddingRestaurant.Core.Constants;
using WeddingRestaurant.Core.Exceptions;
using WeddingRestaurant.Core.Models.ChiTietNuocUong;
using WeddingRestaurant.Core.Models;
using WeddingRestaurant.Service;

namespace WeddingRestaurant.WebApi.Controllers
{
    [ApiController]
    public class ChiTietNuocUongController : ControllerBase
    {
        private readonly IChiTietNuocUongService _iChiTietNuocUongService;

        public ChiTietNuocUongController(IChiTietNuocUongService iChiTietNuocUongService)
        {
            _iChiTietNuocUongService = iChiTietNuocUongService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.ChiTietNuocUong.GetAllChiTietNuocUong)]
        public IActionResult GetAll()
        {
            var result = _iChiTietNuocUongService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<ChiTietNuocUongEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.ChiTietNuocUong.GetChiTietNuocUong)]
        public IActionResult GetChiTietNuocUongById([FromRoute] string MaNuoc, [FromRoute] string MaTiec)
        {
            var data = _iChiTietNuocUongService.GetByKeyIdAsync(MaNuoc, MaTiec);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsChiTietNuocUong.CHITIETNUOCUONG_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ChiTietNuocUongEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.ChiTietNuocUong.AddChiTietNuocUong)]
        public async Task<IActionResult> CreateChiTietNuocUong(ChiTietNuocUongModel model)
        {
            try
            {
                var result = await _iChiTietNuocUongService.CreateAsync(model);
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
        [Route(WebApiEndpoint.ChiTietNuocUong.UpdateChiTietNuocUong)]
        public async Task<IActionResult> UpdateChiTietNuocUong([FromRoute] string MaNuoc, [FromRoute] string MaTiec, ChiTietNuocUongModel model)
        {
            try
            {
                await _iChiTietNuocUongService.UpdateAsync(MaNuoc, MaTiec, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsChiTietNuocUong.UPDATE_CHITIETNUOCUONG_SUCCESS));
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
        [Route(WebApiEndpoint.ChiTietNuocUong.DeleteChiTietNuocUong)]
        public async Task<IActionResult> DeleteChiTietNuocUong([FromRoute] string MaNuoc, [FromRoute] string MaTiec)
        {
            try
            {
                await _iChiTietNuocUongService.DeleteAsync(MaNuoc, MaTiec, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsChiTietNuocUong.DELETE_CHITIETNUOCUONG_SUCCESS));
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
        [Route(WebApiEndpoint.ChiTietNuocUong.CountChiTietNuocUong)]
        public async Task<IActionResult> CountChiTietNuocUong()
        {
            try
            {
                var result = await _iChiTietNuocUongService.CountAsync();
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
        [Route(WebApiEndpoint.ChiTietNuocUong.PrintAllChiTietNuocForTiec)]
        public IActionResult GetChiTietMenuByIdTiec([FromRoute] string MaTiec)
        {
            var data = _iChiTietNuocUongService.GetAllByKey1Async(MaTiec);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsChiTietNuocUong.CHITIETNUOCUONG_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ICollection<ChiTietNuocUongEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpGet]
        [Route(WebApiEndpoint.ChiTietNuocUong.PrintAllChiTietNuocForNuoc)]
        public IActionResult GetChiTietMenuByIdNuoc([FromRoute] string MaNuoc)
        {
            var data = _iChiTietNuocUongService.GetAllByKey2Async(MaNuoc);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsChiTietNuocUong.CHITIETNUOCUONG_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ICollection<ChiTietNuocUongEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: data));
        }
    }
}
