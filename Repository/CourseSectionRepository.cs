using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class CourseSectionRepository : RepositoryBase<CourseSection>, ICourseSectionRepository
    {
        public CourseSectionRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        { }

        public IEnumerable<CourseSection> GetAllSections(bool trackChanges) =>
         FindAll(trackChanges)
        .OrderBy(c => c.course_id)
        .ToList();
    }
}
