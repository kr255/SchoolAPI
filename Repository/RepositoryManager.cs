using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private IUserRepository _userRepository;
        private ICoursesRepository _coursesRepository;
        private ISectionEnrollRepository _sectionEnrollRepository;
        private ICourseSectionRepository _courseSectionRepository;
        private ICourseAssignmentRepository _courseAssignmentRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IUserRepository Users 
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_repositoryContext);
                return _userRepository;
            }
        }
        public ISectionEnrollRepository SectionEnroll 
        {
            get
            {
                if (_sectionEnrollRepository == null)
                    _sectionEnrollRepository = new SectionEnrollRepository(_repositoryContext);
                return _sectionEnrollRepository;
            }
        }
        public ICoursesRepository Courses 
        {
            get
            {
                if (_coursesRepository == null)
                    _coursesRepository = new CoursesRepository(_repositoryContext);
                return _coursesRepository;
            }
        }
        public ICourseSectionRepository CourseSection 
        {
            get
            {
                if (_courseSectionRepository == null)
                    _courseSectionRepository= new CourseSectionRepository(_repositoryContext);
                return _courseSectionRepository;
            }
        }
        public ICourseAssignmentRepository CourseAssignment
        {
            get
            {
                if (_courseAssignmentRepository == null)
                    _courseAssignmentRepository = new CourseAssignmentRepository(_repositoryContext);
                return _courseAssignmentRepository;
            }
        }

        public void Save() => _repositoryContext.SaveChanges();
    }
}
