using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;
namespace Contracts
{
    public interface ICourseSectionRepository
    {
        IEnumerable<CourseSection> GetAllSections(bool trackChanges);

    }
}
