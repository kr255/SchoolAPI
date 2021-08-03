using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class CourseAssignmentRepository : RepositoryBase<CourseAssignment>, ICourseAssignmentRepository
    {
        public CourseAssignmentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        { }

        public void CreateAssignment(int csid, CourseAssignment assignment)
        {
            
            assignment.cs_id = csid;
            Create(assignment);

        }

        public IEnumerable<CourseAssignment> GetAllAssignments(int courseSection, bool trackChanges) =>
         FindByCondition(e => e.cs_id.Equals(courseSection), trackChanges)
        .OrderBy(c => c.cs_id)
        .ToList();

        public CourseAssignment GetAssignment(IEnumerable<CourseAssignment> allAssignments, string title, bool trackChanges) =>
            FindByCondition(allAssignments => allAssignments.ca_title.Trim().ToLower().Equals(title), trackChanges)
            .SingleOrDefault();


        
    }


}
