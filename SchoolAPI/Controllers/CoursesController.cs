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
    [Route("api/courses")]
    public class CoursesController : ControllerBase
    {
        private ILoggerManager _logger;
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;


        public CoursesController(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            _repository = repositoryManager;
            _logger = loggerManager;
            _mapper = mapper;

        }

        [HttpGet]
        public IActionResult GetCourses()
        {
            //throw new Exception("Exception");
            var courses = _repository.Courses.GetAllCourses(trackChanges: false);
            
            var CoursesDTO = _mapper.Map<IEnumerable<CoursesDTO>>(courses);
            return Ok(CoursesDTO);

        }


    }
}
