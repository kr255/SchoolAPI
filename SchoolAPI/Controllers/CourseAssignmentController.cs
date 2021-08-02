using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Threading.Tasks;
using Contracts;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace SchoolAPI.Controllers
{
    [ApiController]
    [Route("api/{course}/{courseSection}/assignments", Name ="Default")]
    public class CourseAssignmentController : ControllerBase
    {
        private ILoggerManager _logger;
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public CourseAssignmentController(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            _repository = repositoryManager;
            _logger = loggerManager;
            _mapper = mapper;

        }
        [HttpGet]
        public IActionResult GetCourseAssignments()
        {
            var coursesAssignments = _repository.CourseAssignment.GetAllAssignments(trackChanges: false);
            var CourseAssignmentDTO = _mapper.Map<IEnumerable<CourseAssignmentDTO>>(coursesAssignments);
            return Ok(CourseAssignmentDTO);

        }
        [HttpGet("{catitle}", Name = "assignmentByTitile")]
        public IActionResult GetCourseAssignment(string title)
        {
            var coursesAssignments = _repository.CourseAssignment.GetAssignment(title, trackChanges: false) ;
            if (coursesAssignments == null)
            {
                _logger.LogInfo($"Assignment with title: {title} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var CourseAssignmentDTO = _mapper.Map<IEnumerable<CourseAssignmentDTO>>(coursesAssignments);
                return Ok(CourseAssignmentDTO);
            }

        }

        [HttpPost]
        public IActionResult CreateAssignment(int course, int courseSection, [FromBody] CourseAssignmentDTOForCreating assignment)
        {
            if (assignment == null)
            {

                _logger.LogError("CourseAssignmentDTOForCreating object sent from client is null.");
                return BadRequest("CourseAssignmentDTOForCreating object is null");
            }

            var Asection = _repository.CourseSection.GetSectionById(course, courseSection, trackChanges: false);
            if (Asection == null)
            {

                _logger.LogInfo($"Section with id: {Asection} doesn't exist in the database.");
                return NotFound();

            }
            var AssignmentEntity = _mapper.Map<CourseAssignment>(assignment);

            _repository.CourseAssignment.CreateAssignment(course, courseSection, AssignmentEntity);
            _repository.Save();

            var assignmentToReturn = _mapper.Map<CourseAssignmentDTO>(AssignmentEntity);
            return CreatedAtRoute("Default", new { course, courseSection, V = "assignments", catitle= AssignmentEntity.ca_title}, assignmentToReturn);
        }


    }
}
