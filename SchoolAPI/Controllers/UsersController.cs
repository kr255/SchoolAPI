using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Threading.Tasks;
using Contracts;
namespace SchoolAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private ILoggerManager _logger;
        private readonly IRepositoryManager _repository;

        public UsersController(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            _repository= repositoryManager;
            _logger = loggerManager;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            try
            {
                var users = _repository.Users.GetAllUsers(trackChanges: false);
                return Ok(users);
            }
            catch(Exception ex) 
            {
                _logger.LogError($"Something went wrong in the {nameof(GetUsers)} action {ex}");
                return StatusCode(500, "Internal Error");
            }
        }

       
    }
}
