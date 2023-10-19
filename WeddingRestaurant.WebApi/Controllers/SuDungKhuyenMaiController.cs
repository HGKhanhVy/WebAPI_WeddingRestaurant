using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Contract.Service;
using WeddingRestaurant.Core.Constants;
using WeddingRestaurant.Core.Exceptions;
using WeddingRestaurant.Core.Models.SuDungKhuyenMai;
using WeddingRestaurant.Core.Models;

namespace WeddingRestaurant.WebApi.Controllers
{
    [ApiController]
    public class SuDungKhuyenMaiController : ControllerBase
    {
        private readonly ISuDungKhuyenMaiService _iSuDungKhuyenMaiService;

        public SuDungKhuyenMaiController(ISuDungKhuyenMaiService iSuDungKhuyenMaiService)
        {
            _iSuDungKhuyenMaiService = iSuDungKhuyenMaiService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.SuDungKhuyenMai.GetAllSuDungKhuyenMai)]
        public IActionResult GetAll()
        {
            var result = _iSuDungKhuyenMaiService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<SuDungKhuyenMaiEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.SuDungKhuyenMai.GetSuDungKhuyenMai)]
        public IActionResult GetSuDungKhuyenMaiById(string keyId, string id_Tiec)
        {
            var data = _iSuDungKhuyenMaiService.GetByKeyIdAsync(keyId, id_Tiec);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsSuDungKhuyenMai.SUDUNGKHUYENMAI_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<SuDungKhuyenMaiEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.SuDungKhuyenMai.AddSuDungKhuyenMai)]
        [Authorize]
        public async Task<IActionResult> CreateSuDungKhuyenMai(SuDungKhuyenMaiModel model)
        {
            try
            {
                var result = await _iSuDungKhuyenMaiService.CreateAsync(model);
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
        [Route(WebApiEndpoint.SuDungKhuyenMai.UpdateSuDungKhuyenMai)]
        [Authorize]
        public async Task<IActionResult> UpdateSuDungKhuyenMai(string keyId, string id_Tiec, SuDungKhuyenMaiModel model)
        {
            try
            {
                await _iSuDungKhuyenMaiService.UpdateAsync(keyId, id_Tiec, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsSuDungKhuyenMai.UPDATE_SUDUNGKHUYENMAI_SUCCESS));
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
        [Route(WebApiEndpoint.SuDungKhuyenMai.DeleteSuDungKhuyenMai)]
        [Authorize]
        public async Task<IActionResult> DeleteSuDungKhuyenMai(string keyId, string id_Tiec)
        {
            try
            {
                await _iSuDungKhuyenMaiService.DeleteAsync(keyId, id_Tiec, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsSuDungKhuyenMai.DELETE_SUDUNGKHUYENMAI_SUCCESS));
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
        [Route(WebApiEndpoint.SuDungKhuyenMai.CountSuDungKhuyenMai)]
        public async Task<IActionResult> CountSuDungKhuyenMai()
        {
            try
            {
                var result = await _iSuDungKhuyenMaiService.CountAsync();
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
