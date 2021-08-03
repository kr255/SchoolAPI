using Microsoft.AspNetCore.Mvc;
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
    [ApiExplorerSettings(GroupName = "v1")]
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
            
            var userEntity = _mapper.Map<Users>(user);
            
            _repository.Users.CreateUser(userEntity);
            _repository.Save();

            var userToReturn = _mapper.Map<UsersDTO>(userEntity);
            return CreatedAtRoute( "UserById", new { id = userToReturn.UserId }, userToReturn);
        }
        [HttpGet("collection/({ids})", Name = "UserCollection")]
        public IActionResult GetUsersCollection(IEnumerable<int> ids)
        {
            if (ids == null)
            {
                _logger.LogError("Parameter ids is null");
                return BadRequest("Parameter ids is null");
            }
            var UserEntities = _repository.Users.GetUsersById(ids, trackChanges: false);
            if(ids.Count() != UserEntities.Count())
            {
                _logger.LogError("Some ids are not valid in a collection"); 
                return NotFound();
            }
            var usersToReturn = _mapper.Map<IEnumerable<UsersDTO>>(UserEntities);
            return Ok(usersToReturn);
        }
        [HttpPost("collection")]
        public IActionResult CreateUsersCollection([FromBody] IEnumerable<UsersDTOForCreating> usersCollection)
        {

            if (usersCollection == null)
            {
                _logger.LogError("Company collection sent from client is null."); 
                return BadRequest("Company collection is null");
            }
            var userEntities = _mapper.Map<IEnumerable<Users>>(usersCollection);
            foreach (var user in userEntities)
            {
                _repository.Users.CreateUser(user);
            }

            _repository.Save();

            var usersCollectionToReturn = _mapper.Map<IEnumerable<Users>>(userEntities);
            var ids = string.Join(',', usersCollectionToReturn.Select(c => c.UserId));

            return CreatedAtRoute("UserCollection", new { ids }, usersCollectionToReturn);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _repository.Users.GetUser(id, trackChanges: false);
            if (user == null)
            {
                _logger.LogInfo($"User with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.Users.DeleteUser(user);
            _repository.Save();
            return NoContent();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UsersDTOForUpdating user)
        {
            if (user == null)
            {

                _logger.LogError("UsersDTOForCreating object sent from client is null.");
                return BadRequest("UsersDTOForCreating object is null");
            }
            var userEntity = _repository.Users.GetUser(id, trackChanges: true);
            if (userEntity == null)
            {
                _logger.LogInfo($"User with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _mapper.Map(user, userEntity);
            _repository.Save();
            return NoContent();

        }
    }
}
