using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObject.BusinessObject;
using Service.Interface;
using AutoMapper;
using BusinessObject.ViewModels;
using System.Security.Principal;
using BusinessObject.DTO;
using Microsoft.AspNetCore.Authorization;

namespace GroupProject.Controllers.UserController
{





    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userServices;
        private readonly IMapper _mapper;

        public UsersController(IUserService userServices, IMapper mapper)
        {
            _userServices = userServices;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllUser()
        {
            try
            {
                if (_userServices.GetAllUser() == null)
                {
                    return NotFound();
                }
                var users = _userServices.GetAllUser();
                var response = _mapper.Map<List<UserVM>>(users);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetUserByID(int id)
        {
            var user = _userServices.GetUserByID(id);

            var responese = _mapper.Map<UserVM>(user);

            return Ok(responese);
        }

        [HttpPost]
        public IActionResult AddNewUser(UserCreateDTO user)
        {
            try
            {
                var _user = _mapper.Map<User>(user);
                _userServices.AddNewUser(_user);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateUser(UserDTO user, int id)
        {
            try
            {
                if (user.UserID != id)
                {
                    return NotFound();
                }
                var _user = _mapper.Map<User>(user);
                _userServices.UpdateUser(_user);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            if (_userServices.GetAllUser() == null)
            {
                return NotFound();
            }
            var user = _userServices.GetUserByID(id);
            if (user == null)
            {
                return NotFound();
            }

            _userServices.ChangeStatusUser(user);


            return Ok("Delete Successfully");
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            var checkEmail = _userServices.GetAllUser().Where(u =>
                u.Email.Equals(register.Email)).FirstOrDefault();

            if (checkEmail != null)
            {
                return BadRequest("Email Existed");
            }

            var user = new UserCreateDTO
            {
                UserName = register.UserName,
                FullName = register.FullName,
                PhoneNumber = register.PhoneNumber,
                Email = register.Email,
                Password = register.Password,
                Status = true,
                RoleID = 1,
                BidID = 4
            };


            var _user = _mapper.Map<User>(user);
            _userServices.AddNewUser(_user);

            return Ok(user);

        }


    }
}
