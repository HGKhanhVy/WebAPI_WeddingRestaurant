﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Contract.Service;
using WeddingRestaurant.Core.Constants;
using WeddingRestaurant.Core.Exceptions;
using WeddingRestaurant.Core.Models.MonAnTrongMenu;
using WeddingRestaurant.Core.Models;
using WeddingRestaurant.Service;

namespace WeddingRestaurant.WebApi.Controllers
{
    [ApiController]
    public class MonAnTrongMenuController : ControllerBase
    {
        private readonly IMonAnTrongMenuService _iMonAnTrongMenuService;

        public MonAnTrongMenuController(IMonAnTrongMenuService iMonAnTrongMenuService)
        {
            _iMonAnTrongMenuService = iMonAnTrongMenuService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.MonAnTrongMenu.GetAllMonAnTrongMenu)]
        public IActionResult GetAll()
        {
            var result = _iMonAnTrongMenuService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<MonAnTrongMenuEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.MonAnTrongMenu.GetMonAnTrongMenu)]
        public IActionResult GetMonAnTrongMenuById([FromRoute] string MaMenu, [FromRoute] string MaMonAn)
        {
            var data = _iMonAnTrongMenuService.GetByKeyIdAsync(MaMenu, MaMonAn);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsMonAnTrongMenu.MONANTRONGMENU_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<MonAnTrongMenuEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.MonAnTrongMenu.AddMonAnTrongMenu)]
        public async Task<IActionResult> CreateMonAnTrongMenu(MonAnTrongMenuModel model)
        {
            try
            {
                var result = await _iMonAnTrongMenuService.CreateAsync(model);
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
        [Route(WebApiEndpoint.MonAnTrongMenu.UpdateMonAnTrongMenu)]
        public async Task<IActionResult> UpdateMonAnTrongMenu([FromRoute] string MaMenu, [FromRoute] string MaMonAn, MonAnTrongMenuModel model)
        {
            try
            {
                await _iMonAnTrongMenuService.UpdateAsync(MaMenu, MaMonAn, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsMonAnTrongMenu.UPDATE_MONANTRONGMENU_SUCCESS));
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
        [Route(WebApiEndpoint.MonAnTrongMenu.DeleteMonAnTrongMenu)]
        public async Task<IActionResult> DeleteMonAnTrongMenu([FromRoute] string MaMenu, [FromRoute] string MaMonAn)
        {
            try
            {
                await _iMonAnTrongMenuService.DeleteAsync(MaMenu, MaMonAn, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsMonAnTrongMenu.DELETE_MONANTRONGMENU_SUCCESS));
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
        [Route(WebApiEndpoint.MonAnTrongMenu.CountMonAnTrongMenu)]
        public async Task<IActionResult> CountMonAnTrongMenu()
        {
            try
            {
                var result = await _iMonAnTrongMenuService.CountAsync();
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
        [Route(WebApiEndpoint.MonAnTrongMenu.PrintAllMonAnTrongMenuForMenu)]
        public IActionResult GetChiTietMenuByIdMenu([FromRoute] string MaMenu)
        {
            var data = _iMonAnTrongMenuService.GetAllByKey1Async(MaMenu);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsMonAnTrongMenu.MONANTRONGMENU_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ICollection<MonAnTrongMenuEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpGet]
        [Route(WebApiEndpoint.MonAnTrongMenu.PrintAllMonAnTrongMenuForMonAn)]
        public IActionResult GetChiTietMenuByIdMonAn([FromRoute] string MaMonAn)
        {
            var data = _iMonAnTrongMenuService.GetAllByKey2Async(MaMonAn);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsMonAnTrongMenu.MONANTRONGMENU_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ICollection<MonAnTrongMenuEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: data));
        }
    }
}
