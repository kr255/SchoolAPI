using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Threading.Tasks;
using Contracts;
using Entities.DataTransferObjects;
using AutoMapper;

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
        [HttpGet("{id}")]
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

    }
}
