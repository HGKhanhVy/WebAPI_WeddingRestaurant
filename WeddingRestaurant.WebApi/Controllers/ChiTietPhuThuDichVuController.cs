using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Contract.Service;
using WeddingRestaurant.Core.Constants;
using WeddingRestaurant.Core.Exceptions;
using WeddingRestaurant.Core.Models.ChiTietPhuThuDichVu;
using WeddingRestaurant.Core.Models;

namespace WeddingRestaurant.WebApi.Controllers
{
    [ApiController]
    public class ChiTietPhuThuDichVuController : ControllerBase
    {
        private readonly IChiTietPhuThuDichVuService _iChiTietPhuThuDichVuService;

        public ChiTietPhuThuDichVuController(IChiTietPhuThuDichVuService iChiTietPhuThuDichVuService)
        {
            _iChiTietPhuThuDichVuService = iChiTietPhuThuDichVuService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.ChiTietPhuThuDichVu.GetAllChiTietPhuThuDichVu)]
        public IActionResult GetAll()
        {
            var result = _iChiTietPhuThuDichVuService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<ChiTietPhuThuDichVuEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.ChiTietPhuThuDichVu.GetChiTietPhuThuDichVu)]
        public IActionResult GetChiTietPhuThuDichVuById([FromRoute] string MaPhuThu, [FromRoute] string MaDichVuTinhPhi)
        {
            var data = _iChiTietPhuThuDichVuService.GetByKeyIdAsync(MaPhuThu, MaDichVuTinhPhi);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsChiTietPhuThuDichVu.CHITIETPHUTHUDV_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ChiTietPhuThuDichVuEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.ChiTietPhuThuDichVu.AddChiTietPhuThuDichVu)]
        public async Task<IActionResult> CreateChiTietPhuThuDichVu(ChiTietPhuThuDichVuModel model)
        {
            try
            {
                var result = await _iChiTietPhuThuDichVuService.CreateAsync(model);
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
        [Route(WebApiEndpoint.ChiTietPhuThuDichVu.UpdateChiTietPhuThuDichVu)]
        public async Task<IActionResult> UpdateChiTietPhuThuDichVu([FromRoute] string MaPhuThu, [FromRoute] string MaDichVuTinhPhi, ChiTietPhuThuDichVuModel model)
        {
            try
            {
                await _iChiTietPhuThuDichVuService.UpdateAsync(MaPhuThu, MaDichVuTinhPhi, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsChiTietPhuThuDichVu.UPDATE_CHITIETPHUTHUDV_SUCCESS));
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
        [Route(WebApiEndpoint.ChiTietPhuThuDichVu.DeleteChiTietPhuThuDichVu)]
        public async Task<IActionResult> DeleteChiTietPhuThuDichVu([FromRoute] string MaPhuThu, [FromRoute] string MaDichVuTinhPhi)
        {
            try
            {
                await _iChiTietPhuThuDichVuService.DeleteAsync(MaPhuThu, MaDichVuTinhPhi, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsChiTietPhuThuDichVu.DELETE_CHITIETPHUTHUDV_SUCCESS));
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
        [Route(WebApiEndpoint.ChiTietPhuThuDichVu.CountChiTietPhuThuDichVu)]
        public async Task<IActionResult> CountChiTietPhuThuDichVu()
        {
            try
            {
                var result = await _iChiTietPhuThuDichVuService.CountAsync();
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
        [Route(WebApiEndpoint.ChiTietPhuThuDichVu.PrintAllChiTietPhuThuDichVuForPhuThu)]
        public IActionResult GetChiTietMenuByIdPhuThu([FromRoute] string MaPhuThu)
        {
            var data = _iChiTietPhuThuDichVuService.GetAllByKey1Async(MaPhuThu);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsChiTietPhuThuDichVu.CHITIETPHUTHUDV_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ICollection<ChiTietPhuThuDichVuEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpGet]
        [Route(WebApiEndpoint.ChiTietPhuThuDichVu.PrintAllChiTietPhuThuDichVuForDVTP)]
        public IActionResult GetChiTietMenuByIdDVTP([FromRoute] string MaDichVuTinhPhi)
        {
            var data = _iChiTietPhuThuDichVuService.GetAllByKey2Async(MaDichVuTinhPhi);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsChiTietPhuThuDichVu.CHITIETPHUTHUDV_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ICollection<ChiTietPhuThuDichVuEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: data));
        }
    }
}
