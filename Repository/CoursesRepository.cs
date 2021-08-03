using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class CoursesRepository : RepositoryBase<Courses>, ICoursesRepository
    {
        public CoursesRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        { }

        public IEnumerable<Courses> GetAllCourses(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(c => c.courseid)
            .ToList();

        public Courses GetCourseById(int courseID, bool trackChanges) =>
            FindByCondition(c => c.courseid.Equals(courseID), trackChanges)
            .SingleOrDefault();

        public void CreateCourse(Courses course) => Create(course);

        public void DeleteCourse(Courses course)
        {
            Delete(course);
        }
    }
}
