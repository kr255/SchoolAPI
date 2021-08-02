using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;
namespace Contracts
{
    public interface ICourseAssignmentRepository
    {
        IEnumerable<CourseAssignment> GetAllAssignments(bool trackChanges);
        CourseAssignment GetAssignment(string title, bool trackChanges);

        void CreateAssignment(int cid, int csid, CourseAssignment assignment);



    }
}
