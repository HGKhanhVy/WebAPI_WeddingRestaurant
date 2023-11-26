using Microsoft.AspNetCore.Mvc;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Contract.Service;
using WeddingRestaurant.Core.Constants;
using WeddingRestaurant.Core.Exceptions;
using WeddingRestaurant.Core.Models.ChiTietPhuThuNuoc;
using WeddingRestaurant.Core.Models;

namespace WeddingRestaurant.WebApi.Controllers
{
    [ApiController]
    public class ChiTietPhuThuNuocController : ControllerBase
    {
        private readonly IChiTietPhuThuNuocService _iChiTietPhuThuNuocService;

        public ChiTietPhuThuNuocController(IChiTietPhuThuNuocService iChiTietPhuThuNuocService)
        {
            _iChiTietPhuThuNuocService = iChiTietPhuThuNuocService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.ChiTietPhuThuNuoc.GetAllChiTietPhuThuNuoc)]
        public IActionResult GetAll()
        {
            var result = _iChiTietPhuThuNuocService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<ChiTietPhuThuNuocEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.ChiTietPhuThuNuoc.GetChiTietPhuThuNuoc)]
        public IActionResult GetChiTietPhuThuNuocById([FromRoute] string MaPhuThu, [FromRoute] string MaNuoc)
        {
            var data = _iChiTietPhuThuNuocService.GetByKeyIdAsync(MaPhuThu, MaNuoc);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsChiTietPhuThuNuoc.CHITIETPHUTHUNUOC_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ChiTietPhuThuNuocEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.ChiTietPhuThuNuoc.AddChiTietPhuThuNuoc)]
        public async Task<IActionResult> CreateChiTietPhuThuNuoc(ChiTietPhuThuNuocModel model)
        {
            try
            {
                var result = await _iChiTietPhuThuNuocService.CreateAsync(model);
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
        [Route(WebApiEndpoint.ChiTietPhuThuNuoc.UpdateChiTietPhuThuNuoc)]
        public async Task<IActionResult> UpdateChiTietPhuThuNuoc([FromRoute] string MaPhuThu, [FromRoute] string MaNuoc, ChiTietPhuThuNuocModel model)
        {
            try
            {
                await _iChiTietPhuThuNuocService.UpdateAsync(MaPhuThu, MaNuoc, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsChiTietPhuThuNuoc.UPDATE_CHITIETPHUTHUNUOC_SUCCESS));
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
        [Route(WebApiEndpoint.ChiTietPhuThuNuoc.DeleteChiTietPhuThuNuoc)]
        public async Task<IActionResult> DeleteChiTietPhuThuNuoc([FromRoute] string MaPhuThu, [FromRoute] string MaNuoc)
        {
            try
            {
                await _iChiTietPhuThuNuocService.DeleteAsync(MaPhuThu, MaNuoc, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsChiTietPhuThuNuoc.DELETE_CHITIETPHUTHUNUOC_SUCCESS));
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
        [Route(WebApiEndpoint.ChiTietPhuThuNuoc.CountChiTietPhuThuNuoc)]
        public async Task<IActionResult> CountChiTietPhuThuNuoc()
        {
            try
            {
                var result = await _iChiTietPhuThuNuocService.CountAsync();
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
        [Route(WebApiEndpoint.ChiTietPhuThuNuoc.PrintAllChiTietPhuThuNuocForPhuThu)]
        public IActionResult GetChiTietMenuByIdPhuThu([FromRoute] string MaPhuThu)
        {
            var data = _iChiTietPhuThuNuocService.GetAllByKey1Async(MaPhuThu);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsChiTietPhuThuNuoc.CHITIETPHUTHUNUOC_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ICollection<ChiTietPhuThuNuocEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpGet]
        [Route(WebApiEndpoint.ChiTietPhuThuNuoc.PrintAllChiTietPhuThuNuocForNuoc)]
        public IActionResult GetChiTietMenuByIdNuoc([FromRoute] string MaNuoc)
        {
            var data = _iChiTietPhuThuNuocService.GetAllByKey2Async(MaNuoc);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsChiTietPhuThuNuoc.CHITIETPHUTHUNUOC_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ICollection<ChiTietPhuThuNuocEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: data));
        }
    }
}
