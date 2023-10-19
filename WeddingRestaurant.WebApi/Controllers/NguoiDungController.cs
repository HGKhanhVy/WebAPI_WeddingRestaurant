using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Contract.Service;
using WeddingRestaurant.Core.Constants;
using WeddingRestaurant.Core.Exceptions;
using WeddingRestaurant.Core.Models.NguoiDung;
using WeddingRestaurant.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeddingRestaurant.Repository.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WeddingRestaurant.Core.Models.Login;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using WeddingRestaurant.Service;
using WeddingRestaurant.Core.Models.Token;
using System.Security.Cryptography;
using static WeddingRestaurant.Core.Constants.WebApiEndpoint;
using AngleSharp.Io;
using Microsoft.EntityFrameworkCore;
using WeddingRestaurant.Contract.Repository.Infrastructure;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WeddingRestaurant.WebApi.Controllers
{
    [ApiController]
    public class NguoiDungController : ControllerBase
    {
        private readonly INguoiDungService _iNguoiDungService;
        private readonly ITokenService _iTokenService;
        private readonly IRefreshTokenService _iRefreshTokenService;
        private readonly AppSettings _appSettings;

        public NguoiDungController(INguoiDungService iNguoiDungService, IOptionsMonitor<AppSettings> optionsMonitor)
        {
            _iNguoiDungService = iNguoiDungService;
            _appSettings = optionsMonitor.CurrentValue;
        }

        [HttpGet]
        [Route(WebApiEndpoint.NguoiDung.GetAllNguoiDung)]
        [Authorize]
        public IActionResult GetAll()
        {
            var result = _iNguoiDungService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<NguoiDungEntity>?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.NguoiDung.GetNguoiDung)]
        public IActionResult GetNguoiDungById(string keyId)
        {
            var data = _iNguoiDungService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(statusCode: StatusCodes.Status400BadRequest, code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsNguoiDung.NGUOIDUNG_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<NguoiDungEntity?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.NguoiDung.AddNguoiDung)]
        public async Task<IActionResult> CreateNguoiDung(NguoiDungModel NguoiDung)
        {
            try
            {
                var result = await _iNguoiDungService.CreateAsync(NguoiDung);
                return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status201Created, code: ResponseCodeConstants.SUCCESS, data: result));
            }
            catch (Exception e)
            {
                dynamic result;
                if (e is CoreException error)
                {
                    result = new BaseResponseModel<string>(statusCode: error.StatusCode, code: error.Code, message: error.Message);
                    return BadRequest(result);
                }
                result = new BaseResponseModel<string>(statusCode: StatusCodes.Status500InternalServerError, code: ResponseCodeConstants.FAILED, message: e.Message);
                return BadRequest(result);
            }
        }

        [HttpPut]
        [Route(WebApiEndpoint.NguoiDung.UpdateNguoiDung)]
        [Authorize]
        public async Task<IActionResult> UpdateNguoiDung(string keyId, NguoiDungModel request)
        {
            try
            {
                await _iNguoiDungService.UpdateAsync(keyId, request);
                return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status202Accepted, code: ResponseCodeConstants.SUCCESS, data: ReponseMessageConstantsNguoiDung.UPDATE_NGUOIDUNG_SUCCESS));
            }
            catch (Exception e)
            {
                dynamic result;
                if (e is CoreException error)
                {
                    result = new BaseResponseModel<string>(statusCode: error.StatusCode, code: error.Code, message: error.Message);
                    return BadRequest(result);
                }
                result = new BaseResponseModel<string>(statusCode: StatusCodes.Status500InternalServerError, code: ResponseCodeConstants.FAILED, message: e.Message);
                return BadRequest(result);
            }
        }

        [HttpDelete]
        [Route(WebApiEndpoint.NguoiDung.DeleteNguoiDung)]
        [Authorize]
        public async Task<IActionResult> DeleteNguoiDung(string keyId)
        {
            try
            {
                await _iNguoiDungService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status202Accepted, code: ResponseCodeConstants.SUCCESS, data: ReponseMessageConstantsNguoiDung.DELETE_NGUOIDUNG_SUCCESS));
            }
            catch (Exception e)
            {
                dynamic result;
                if (e is CoreException error)
                {
                    result = new BaseResponseModel<string>(statusCode: error.StatusCode, code: error.Code, message: error.Message);
                    return BadRequest(result);
                }
                result = new BaseResponseModel<string>(statusCode: StatusCodes.Status500InternalServerError, code: ResponseCodeConstants.FAILED, message: e.Message);
                return BadRequest(result);
            }
        }

        [HttpPost]
        [Route(WebApiEndpoint.NguoiDung.Login)]
        public IActionResult Validate(LoginModel model)
        {
            var user = _iNguoiDungService.GetByLoginAsync(model);
            if(user == null)
            {
                var result = new BaseResponseModel<string>(statusCode: StatusCodes.Status400BadRequest, code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsNguoiDung.NGUOIDUNG_NOT_FOUND);
                return BadRequest(result);
            }
            // Cấp token
            var data = GenerateToken(user);
            return Ok(new BaseResponseModel<TokenModel>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: data));
        }

        private TokenModel GenerateToken(NguoiDungEntity nguoiDung)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_appSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, nguoiDung.hoTen),
                    new Claim(ClaimTypes.MobilePhone, nguoiDung.sdt),
                    new Claim(JwtRegisteredClaimNames.Email, nguoiDung.email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("UserName", nguoiDung.userName),

                    // roles
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var accessToken = jwtTokenHandler.WriteToken(token);
            var refreshToken = GenerateRefreshToken();

            /*
            // Save db
            var user = _iTokenService.SaveTokenToDB(accessToken, refreshToken, nguoiDung.userName, token.Id);
            if (user != 1)
            {
                dynamic result = new BaseResponseModel<string>(statusCode: StatusCodes.Status400BadRequest, code: ResponseCodeConstants.FAILED, message: "Error at save token to db");
                return BadRequest(result);
            }*/

            return new TokenModel { AccessToken = accessToken, RefreshToken = refreshToken };
        }

        private string GenerateRefreshToken()
        {
            var random = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(random);
                return Convert.ToBase64String(random);
            }
        }
        /*
        [HttpPost]
        [Route(WebApiEndpoint.Token.RenewToken)]
        public IActionResult RenewToken(TokenModel model)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_appSettings.SecretKey);
            var tokenValidateParam = new TokenValidationParameters
            {
                //tự cấp token
                ValidateIssuer = false,
                ValidateAudience = false,

                //ký vào token
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),

                ClockSkew = TimeSpan.Zero,

                ValidateLifetime = false //ko kiểm tra token hết hạn
            };
            try
            {
                //check 1: AccessToken valid format
                var tokenInVerification = jwtTokenHandler.ValidateToken(model.AccessToken, tokenValidateParam, out var validatedToken);

                //check 2: Check alg
                if (validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha512, StringComparison.InvariantCultureIgnoreCase);
                    if (!result)//false
                    {
                        dynamic rs = new BaseResponseModel<string>(statusCode: StatusCodes.Status417ExpectationFailed, code: ResponseCodeConstants.FAILED, message: "Invalid token");
                        return BadRequest(rs);
                    }
                }

                //check 3: Check accessToken expire?
                var utcExpireDate = long.Parse(tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

                var expireDate = ConvertUnixTimeToDateTime(utcExpireDate);
                if (expireDate > DateTime.UtcNow)
                {
                    dynamic rs = new BaseResponseModel<string>(statusCode: StatusCodes.Status417ExpectationFailed, code: ResponseCodeConstants.FAILED, message: "Access token has not yet expired");
                    return BadRequest(rs);
                }

                //check 4: Check refreshtoken exist in DB
                var storedToken = _iRefreshTokenService.CheckExistsToken(model);
                if (storedToken == null)
                {
                    dynamic rs = new BaseResponseModel<string>(statusCode: StatusCodes.Status417ExpectationFailed, code: ResponseCodeConstants.FAILED, message: "Refresh token does not exist");
                    return BadRequest(rs);
                }

                //check 5: check refreshToken is used/revoked?
                if (storedToken.IsUsed)
                {
                    dynamic rs = new BaseResponseModel<string>(statusCode: StatusCodes.Status417ExpectationFailed, code: ResponseCodeConstants.FAILED, message: "Refresh token has been used");
                    return BadRequest(rs);
                }
                if (storedToken.IsRevoked)
                {
                    dynamic rs = new BaseResponseModel<string>(statusCode: StatusCodes.Status417ExpectationFailed, code: ResponseCodeConstants.FAILED, message: "Refresh token has been revoked");
                    return BadRequest(rs);
                }

                //check 6: AccessToken id == JwtId in RefreshToken
                var jti = tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
                if (storedToken.JwtID != jti)
                {
                    dynamic rs = new BaseResponseModel<string>(statusCode: StatusCodes.Status417ExpectationFailed, code: ResponseCodeConstants.FAILED, message: "Token doesn't match");
                    return BadRequest(rs);
                }

                //Update token is used
                storedToken.IsRevoked = true;
                storedToken.IsUsed = true;
                //_context.Update(storedToken);
                //_context.SaveChangesAsync();

                //create new token
                var user = _iNguoiDungService.GetByUserNameAsync(storedToken);
                var token = GenerateToken(user);

                return Ok(new BaseResponseModel<TokenModel>(statusCode: StatusCodes.Status201Created, code: ResponseCodeConstants.SUCCESS, data: token));
            }
            catch (Exception e)
            {
                dynamic rs = new BaseResponseModel<string>(statusCode: StatusCodes.Status417ExpectationFailed, code: ResponseCodeConstants.FAILED, message: e.Message);
                return BadRequest(rs);
            }
        }
        private DateTime ConvertUnixTimeToDateTime(long utcExpireDate)
        {
            var dateTimeInterval = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTimeInterval.AddSeconds(utcExpireDate).ToUniversalTime();

            return dateTimeInterval;
        }*/
    }
}
