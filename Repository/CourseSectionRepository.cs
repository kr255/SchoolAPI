using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class CourseSectionRepository : RepositoryBase<CourseSection>, ICourseSectionRepository
    {
        public CourseSectionRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        { }
    }
}
