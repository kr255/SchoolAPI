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

        public void CreateAssignment(int cid, int csid, CourseAssignment assignment)
        {
            
            assignment.cs_id = csid;
            Create(assignment);

        }

        public IEnumerable<CourseAssignment> GetAllAssignments(bool trackChanges) =>
         FindAll(trackChanges)
        .OrderBy(c => c.cs_id)
        .ToList();

        public CourseAssignment GetAssignment(string title, bool trackChanges) =>
            FindByCondition(e => e.ca_title == (title), trackChanges)
            .SingleOrDefault();


        
    }


}
