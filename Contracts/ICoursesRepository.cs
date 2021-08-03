using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Contracts
{
    public interface ICoursesRepository
    {
        IEnumerable<Courses> GetAllCourses(bool trackChanges);
        public Courses GetCourseById(int courseID, bool trackChanges);

        public void CreateCourse(Courses course);
        public void DeleteCourse(Courses course);

    }
}
