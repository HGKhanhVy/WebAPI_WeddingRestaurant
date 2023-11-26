using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Contract.Service;
using WeddingRestaurant.Core.Constants;
using WeddingRestaurant.Core.Exceptions;
using WeddingRestaurant.Core.Models.ChiTietDichVuUuDai;
using WeddingRestaurant.Core.Models;
using static WeddingRestaurant.Core.Constants.WebApiEndpoint;

namespace WeddingRestaurant.WebApi.Controllers
{
    [ApiController]
    public class ChiTietDichVuUuDaiController : ControllerBase
    {
        private readonly IChiTietDichVuUuDaiService _iChiTietDichVuUuDaiService;

        public ChiTietDichVuUuDaiController(IChiTietDichVuUuDaiService iChiTietDichVuUuDaiService)
        {
            _iChiTietDichVuUuDaiService = iChiTietDichVuUuDaiService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.ChiTietDichVuUuDai.GetAllChiTietDichVuUuDai)]
        public IActionResult GetAll()
        {
            var result = _iChiTietDichVuUuDaiService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<ChiTietDichVuUuDaiEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.ChiTietDichVuUuDai.GetChiTietDichVuUuDai)]
        public IActionResult GetChiTietDichVuUuDaiById([FromRoute] string MaTiec, [FromRoute] string MaDichVuUuDai)
        {
            var data = _iChiTietDichVuUuDaiService.GetByKeyIdAsync(MaTiec, MaDichVuUuDai);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsChiTietDichVuUuDai.CHITIETDICHVUUUDAI_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ChiTietDichVuUuDaiEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.ChiTietDichVuUuDai.AddChiTietDichVuUuDai)]
        public async Task<IActionResult> CreateChiTietDichVuUuDai(ChiTietDichVuUuDaiModel model)
        {
            try
            {
                var result = await _iChiTietDichVuUuDaiService.CreateAsync(model);
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
        [Route(WebApiEndpoint.ChiTietDichVuUuDai.UpdateChiTietDichVuUuDai)]
        public async Task<IActionResult> UpdateChiTietDichVuUuDai([FromRoute] string MaTiec, [FromRoute] string MaDichVuUuDai, ChiTietDichVuUuDaiModel model)
        {
            try
            {
                await _iChiTietDichVuUuDaiService.UpdateAsync(MaTiec, MaDichVuUuDai, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsChiTietDichVuUuDai.UPDATE_CHITIETDICHVUUUDAI_SUCCESS));
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
        [Route(WebApiEndpoint.ChiTietDichVuUuDai.DeleteChiTietDichVuUuDai)]
        public async Task<IActionResult> DeleteChiTietDichVuUuDai([FromRoute] string MaTiec, [FromRoute] string MaDichVuUuDai)
        {
            try
            {
                await _iChiTietDichVuUuDaiService.DeleteAsync(MaTiec, MaDichVuUuDai, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsChiTietDichVuUuDai.DELETE_CHITIETDICHVUUUDAI_SUCCESS));
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
        [Route(WebApiEndpoint.ChiTietDichVuUuDai.CountChiTietDichVuUuDai)]
        public async Task<IActionResult> CountChiTietDichVuUuDai()
        {
            try
            {
                var result = await _iChiTietDichVuUuDaiService.CountAsync();
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
        [Route(WebApiEndpoint.ChiTietDichVuUuDai.PrintAllChiTietDichVuUuDaiForTiec)]
        public IActionResult GetChiTietDichVuUuDaiByIdTiec([FromRoute] string MaTiec)
        {
            var data = _iChiTietDichVuUuDaiService.GetAllByKey1Async(MaTiec);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsChiTietDichVuUuDai.CHITIETDICHVUUUDAI_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ICollection<ChiTietDichVuUuDaiEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpGet]
        [Route(WebApiEndpoint.ChiTietDichVuUuDai.PrintAllChiTietDichVuUuDaiForDVUD)]
        public IActionResult GetChiTietDichVuUuDaiByIdDVUD([FromRoute] string MaDichVuUuDai)
        {
            var data = _iChiTietDichVuUuDaiService.GetAllByKey2Async(MaDichVuUuDai);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsChiTietDichVuUuDai.CHITIETDICHVUUUDAI_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ICollection<ChiTietDichVuUuDaiEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: data));
        }
    }
}
