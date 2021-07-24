using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Contracts
{
    public interface ICoursesRepository
    {
        IEnumerable<Courses> GetAllCourses(bool trackChanges);

    }
}
