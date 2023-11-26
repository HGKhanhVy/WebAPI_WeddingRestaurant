using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Contract.Service;
using WeddingRestaurant.Core.Constants;
using WeddingRestaurant.Core.Exceptions;
using WeddingRestaurant.Core.Models.ChiTietPhuThuMonAn;
using WeddingRestaurant.Core.Models;

namespace WeddingRestaurant.WebApi.Controllers
{
    [ApiController]
    public class ChiTietPhuThuMonAnController : ControllerBase
    {
        private readonly IChiTietPhuThuMonAnService _iChiTietPhuThuMonAnService;

        public ChiTietPhuThuMonAnController(IChiTietPhuThuMonAnService iChiTietPhuThuMonAnService)
        {
            _iChiTietPhuThuMonAnService = iChiTietPhuThuMonAnService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.ChiTietPhuThuMonAn.GetAllChiTietPhuThuMonAn)]
        public IActionResult GetAll()
        {
            var result = _iChiTietPhuThuMonAnService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<ChiTietPhuThuMonAnEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.ChiTietPhuThuMonAn.GetChiTietPhuThuMonAn)]
        public IActionResult GetChiTietPhuThuMonAnById([FromRoute] string MaPhuThu, [FromRoute] string MaMonAn)
        {
            var data = _iChiTietPhuThuMonAnService.GetByKeyIdAsync(MaPhuThu, MaMonAn);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsChiTietPhuThuMonAn.CHITIETPHUTHUMA_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ChiTietPhuThuMonAnEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.ChiTietPhuThuMonAn.AddChiTietPhuThuMonAn)]
        public async Task<IActionResult> CreateChiTietPhuThuMonAn(ChiTietPhuThuMonAnModel model)
        {
            try
            {
                var result = await _iChiTietPhuThuMonAnService.CreateAsync(model);
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
        [Route(WebApiEndpoint.ChiTietPhuThuMonAn.UpdateChiTietPhuThuMonAn)]
        public async Task<IActionResult> UpdateChiTietPhuThuMonAn([FromRoute] string MaPhuThu, [FromRoute] string MaMonAn, ChiTietPhuThuMonAnModel model)
        {
            try
            {
                await _iChiTietPhuThuMonAnService.UpdateAsync(MaPhuThu, MaMonAn, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsChiTietPhuThuMonAn.UPDATE_CHITIETPHUTHUMA_SUCCESS));
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
        [Route(WebApiEndpoint.ChiTietPhuThuMonAn.DeleteChiTietPhuThuMonAn)]
        public async Task<IActionResult> DeleteChiTietPhuThuMonAn([FromRoute] string MaPhuThu, [FromRoute] string MaMonAn)
        {
            try
            {
                await _iChiTietPhuThuMonAnService.DeleteAsync(MaPhuThu, MaMonAn, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsChiTietPhuThuMonAn.DELETE_CHITIETPHUTHUMA_SUCCESS));
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
        [Route(WebApiEndpoint.ChiTietPhuThuMonAn.CountChiTietPhuThuMonAn)]
        public async Task<IActionResult> CountChiTietPhuThuMonAn()
        {
            try
            {
                var result = await _iChiTietPhuThuMonAnService.CountAsync();
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
        [Route(WebApiEndpoint.ChiTietPhuThuMonAn.PrintAllChiTietPhuThuMonAnForPhuThu)]
        public IActionResult GetChiTietMenuByIdPhuThu([FromRoute] string MaPhuThu)
        {
            var data = _iChiTietPhuThuMonAnService.GetAllByKey1Async(MaPhuThu);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsChiTietPhuThuMonAn.CHITIETPHUTHUMA_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ICollection<ChiTietPhuThuMonAnEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpGet]
        [Route(WebApiEndpoint.ChiTietPhuThuMonAn.PrintAllChiTietPhuThuMonAnForMonAn)]
        public IActionResult GetChiTietMenuByIdMonAn([FromRoute] string MaMonAn)
        {
            var data = _iChiTietPhuThuMonAnService.GetAllByKey2Async(MaMonAn);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsChiTietPhuThuMonAn.CHITIETPHUTHUMA_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ICollection<ChiTietPhuThuMonAnEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: data));
        }
    }
}
