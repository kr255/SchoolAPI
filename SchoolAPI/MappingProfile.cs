using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using System;

/// <summary>
/// Summary description for Class1
/// </summary>
/// 
namespace SchoolAPI {

	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Users, UsersDTO>()
				.ForMember(c => c.FullRecord,
				opt => opt.MapFrom(x => string.Join(' ', x.UserId, x.name, x.email, x.enroll_status)));

			CreateMap<Courses, CoursesDTO>()
				.ForMember(c => c.FullRecord,
					opt => opt.MapFrom(x => string.Join(' ', x.courseid, x.course_name, x.course_description)));
			
			CreateMap<CourseAssignment, CourseAssignmentDTO>()
				.ForMember(c => c.FullRecord,
					opt => opt.MapFrom(x => string.Join(' ', x.cs_id, x.ca_title, x.ca_description)));

			CreateMap<CourseSection, CourseSectionDTO>()
			.ForMember(c => c.FullRecord,
					opt => opt.MapFrom(x => string.Join(' ', x.courseid, x.cs_id, x.cs_create_date, x.cs_end_date, x.cs_start_date, x.cs_update_date)));

			//CreateMap<CourseSection, CourseSectionDTO>();

			CreateMap<SectionEnroll, SectionEnrollDTO>()
				.ForMember(c => c.FullRecord,
					opt => opt.MapFrom(x => string.Join(' ', x.section_key, x.se_created_date, x.se_updated_date, x.se_start_date, x.se_end_date)));

			CreateMap<UsersDTOForCreating, Users>();
			CreateMap<CoursesDTOForCreating, Courses>();
			CreateMap<CourseSectionDTOForCreating, CourseSection>();
			CreateMap<CourseAssignmentDTOForCreating, CourseAssignment>();
		}
	}


}
