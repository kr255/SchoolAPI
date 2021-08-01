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
    [Route("api/{course}")]
    public class CourseSectionController : ControllerBase
    {
        private ILoggerManager _logger;
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public CourseSectionController(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            _repository= repositoryManager;
            _logger = loggerManager;
            _mapper = mapper;

        }

        [HttpGet]
        public IActionResult GetCourseSection(int course)
        {
            var Acourse = _repository.Courses.GetCourseById(course, trackChanges: false);

            var courseSection = _repository.CourseSection.GetAllSections(course, trackChanges: false);

            if (Acourse == null)
            {

                _logger.LogInfo($"Section with id: {course} doesn't exist in the database.");
                return NotFound();

            }
            else
            {

                var courseSectionDTO = _mapper.Map<IEnumerable<CourseSectionDTO>>(courseSection);
                return Ok(courseSectionDTO);
            }
            
        }
        [HttpGet("{csid}", Name = "SectionByCourse")]
        public IActionResult GetCourseSectionFromId(int course, int csid)
        {
            var Acourse = _repository.Courses.GetCourseById(course, trackChanges: false);


            if (Acourse == null)
            {

                _logger.LogInfo($"Course with id: {course} doesn't exist in the database.");
                return NotFound();

            }
            else
            {
                var courseSection = _repository.CourseSection.GetSectionById(course, csid, trackChanges: false);
                var courseSectionDTO = _mapper.Map<CourseSectionDTO>(courseSection);
                return Ok(courseSectionDTO);
            }
        }

        [HttpPost]
        public IActionResult CreateSection(int course, [FromBody] CourseSectionDTOForCreating section)
        {
            if (section == null)
            {

                _logger.LogError("CourseSectionDTOForCreating object sent from client is null.");
                return BadRequest("CourseSectionDTOForCreating object is null");
            }

            var Acourse = _repository.Courses.GetCourseById(course, trackChanges: false);
            if (Acourse == null)
            {

                _logger.LogInfo($"Course with id: {course} doesn't exist in the database.");
                return NotFound();

            }
            var sectionEntity = _mapper.Map<CourseSection>(section);

            _repository.CourseSection.CreateSection(course, sectionEntity);
            _repository.Save();

            var sectionToReturn = _mapper.Map<CourseSectionDTO>(sectionEntity);
            return CreatedAtRoute("SectionByCourse", new { course, csid = sectionToReturn.cs_id}, sectionToReturn);
        }

    }
}
