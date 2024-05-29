using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UitoUx.AppD.DTO.Services;
using UitoUx.AppD.DTO.UserRegister;
using UitoUx.DataAccess.Common;
using UitoUx.Domain.Models;

namespace UiToUx_Sith_Api_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {

        private readonly AppDbContext _dbContext;
        private readonly AuthServices _authService;


        public RegisterController(AppDbContext dbContext, AuthServices authService)
        {
            _dbContext = dbContext;
            _authService = authService;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> Create([FromBody] CreateUserRegDto createUserRegDto)
        {
            if ((createUserRegDto.Password == null && createUserRegDto.ConfirmPassword == null) || (createUserRegDto.Password == null || createUserRegDto.ConfirmPassword == null))
            {
                return BadRequest("Password and Confirm Password Must!");
            }

            var dept = _dbContext.Register.Where(x => x.EmailAddress == createUserRegDto.EmailAddress).FirstOrDefault();

            _authService.CreatePasswordHash(createUserRegDto.Password, out byte[] passwordHash, out byte[] passwordSalt);


            if (dept != null)
            {
                return Ok("User Already Exists");
            }
            Register register = new Register
            {
                FirstName = createUserRegDto.FirstName,
                MiddelName = createUserRegDto.MiddelName,
                SurName = createUserRegDto.SurName,
                EmailAddress = createUserRegDto.EmailAddress,
                //Password=createUserRegDto.Password,
                //ConfirmPassword=createUserRegDto.ConfirmPassword,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                RegisterDateAndTime = createUserRegDto.RegisterDateAndTime,

            };

            _dbContext.Register.Add(register);
            await _dbContext.SaveChangesAsync();
            return Ok("Welcome to UiToUx Solutions! Happy onboarding!");

        }


        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login(LoginuserDto loginUserDto)
        {
            var user = _dbContext.Register.FirstOrDefault(x => x.EmailAddress == loginUserDto.EmailAddress);
           
            bool checkinglogin =  _authService.VerifyPasswordHash(loginUserDto.Password,user.PasswordHash, user.PasswordSalt);
            if (checkinglogin)
            {
                return Ok("Login Successfully!");
            }
            return Ok("Username Password is in correct!");

        }
    }
}
