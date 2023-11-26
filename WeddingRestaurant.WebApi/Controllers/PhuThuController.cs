using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Contract.Service;
using WeddingRestaurant.Core.Constants;
using WeddingRestaurant.Core.Exceptions;
using WeddingRestaurant.Core.Models.PhuThu;
using WeddingRestaurant.Core.Models;

namespace WeddingRestaurant.WebApi.Controllers
{
    [ApiController]
    public class PhuThuController : ControllerBase
    {
        private readonly IPhuThuService _iPhuThuService;

        public PhuThuController(IPhuThuService iPhuThuService)
        {
            _iPhuThuService = iPhuThuService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.PhuThu.GetAllPhuThu)]
        public IActionResult GetAll()
        {
            var result = _iPhuThuService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<PhuThuEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.PhuThu.GetPhuThu)]
        public IActionResult GetPhuThuById([FromRoute] string MaPhuThu)
        {
            var data = _iPhuThuService.GetByKeyIdAsync(MaPhuThu);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsPhuThu.PHUTHU_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<PhuThuEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.PhuThu.AddPhuThu)]
        public async Task<IActionResult> CreatePhuThu(PhuThuModel model)
        {
            try
            {
                var result = await _iPhuThuService.CreateAsync(model);
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
        [Route(WebApiEndpoint.PhuThu.UpdatePhuThu)]
        public async Task<IActionResult> UpdatePhuThu([FromRoute] string MaPhuThu, PhuThuModel model)
        {
            try
            {
                await _iPhuThuService.UpdateAsync(MaPhuThu, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsPhuThu.UPDATE_PHUTHU_SUCCESS));
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
        [Route(WebApiEndpoint.PhuThu.DeletePhuThu)]
        public async Task<IActionResult> DeletePhuThu([FromRoute] string MaPhuThu)
        {
            try
            {
                await _iPhuThuService.DeleteAsync(MaPhuThu, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsPhuThu.DELETE_PHUTHU_SUCCESS));
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
        [Route(WebApiEndpoint.PhuThu.CountPhuThu)]
        public async Task<IActionResult> CountPhuThu()
        {
            try
            {
                var result = await _iPhuThuService.CountAsync();
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
