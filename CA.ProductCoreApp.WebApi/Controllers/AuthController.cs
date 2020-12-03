using AutoMapper;
using CA.ProductCoreApp.Business.Interfaces;
using CA.ProductCoreApp.Business.StringInfos;
using CA.ProductCoreApp.Entities.Concrete;
using CA.ProductCoreApp.Entities.Dtos.AppUserDtos;
using CA.ProductCoreApp.Entities.Token;
using CA.ProductCoreApp.WebApi.CustomFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CA.ProductCoreApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;

        public AuthController(IJwtService jwtService, IAppUserService appUserService, IMapper mapper)
        {
            _jwtService = jwtService;
            _appUserService = appUserService;
            _mapper = mapper;
        }

        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignIn(AppUserLoginDto appUserLoginDto)
        {
            var appUser = await _appUserService.FindByUserName(appUserLoginDto.UserName);
            if(appUser == null)
            {
                return BadRequest("Kullanıcı Adı veya Parola Hatalı");
            }
            else
            {
                if (await _appUserService.CheckPassword(appUserLoginDto))
                {
                    var roles = await _appUserService.GetRolesByUserName(appUserLoginDto.UserName);
                    var token = _jwtService.GenerateJwt(appUser, roles);

                    JwtAccessToken jwtAccessToken = new JwtAccessToken(token);
                    
                    return Created("", jwtAccessToken);
                }
                return BadRequest("Kullanıcı Adı veya Parola Hatalı");
            }         
        }

        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignUp(AppUserAddDto appUserAddDto, 
            [FromServices] IAppUserRoleService appUserRoleService, [FromServices] IAppRoleService appRoleService)
        {
            var appUser = await _appUserService.FindByUserName(appUserAddDto.Username);

            if(appUser != null)
            {
                return BadRequest($"{appUserAddDto.Username} kullanılıyor. Farklı Kullanıcı Adı ile Tekrar Deneyin.");
            }

            await _appUserService.Add(_mapper.Map<AppUser>(appUserAddDto));

            var getUser = await _appUserService.FindByUserName(appUserAddDto.Username);
            var role = await appRoleService.FindByName(RoleInfo.Member);

            await appUserRoleService.Add(new AppUserRole
            {
                AppUserId = getUser.Id,
                AppRoleId = role.Id
            });

            return Created("", appUserAddDto);
        }

        [HttpGet("[action]")]
        [Authorize]
        public async Task<IActionResult> ActiveUser()
        {
            var user = await _appUserService.FindByUserName(User.Identity.Name);
            var roles = await _appUserService.GetRolesByUserName(User.Identity.Name);

            AppUserDto appUserDto = new AppUserDto
            {
                FullName = user.FullName,
                Username = user.Username,
                Roles = roles.Select(I => I.Name).ToList()
            };

            return Ok(appUserDto);
         }
    }
}
