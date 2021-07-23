using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IUserRepository Users { get;  }
        ISectionEnrollRepository SectionEnroll{ get; }
        ICoursesRepository Courses{ get; }
        ICourseSectionRepository CourseSection{ get;  }
        ICourseAssignmentRepository CourseAssignment{ get; }
        void Save();
    }
}
