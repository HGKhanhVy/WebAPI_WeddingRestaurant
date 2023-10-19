using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Contract.Service;
using WeddingRestaurant.Core.Constants;
using WeddingRestaurant.Core.Exceptions;
using WeddingRestaurant.Core.Models.ChiTietDichVu;
using WeddingRestaurant.Core.Models;
using WeddingRestaurant.Core.Models.ChiTietMenu;

namespace WeddingRestaurant.WebApi.Controllers
{
    [ApiController]
    public class ChiTietMenuController : ControllerBase
    {
        private readonly IChiTietMenuService _iChiTietMenuService;

        public ChiTietMenuController(IChiTietMenuService iChiTietMenuService)
        {
            _iChiTietMenuService = iChiTietMenuService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.ChiTietMenu.GetAllChiTietMenu)]
        public IActionResult GetAll()
        {
            var result = _iChiTietMenuService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<ChiTietMenuEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.ChiTietMenu.GetChiTietMenu)]
        public IActionResult GetChiTietMenuById(string keyId, string id_Tiec)
        {
            var data = _iChiTietMenuService.GetByKeyIdAsync(keyId, id_Tiec);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsChiTietMenu.CHITIETMENU_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ChiTietMenuEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.ChiTietMenu.AddChiTietMenu)]
        [Authorize]
        public async Task<IActionResult> CreateChiTietMenu(ChiTietMenuModel model)
        {
            try
            {
                var result = await _iChiTietMenuService.CreateAsync(model);
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
        [Route(WebApiEndpoint.ChiTietMenu.UpdateChiTietMenu)]
        [Authorize]
        public async Task<IActionResult> UpdateChiTietMenu(string keyId, string id_Tiec, ChiTietMenuModel model)
        {
            try
            {
                await _iChiTietMenuService.UpdateAsync(keyId, id_Tiec, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsChiTietMenu.UPDATE_CHITIETMENU_SUCCESS));
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
        [Route(WebApiEndpoint.ChiTietMenu.DeleteChiTietMenu)]
        [Authorize]
        public async Task<IActionResult> DeleteChiTietMenu(string keyId, string id_Tiec)
        {
            try
            {
                await _iChiTietMenuService.DeleteAsync(keyId, id_Tiec, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsMenu.DELETE_MENU_SUCCESS));
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
        [Route(WebApiEndpoint.ChiTietMenu.CountChiTietMenu)]
        public async Task<IActionResult> CountChiTietMenu()
        {
            try
            {
                var result = await _iChiTietMenuService.CountAsync();
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
