using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;
namespace Contracts
{
    public interface ICourseAssignmentRepository
    {
        IEnumerable<CourseAssignment> GetAllAssignments(int courseSection, bool trackChanges);
        CourseAssignment GetAssignment(IEnumerable<CourseAssignment> AllAssignments, string title, bool trackChanges);

        //void DeleteAssignment(CourseAssignment assignment);
        void CreateAssignment(int csid, CourseAssignment assignment);



    }
}
