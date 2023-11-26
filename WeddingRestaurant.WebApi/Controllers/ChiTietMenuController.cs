using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Contract.Service;
using WeddingRestaurant.Core.Constants;
using WeddingRestaurant.Core.Exceptions;
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
        public IActionResult GetChiTietMenuById([FromRoute] string MaMenu, [FromRoute] string MaTiec)
        {
            var data = _iChiTietMenuService.GetByKeyIdAsync(MaMenu, MaTiec);
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
        public async Task<IActionResult> UpdateChiTietMenu([FromRoute] string MaMenu, [FromRoute] string MaTiec, ChiTietMenuModel model)
        {
            try
            {
                await _iChiTietMenuService.UpdateAsync(MaMenu, MaTiec, model);
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
        public async Task<IActionResult> DeleteChiTietMenu([FromRoute] string MaMenu, [FromRoute] string MaTiec)
        {
            try
            {
                await _iChiTietMenuService.DeleteAsync(MaMenu, MaTiec, false);
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

        [HttpGet]
        [Route(WebApiEndpoint.ChiTietMenu.PrintAllChiTietMenuForTiec)]
        public IActionResult GetChiTietMenuByIdTiec([FromRoute] string MaTiec)
        {
            var data = _iChiTietMenuService.GetAllByKey1Async(MaTiec);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsChiTietMenu.CHITIETMENU_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ICollection<ChiTietMenuEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpGet]
        [Route(WebApiEndpoint.ChiTietMenu.PrintAllChiTietMenuForMenu)]
        public IActionResult GetChiTietMenuByIdMenu([FromRoute] string MaMenu)
        {
            var data = _iChiTietMenuService.GetAllByKey2Async(MaMenu);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsChiTietMenu.CHITIETMENU_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ICollection<ChiTietMenuEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: data));
        }
    }
}
