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
    [Route("api/[controller]")]
    public class CourseAssignmentController : ControllerBase
    {
        private ILoggerManager _logger;
        private readonly IRepositoryManager _repository;

        public CourseAssignmentController(IRepositoryManager repositoryManager)
        {
            _repository= repositoryManager;
        }

       
    }
}
