using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class CoursesRepository : RepositoryBase<Courses>, ICoursesRepository
    {
        public CoursesRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        { }

        public IEnumerable<Courses> GetAllCourses(bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}
