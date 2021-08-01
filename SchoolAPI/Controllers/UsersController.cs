﻿using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Threading.Tasks;
using Contracts;
using Entities.DataTransferObjects;
using AutoMapper;
using Entities.Models;

namespace SchoolAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private ILoggerManager _logger;
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public UsersController(IRepositoryManager repositoryManager, 
                               ILoggerManager loggerManager, 
                               IMapper mapper)
        {
            _repository= repositoryManager;
            _logger = loggerManager;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            //throw new Exception("Exception");
            var users = _repository.Users.GetAllUsers(trackChanges: false);
                //var UsersDTO = users.Select(c => new UsersDTO
                //{ 
                //    Id = c.user_id,
                //    name = c.name,
                //    password = c.password,
                //    email = c.email,
                //    enroll_status = c.enroll_status,
                //    FullRecord = string.Join(' ', c.user_id, c.email, c.password)
                //}).ToList();
                var UsersDTO = _mapper.Map<IEnumerable<UsersDTO>>(users);
                return Ok(UsersDTO);

        }
        [HttpGet("{id}", Name = "UserById")]
        public IActionResult GetUser(int id)
        {
            var user = _repository.Users.GetUser(id, trackChanges: false);
            if (user == null)
            {
                _logger.LogInfo($"User with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var UsersDTO = _mapper.Map<UsersDTO>(user);
                return Ok(UsersDTO);

            }

        }
        [HttpPost]
        public IActionResult CreateUser([FromBody]UsersDTOForCreating user) 
        {
            if (user == null)
            {

                _logger.LogError("UsersDTOForCreating object sent from client is null.");
                return BadRequest("UsersDTOForCreating object is null");
            }
            //var newUserEntity = new Users();

            //newUserEntity.name = user.name;
            //newUserEntity.email = user.email;
            //newUserEntity.password = user.password;
            //newUserEntity.enroll_status = user.enroll_status;
            //newUserEntity.sys_role_id = user.sys_role_id;
            
            var userEntity = _mapper.Map<Users>(user);
            
            _repository.Users.CreateUser(userEntity);
            _repository.Save();

            var userToReturn = _mapper.Map<UsersDTO>(userEntity);
            return CreatedAtRoute( "UserById", new { id = userToReturn.UserId }, userToReturn);
        }

    }
}
