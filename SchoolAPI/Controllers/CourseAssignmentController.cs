using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Threading.Tasks;
using Contracts;
using AutoMapper;
using Entities.DataTransferObjects;


namespace SchoolAPI.Controllers
{
    [ApiController]
    [Route("api/{course}/{courseSection}/assignments")]
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
        [HttpGet("{cid}")]
        public IActionResult GetCourseAssignment(int cid)
        {
            var coursesAssignments = _repository.CourseAssignment.GetAssignment(cid, trackChanges: false);
            if (coursesAssignments == null)
            {
                _logger.LogInfo($"Assignment with id: {cid} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var CourseAssignmentDTO = _mapper.Map<IEnumerable<CourseAssignmentDTO>>(coursesAssignments);
                return Ok(CourseAssignmentDTO);
            }

            

        }


    }
}
