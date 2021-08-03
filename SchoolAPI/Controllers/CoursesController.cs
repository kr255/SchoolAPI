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
    [Route("api/course")]
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

        [HttpGet("{cid}", Name ="CourseById")]
        public IActionResult getGetCourseById(int cid)
        {
            //throw new Exception("Exception");
            var course = _repository.Courses.GetCourseById(cid, trackChanges: false);

            if (course == null)
            {

                _logger.LogInfo($"Course with id: {cid} doesn't exist in the database.");
                return NotFound();

            }

            var CoursesDTO = _mapper.Map<CoursesDTO>(course);
            return Ok(CoursesDTO);

        }

        [HttpPost]
        public IActionResult CreateCourse([FromBody] CoursesDTOForCreating course)
        {
            if (course == null)
            {

                _logger.LogError("CoursesDTOForCreating object sent from client is null.");
                return BadRequest("CoursesDTOForCreating object is null");
            }

            var courseEntity = _mapper.Map<Courses>(course);

            _repository.Courses.CreateCourse(courseEntity);
            _repository.Save();

            var courseToReturn = _mapper.Map<CoursesDTO>(courseEntity);
            return CreatedAtRoute("CourseById", new { cid = courseToReturn.courseid }, courseToReturn);
        }

        [HttpDelete("{cid}")]
        public IActionResult DeleteCourse(int cid)
        { 
        
            var course = _repository.Courses.GetCourseById(cid, trackChanges: false);
            if (course == null)
            {

                _logger.LogInfo($"Course with id: {cid} doesn't exist in the database.");
                return NotFound();

            }
            _repository.Courses.DeleteCourse(course);
            _repository.Save();

            return NoContent();
        }


    }
}
