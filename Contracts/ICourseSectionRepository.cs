using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;
namespace Contracts
{
    public interface ICourseSectionRepository
    {
        IEnumerable<CourseSection> GetAllSections(int cid, bool trackChanges);
        public CourseSection GetSectionById(int cid, int csid, bool trackChanges);

        void CreateSection(int cid, CourseSection section);
        void DeleteSection(CourseSection section);
    }
}
