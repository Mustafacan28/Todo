using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Business.DependencyInjection.Autofac;

using Business.MessagesContent.Models;
using Todo.Api.Models;

namespace Todo.Api.Controllers
{

    [Route("api")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        IUserService _userService;
        ITaskService _taskService;
       

        public AuthController(ITaskService taskService, IUserService userService )
        {
            _taskService = taskService;
            _userService = userService;
           
        }



        [HttpGet("getuser")]
        public IActionResult LoginAuth()
        {
            return Ok(_userService.GetAll());
            //if (user != null && user.UserName != null && user.Password != null)
            //{
            //    var userData = _userService.GetUser(user.UserName, user.Password);

            //    if (userData != null)
            //    {

            //        var claims = new[] {
            //            new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
            //            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            //            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            //            new Claim("UserId", userData.UserId.ToString()),
            //            new Claim("UserName", userData.UserName),
            //            new Claim("LastName", userData.LastName),
            //            new Claim("Telephone", userData.Telephone)
            //        };

            //        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            //        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //        var token = new JwtSecurityToken(
            //            _configuration["Jwt:Issuer"],
            //            _configuration["Jwt:Audience"],
            //            claims,
            //            expires: DateTime.UtcNow.AddMinutes(10),
            //            signingCredentials: signIn);
            //        AuthResponseModel responseModel = new();
            //        responseModel.BearToken = new JwtSecurityTokenHandler().WriteToken(token);

            //        return Ok(responseModel.BearToken);

            //        //return Ok(_claimModule.Claim(user));
            //    }
            //    else
            //    {
            //        return BadRequest(new AuthResponseModel { ErrorMessage = "Giriş Başarısız", BearToken = "Oluşturulamadı", Success = false });
            //    }
            //}
            //else
            //{
            //    return BadRequest(new AuthResponseModel { Success = false, ErrorMessage = "Kullanıcı adı ve şifre giriniz!" });
            //}
        }
        [AllowAnonymous]
        [HttpGet("getall")]
        public IActionResult Get()
        {
            return Ok(_taskService.GetAll());
        }

        [AllowAnonymous]
        [HttpPost("AddTask")]
        public IActionResult AddTask(Taskk task)
        {
            _taskService.Add(task);
            return Ok();
        }


        [AllowAnonymous]
        [HttpPut("TaskUpdate")]
        public IActionResult TaskUpdate(Taskk task)
        {
           
            _taskService.Update(task);


            return Ok();
        }
        [AllowAnonymous]
        [HttpDelete("DeleteTask")]
        public IActionResult DeleteTask(int id)
        {
            var data = _taskService.GetById(id);
            _taskService.Delete(data);
            return Ok();
        }

    }


}


