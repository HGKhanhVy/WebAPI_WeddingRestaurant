using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Contract.Service;
using WeddingRestaurant.Core.Constants;
using WeddingRestaurant.Core.Exceptions;
using WeddingRestaurant.Core.Models.ChiTietDichVuTinhPhi;
using WeddingRestaurant.Core.Models;
using static WeddingRestaurant.Core.Constants.WebApiEndpoint;

namespace WeddingRestaurant.WebApi.Controllers
{
    [ApiController]
    public class ChiTietDichVuTinhPhiController : ControllerBase
    {
        private readonly IChiTietDichVuTinhPhiService _iChiTietDichVuTinhPhiService;

        public ChiTietDichVuTinhPhiController(IChiTietDichVuTinhPhiService iChiTietDichVuTinhPhiService)
        {
            _iChiTietDichVuTinhPhiService = iChiTietDichVuTinhPhiService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.ChiTietDichVuTinhPhi.GetAllChiTietDichVuTinhPhi)]
        public IActionResult GetAll()
        {
            var result = _iChiTietDichVuTinhPhiService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<ChiTietDichVuTinhPhiEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.ChiTietDichVuTinhPhi.GetChiTietDichVuTinhPhi)]
        public IActionResult GetChiTietDichVuTinhPhiById([FromRoute] string MaTiec, [FromRoute] string MaDichVuTinhPhi)
        {
            var data = _iChiTietDichVuTinhPhiService.GetByKeyIdAsync(MaTiec, MaDichVuTinhPhi);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsChiTietDichVuTinhPhi.CHITIETDICHVUTINHPHI_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ChiTietDichVuTinhPhiEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.ChiTietDichVuTinhPhi.AddChiTietDichVuTinhPhi)]
        public async Task<IActionResult> CreateChiTietDichVuTinhPhi(ChiTietDichVuTinhPhiModel model)
        {
            try
            {
                var result = await _iChiTietDichVuTinhPhiService.CreateAsync(model);
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
        [Route(WebApiEndpoint.ChiTietDichVuTinhPhi.UpdateChiTietDichVuTinhPhi)]
        public async Task<IActionResult> UpdateChiTietDichVuTinhPhi([FromRoute] string MaTiec, [FromRoute] string MaDichVuTinhPhi, ChiTietDichVuTinhPhiModel model)
        {
            try
            {
                await _iChiTietDichVuTinhPhiService.UpdateAsync(MaTiec, MaDichVuTinhPhi, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsChiTietDichVuTinhPhi.UPDATE_CHITIETDICHVUTINHPHI_SUCCESS));
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
        [Route(WebApiEndpoint.ChiTietDichVuTinhPhi.DeleteChiTietDichVuTinhPhi)]
        public async Task<IActionResult> DeleteChiTietDichVuTinhPhi([FromRoute] string MaTiec, [FromRoute] string MaDichVuTinhPhi)
        {
            try
            {
                await _iChiTietDichVuTinhPhiService.DeleteAsync(MaTiec, MaDichVuTinhPhi, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsChiTietDichVuTinhPhi.DELETE_CHITIETDICHVUTINHPHI_SUCCESS));
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
        [Route(WebApiEndpoint.ChiTietDichVuTinhPhi.CountChiTietDichVuTinhPhi)]
        public async Task<IActionResult> CountChiTietDichVuTinhPhi()
        {
            try
            {
                var result = await _iChiTietDichVuTinhPhiService.CountAsync();
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
        [Route(WebApiEndpoint.ChiTietDichVuTinhPhi.PrintAllChiTietDichVuTinhPhiForTiec)]
        public IActionResult GetChiTietDichVuTinhPhiByIdTiec([FromRoute] string MaTiec)
        {
            var data = _iChiTietDichVuTinhPhiService.GetAllByKey1Async(MaTiec);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsChiTietDichVuTinhPhi.CHITIETDICHVUTINHPHI_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ICollection<ChiTietDichVuTinhPhiEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpGet]
        [Route(WebApiEndpoint.ChiTietDichVuTinhPhi.PrintAllChiTietDichVuTinhPhiForDVTP)]
        public IActionResult GetChiTietDichVuTinhPhiByIdDVTP([FromRoute] string MaDichVuTinhPhi)
        {
            var data = _iChiTietDichVuTinhPhiService.GetAllByKey2Async(MaDichVuTinhPhi);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsChiTietDichVuTinhPhi.CHITIETDICHVUTINHPHI_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ICollection<ChiTietDichVuTinhPhiEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: data));
        }
    }
}
