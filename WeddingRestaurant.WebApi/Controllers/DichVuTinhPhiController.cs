using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Contract.Service;
using WeddingRestaurant.Core.Constants;
using WeddingRestaurant.Core.Exceptions;
using WeddingRestaurant.Core.Models.DichVuTinhPhi;
using WeddingRestaurant.Core.Models;

namespace WeddingRestaurant.WebApi.Controllers
{
    [ApiController]
    public class DichVuTinhPhiController : ControllerBase
    {
        private readonly IDichVuTinhPhiService _iDichVuTinhPhiService;

        public DichVuTinhPhiController(IDichVuTinhPhiService iDichVuTinhPhiService)
        {
            _iDichVuTinhPhiService = iDichVuTinhPhiService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.DichVuTinhPhi.GetAllDichVuTinhPhi)]
        public IActionResult GetAll()
        {
            var result = _iDichVuTinhPhiService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<DichVuTinhPhiEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.DichVuTinhPhi.GetDichVuTinhPhi)]
        public IActionResult GetDichVuTinhPhiById([FromRoute] string MaDichVuTinhPhi)
        {
            var data = _iDichVuTinhPhiService.GetByKeyIdAsync(MaDichVuTinhPhi);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsDichVuTinhPhi.DICHVUTINHPHI_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<DichVuTinhPhiEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.DichVuTinhPhi.AddDichVuTinhPhi)]
        [Authorize]
        public async Task<IActionResult> CreateDichVuTinhPhi(DichVuTinhPhiModel model)
        {
            try
            {
                var result = await _iDichVuTinhPhiService.CreateAsync(model);
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
        [Route(WebApiEndpoint.DichVuTinhPhi.UpdateDichVuTinhPhi)]
        [Authorize]
        public async Task<IActionResult> UpdateDichVuTinhPhi([FromRoute] string MaDichVuTinhPhi, DichVuTinhPhiModel model)
        {
            try
            {
                await _iDichVuTinhPhiService.UpdateAsync(MaDichVuTinhPhi, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsDichVuTinhPhi.UPDATE_DICHVUTINHPHI_SUCCESS));
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
        [Route(WebApiEndpoint.DichVuTinhPhi.DeleteDichVuTinhPhi)]
        [Authorize]
        public async Task<IActionResult> DeleteDichVuTinhPhi([FromRoute] string MaDichVuTinhPhi)
        {
            try
            {
                await _iDichVuTinhPhiService.DeleteAsync(MaDichVuTinhPhi, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsDichVuTinhPhi.DELETE_DICHVUTINHPHI_SUCCESS));
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
        [Route(WebApiEndpoint.DichVuTinhPhi.CountDichVuTinhPhi)]
        public async Task<IActionResult> CountDichVuTinhPhi()
        {
            try
            {
                var result = await _iDichVuTinhPhiService.CountAsync();
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
