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
    [Route("api/sectionenroll")]
    public class SectionEnrollController : ControllerBase
    {
        private ILoggerManager _logger;
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public SectionEnrollController(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            _repository= repositoryManager;
            _logger = loggerManager;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetSectionEnroll()
        {

            var sectionEnroll = _repository.SectionEnroll.GetAllEnrollSections(trackChanges: false);
            var sectionEnrollDTO = _mapper.Map<SectionEnrollDTO>(sectionEnroll); 
            return Ok(sectionEnrollDTO);
        }
       
    }
}
