using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class CourseAssignmentRepository : RepositoryBase<CourseAssignment>, ICourseAssignmentRepository
    {
        public CourseAssignmentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        { }

        public IEnumerable<CourseAssignment> GetAllAssignments(bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}
