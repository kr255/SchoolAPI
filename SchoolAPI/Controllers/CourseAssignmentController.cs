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
    [Route("api/course/{course}/section/{courseSection}/assignment", Name ="Default")]
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
        public IActionResult GetCourseAssignments(int course, int courseSection)
        {
            //add the if condition for null courseSection Assignment
            var Asection = _repository.CourseSection.GetSectionById(course, courseSection, trackChanges: false);
            var coursesAssignments = _repository.CourseAssignment.GetAllAssignments(courseSection, trackChanges: false);
            if (Asection == null)
            {

                _logger.LogInfo($"Section with id: {Asection} doesn't exist in the database.");
                return NotFound();

            }
            
            var CourseAssignmentDTO = _mapper.Map<IEnumerable<CourseAssignmentDTO>>(coursesAssignments);
            return Ok(CourseAssignmentDTO);

        }
        [HttpGet("{catitle}", Name = "assignmentByTitile")]
        public IActionResult GetCourseAssignment(int course, int courseSection, string catitle)
        {
            var AllCoursesAssignments = _repository.CourseAssignment.GetAllAssignments(courseSection, trackChanges: false);
            if (AllCoursesAssignments == null)
            {
                _logger.LogInfo($"Assignments doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var coursesAssignments = _repository.CourseAssignment.GetAssignment(AllCoursesAssignments, catitle, trackChanges: false);
                //var OneAssignment = coursesAssignments.Select(t => t.ca_title.Trim().ToLower().Equals(title.Trim().ToLower())).SingleOrDefault();
                var CourseAssignmentDTO = _mapper.Map<CourseAssignmentDTO>(coursesAssignments);
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

            _repository.CourseAssignment.CreateAssignment(courseSection, AssignmentEntity);
            _repository.Save();

            var assignmentToReturn = _mapper.Map<CourseAssignmentDTO>(AssignmentEntity);
            return CreatedAtRoute("assignmentByTitile", new { /*course, courseSection, V = "assignments",*/
                                                                course,
                                                                courseSection,
                                                                catitle = AssignmentEntity.ca_title}, assignmentToReturn);
        }


    }
}
